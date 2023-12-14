// <copyright file="ProfileView.xaml.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace WPFSipBiteUnite
{
    using System.Windows;
    using System.Windows.Input;

    /// <summary>
    /// Interaction logic for ProfileView.xaml.
    /// </summary>
    public partial class ProfileView : Window
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ProfileView"/> class.
        /// </summary>
        public ProfileView()
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

        private void BtnClose_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void BtnMinimize_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }
    }
}