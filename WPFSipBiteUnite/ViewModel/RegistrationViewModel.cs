using System.Windows.Input;
using WPFSipBiteUnite.DataBaseClasses;
using WPFSipBiteUnite.Repositories;
using WPFSipBiteUnite.DbContext;


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
            bool validData;
            if (string.IsNullOrWhiteSpace(Username) || Username.Length < 3 || Password == null || Password.Length<3)
            {
                validData = false;
            }
            else
            {
                validData = true;
            }

            return validData;
        }

        private void ExecuteRegisterCommand(object obj)
        {
            _userRepository.AddUser( new User{name = Username, password = Password});
        }
    }
}

