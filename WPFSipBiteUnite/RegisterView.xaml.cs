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

namespace WPFSipBiteUnite
{
    /// <summary>
    /// Interaction logic for RegisterView.xaml
    /// </summary>
    public partial class RegisterView : Window
    {
        public RegisterView()
        {
            InitializeComponent();
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                DragMove();
            }
        }

        private void txtUser_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            // Логіка переходу до вікна логіну
            LoginView loginWindow = new LoginView();
            loginWindow.Show();
            this.Close();
        }

        private void btnRegister_Click(object sender, RoutedEventArgs e)
        {
            LoginView loginWindow = new LoginView();
            loginWindow.Show();
            this.Close();
        }

        private void btnInfo_Click(object sender, RoutedEventArgs e)
        {
            // Set the alert text
            txtAlert.Text = "Ваш пароль повинен мати мінімум 8 символів і містити хоча б одну цифру та одну букву.";

            DispatcherTimer timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(5);
            timer.Tick += (s, args) =>
            {
                txtAlert.Text = string.Empty;
                timer.Stop();
            };

            timer.Start();
        }


        // Очистіть текст алерта при зміні значення пароля
        private void PasswordBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            txtAlert.Text = string.Empty;
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }


    }
}
