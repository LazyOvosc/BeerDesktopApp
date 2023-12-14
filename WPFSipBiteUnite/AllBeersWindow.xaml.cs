// <copyright file="AllBeersWindow.xaml.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace WPFSipBiteUnite
{
    using System.Windows;

    /// <summary>
    /// Interaction logic for MainWindow.xaml.
    /// </summary>
    public partial class AllBeersWindow : Window
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AllBeersWindow"/> class.
        /// </summary>
        public AllBeersWindow()
        {
            this.InitializeComponent();

            this.mainFrame.Navigate(new AllBeersPage());
        }
    }
}