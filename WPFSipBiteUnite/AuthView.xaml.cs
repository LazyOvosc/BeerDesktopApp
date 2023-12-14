// <copyright file="AuthView.xaml.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace WPFSipBiteUnite
{
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Input;

    /// <summary>
    /// Interaction logic for LoginView.xaml.
    /// </summary>
    public partial class AuthView : Window
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AuthView"/> class.
        /// </summary>
        public AuthView()
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
        }

        private void BtnRegister_Click(object sender, RoutedEventArgs e)
        {
        }

        private void BtnClose_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
