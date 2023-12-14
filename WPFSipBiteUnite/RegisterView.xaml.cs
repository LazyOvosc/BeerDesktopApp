// <copyright file="RegisterView.xaml.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace WPFSipBiteUnite
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Data;
    using System.Windows.Documents;
    using System.Windows.Input;
    using System.Windows.Media;
    using System.Windows.Media.Imaging;
    using System.Windows.Shapes;
    using System.Windows.Threading;

    /// <summary>
    /// Interaction logic for RegisterView.xaml.
    /// </summary>
    public partial class RegisterView : Window
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RegisterView"/> class.
        /// </summary>
        public RegisterView()
        {
            this.InitializeComponent();
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                this.DragMove();
            }
        }

        private void TxtUser_TextChanged(object sender, TextChangedEventArgs e)
        {
        }

        private void BtnLogin_Click(object sender, RoutedEventArgs e)
        {
            // Логіка переходу до вікна логіну
            LoginView loginWindow = new LoginView();
            loginWindow.Show();
            this.Close();
        }

        private void BtnRegister_Click(object sender, RoutedEventArgs e)
        {
            LoginView loginWindow = new LoginView();
            loginWindow.Show();
            this.Close();
        }

        private void BtnInfo_Click(object sender, RoutedEventArgs e)
        {
            // Set the alert text
            this.txtAlert.Text = "Ваш пароль повинен мати мінімум 8 символів і містити хоча б одну цифру та одну букву.";

            DispatcherTimer timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(5);
            timer.Tick += (s, args) =>
            {
                this.txtAlert.Text = string.Empty;
                timer.Stop();
            };

            timer.Start();
        }

        // Очистіть текст алерта при зміні значення пароля
        private void PasswordBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            this.txtAlert.Text = string.Empty;
        }

        private void BtnClose_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
