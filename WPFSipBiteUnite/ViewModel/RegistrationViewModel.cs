using System.Windows.Input;
using DALSipBiteUnite.DbContext;
using DALSipBiteUnite.Repositories;
using DALSipBiteUnite.DataBaseClasses;
using System.Text.RegularExpressions;

namespace WPFSipBiteUnite.ViewModel
{
    public class RegistrationViewModel:ViewModelBase
    {
        public string Username
        {
            get => _username;
            set
            {
                _username = value;
                OnPropertyChanged(nameof(Username));
            }
        }

        public string Password
        {
            get => _password;
            set
            {
                _password = value;
                OnPropertyChanged(nameof(Password));
            }
        }

        public string ErrorMessage
        {
            get => _errorMessage;
            set
            {
                _errorMessage = value;
                OnPropertyChanged(nameof(ErrorMessage));
            }
        }

        public bool IsViewVisible
        {
            get => _isViewVisible;
            set
            {
                _isViewVisible = value;
                OnPropertyChanged(nameof(IsViewVisible));
            }
        }

        private string _username;
        private string _password;
        private string _errorMessage;
        private bool _isViewVisible = true;
        private IUserRepository _userRepository;
        
        public ICommand RegisterCommand { get; }

        public RegistrationViewModel()
        {
            RegisterCommand = new ViewModelCommand(ExecuteRegisterCommand, CanExecuteRegisterCommand);
            _userRepository = new UserRepository(new ApplicationDbContext());
        }

        private bool CanExecuteRegisterCommand(object obj)
        {
            bool validData = false;

            // Регулярний вираз для перевірки формату email
            string emailPattern = @"^[a-zA-Z0-9._-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,4}$";

            // Перевірка на не null і формат email
            if (Username != null && Regex.IsMatch(Username, emailPattern) && !string.IsNullOrWhiteSpace(Username))
            {
                // Перевірка на умови пароля
                if (Password != null && Password.Length >= 8 && Regex.IsMatch(Password, @"^(?=.*[A-Za-z])(?=.*\d).{8,}$"))
                {
                    validData = true;
                }
            }

            return validData;
        }

        private void ExecuteRegisterCommand(object obj)
        {
            _userRepository.AddUser( new User{UserEmail = Username, UserPassword = Password});
        }
    }
}

