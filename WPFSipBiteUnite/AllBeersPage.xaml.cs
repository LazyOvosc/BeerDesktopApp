// <copyright file="AllBeersPage.xaml.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace WPFSipBiteUnite
{
    using System.Windows;
    using System.Windows.Controls;
    using WPFSipBiteUnite.ViewModel;

    /// <summary>
    /// Interaction logic for AllBeersPage.xaml.
    /// </summary>
    public partial class AllBeersPage : Page
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AllBeersPage"/> class.
        /// </summary>
        public AllBeersPage()
        {
            this.InitializeComponent();
            this.DataContext = new BeersExploreViewModel();
            this.BeerButton.IsChecked = true;
            this.FoodButton.IsChecked = false;
            this.ProfileButton.IsChecked = false;
        }

        private void ProfileButton_Checked(object sender, RoutedEventArgs e)
        {
            this.BeerButton.IsChecked = false;
            this.FoodButton.IsChecked = false;
        }

        private void BeerButton_Checked(object sender, RoutedEventArgs e)
        {
            this.ProfileButton.IsChecked = false;
            this.FoodButton.IsChecked = false;
        }

        private void FoodButton_Checked(object sender, RoutedEventArgs e)
        {
            this.BeerButton.IsChecked = false;
            this.ProfileButton.IsChecked = false;
        }

        private void CustomCardSmall_Loaded(object sender, RoutedEventArgs e)
        {
        }
    }
}
