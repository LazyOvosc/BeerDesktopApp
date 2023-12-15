// <copyright file="App.xaml.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace WPFSipBiteUnite
{
    using System.Windows;

    /// <summary>
    /// Interaction logic for App.xaml.
    /// </summary>
    public partial class App : Application
    {
        /// <summary>
        /// Handles the application start event.
        /// </summary>
        /// <param name="sender">The sender of the event.</param>
        /// <param name="e">Startup event arguments.</param>
        protected void ApplicationStart(object sender, StartupEventArgs e)
        {
            var splashScreenView = new SplashScreenView();
            splashScreenView.Show();
            //var loginView = new LoginView();
            //loginView.Show();
        }
    }
}
