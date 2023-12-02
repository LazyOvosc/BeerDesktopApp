using System;
using System.Security;
using System.Security.Principal;
using System.Threading;
using System.Windows.Input;
using DALSipBiteUnite.DbContext;
using DALSipBiteUnite.Repositories;

namespace WPFSipBiteUnite.ViewModel
{
    public class LoginViewModel:ViewModelBase
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
        private UserRepository userRepository;
        
        public ICommand LoginCommand { get; }

        public LoginViewModel()
        {
            LoginCommand = new ViewModelCommand(ExecuteLoginCommand, CanExecuteLoginCommand);
            userRepository = new UserRepository(new ApplicationDbContext());
        }

        private bool CanExecuteLoginCommand(object obj)
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

        private void ExecuteLoginCommand(object obj)
        {
            var user = userRepository.GetUserByName(Username);
            if (user is not null)
            {
                if (user.UserPassword == Password)
                {
                    Thread.CurrentPrincipal = new GenericPrincipal(new GenericIdentity(Username), null);
                    IsViewVisible = false;
                }
                else
                {
                    ErrorMessage = "* Invalid username or password";
                }
            }
        }
    }
}

