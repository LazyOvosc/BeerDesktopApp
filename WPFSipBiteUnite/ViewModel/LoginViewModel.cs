// <copyright file="LoginViewModel.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace WPFSipBiteUnite.ViewModel
{
    using System;
    using System.Security;
    using System.Security.Principal;
    using System.Threading;
    using System.Windows.Input;
    using DALSipBiteUnite.DbContext;
    using DALSipBiteUnite.Repositories;

    /// <summary>
    /// ViewModel for the LoginView.
    /// </summary>
    public class LoginViewModel : ViewModelBase
    {
        private readonly UserRepository userRepository;
        private string _username = string.Empty;
        private string _password = string.Empty;
        private string _errorMessage = string.Empty;
        private bool _isViewVisible = true;
        private static NLog.Logger logger = NLog.LogManager.GetCurrentClassLogger();



        /// <summary>
        /// Initializes a new instance of the <see cref="LoginViewModel"/> class.
        /// </summary>
        public LoginViewModel()
        {
            this.LoginCommand = new ViewModelCommand(this.ExecuteLoginCommand, this.CanExecuteLoginCommand);
            this.userRepository = new UserRepository(new ApplicationDbContext());
        }

        /// <summary>
        /// Gets or sets the username.
        /// </summary>
        public string Username
        {
            get => this._username;
            set
            {
                this._username = value;
                this.OnPropertyChanged(nameof(this.Username));
            }
        }

        /// <summary>
        /// Gets or sets the password.
        /// </summary>
        public string Password
        {
            get => this._password;
            set
            {
                this._password = value;
                this.OnPropertyChanged(nameof(this.Password));
            }
        }

        /// <summary>
        /// Gets or sets the error message.
        /// </summary>
        public string ErrorMessage
        {
            get => this._errorMessage;
            set
            {
                this._errorMessage = value;
                this.OnPropertyChanged(nameof(this.ErrorMessage));
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether the view is visible.
        /// </summary>
        public bool IsViewVisible
        {
            get => this._isViewVisible;
            set
            {
                this._isViewVisible = value;
                this.OnPropertyChanged(nameof(this.IsViewVisible));
            }
        }

        /// <summary>
        /// Gets the command to login.
        /// </summary>
        public ICommand LoginCommand { get; }

        private bool CanExecuteLoginCommand(object obj)
        {
            bool validData = false;

            if (this.Username != null && !string.IsNullOrWhiteSpace(this.Username))
            {
                if (this.Password != null && this.Password.Length >= 8)
                {
                    validData = true;
                }
            }

            return validData;
        }

        private void ExecuteLoginCommand(object obj)
        {
            try
            {
                var user = this.userRepository.GetUserByName(this.Username);
                if (user is not null)
                {
                    if (user.UserPassword == this.Password)
                    {
                        Thread.CurrentPrincipal = new GenericPrincipal(new GenericIdentity(this.Username), null);
                        this.IsViewVisible = false;
                        logger.Info($"Вітаю у світі Пива {this.Username}");
                        logger.Info($"Успішний вхід для користувача: {this.Username}");
                    }
                    else
                    {
                        this.ErrorMessage = "* Invalid username or password";
                        logger.Warn($"Невірний пароль для користувача: {this.Username}");
                    }
                }
                else
                {
                    logger.Warn($"Користувач не знайдений: {this.Username}");
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex, $"Помилка при вході для користувача: {this.Username}");
                throw;
            }
        }
    }
}