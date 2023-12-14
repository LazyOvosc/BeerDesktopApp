// <copyright file="BindablePasswordBox.xaml.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace WPFSipBiteUnite.CustomControls
{
    using System.Windows;
    using System.Windows.Controls;

    /// <summary>
    /// Interaction logic for a UserControl that makes the PasswordBox's password bindable.
    /// </summary>
    public partial class BindablePasswordBox : UserControl
    {
        /// <summary>
        /// Identifies the <see cref="Password"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty PasswordProperty =
            DependencyProperty.Register(
                nameof(Password),
                typeof(string),
                typeof(BindablePasswordBox));

        /// <summary>
        /// Initializes a new instance of the <see cref="BindablePasswordBox"/> class.
        /// </summary>
        public BindablePasswordBox()
        {
            this.InitializeComponent();
            this.TxtPasswordBox.PasswordChanged += this.OnPasswordChange;
        }

        /// <summary>
        /// Gets or sets the password.
        /// </summary>
        public string Password
        {
            get { return (string)this.GetValue(PasswordProperty); }
            set { this.SetValue(PasswordProperty, value); }
        }

        /// <summary>
        /// Handles the PasswordChanged event of the PasswordBox control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void OnPasswordChange(object sender, RoutedEventArgs e)
        {
            this.Password = this.TxtPasswordBox.Password;
        }
    }
}
