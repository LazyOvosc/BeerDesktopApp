// <copyright file="RegistrationViewModel.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace WPFSipBiteUnite.ViewModel
{
    using System;
    using System.Text.RegularExpressions;
    using System.Windows.Input;
    using DALSipBiteUnite.DataBaseClasses;
    using DALSipBiteUnite.DbContext;
    using DALSipBiteUnite.Repositories;

    /// <summary>
    /// ViewModel for the RegistrationView.
    /// </summary>
    public class RegistrationViewModel : ViewModelBase
    {
        private string _username = string.Empty;
        private string _password = string.Empty;
        private string _errorMessage = string.Empty;
        private bool _isViewVisible = true;
        private IUserRepository _userRepository;
        private static NLog.Logger logger = NLog.LogManager.GetCurrentClassLogger();

        /// <summary>
        /// Initializes a new instance of the <see cref="RegistrationViewModel"/> class.
        /// </summary>
        public RegistrationViewModel()
        {
            #pragma warning disable CS8622
            this.RegisterCommand = new ViewModelCommand(this.ExecuteRegisterCommand, this.CanExecuteRegisterCommand);
            this._userRepository = new UserRepository(new ApplicationDbContext());
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
        /// Gets the register command.
        /// </summary>
        public ICommand RegisterCommand { get; }

        private bool CanExecuteRegisterCommand(object? obj)
        {
            string emailPattern = @"^[a-zA-Z0-9._-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,4}$";

            bool isEmailValid = !string.IsNullOrWhiteSpace(this.Username) && Regex.IsMatch(this.Username, emailPattern);
            bool isPasswordValid = !string.IsNullOrWhiteSpace(this.Password) && this.Password.Length >= 8 && Regex.IsMatch(this.Password, @"^(?=.*[A-Za-z])(?=.*\d).{8,}$");

            if (!isEmailValid || !isPasswordValid)
            {
                logger.Warn($"Реєстрація: невалідні дані для користувача '{this.Username}'");
                return false;
            }

            return true;
        }

        private void ExecuteRegisterCommand(object obj)
        {
            try
            {
                this._userRepository.AddUser(new User { UserEmail = this.Username, UserPassword = this.Password });
                logger.Info($"Реєстрація: новий користувач '{this.Username}' успішно зареєстрований");
            }
            catch (Exception ex)
            {
                logger.Error(ex, $"Реєстрація: помилка при реєстрації користувача '{this.Username}'");
            }
        }
    }
}