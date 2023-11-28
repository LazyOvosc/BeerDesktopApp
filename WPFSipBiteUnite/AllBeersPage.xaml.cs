using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WPFSipBiteUnite
{
    /// <summary>
    /// Interaction logic for AllBeersPage.xaml
    /// </summary>
    public partial class AllBeersPage : Page
    {
        public AllBeersPage()
        {
            InitializeComponent();
            BeerButton.IsChecked = true;
            FoodButton.IsChecked = false;
            ProfileButton.IsChecked = false;
        }

        private void ProfileButton_Checked(object sender, RoutedEventArgs e)
        {
            BeerButton.IsChecked = false;
            FoodButton.IsChecked = false;
        }

        private void BeerButton_Checked(object sender, RoutedEventArgs e)
        {
            ProfileButton.IsChecked = false;
            FoodButton.IsChecked = false;
        }

        private void FoodButton_Checked(object sender, RoutedEventArgs e)
        {
            BeerButton.IsChecked= false;
            ProfileButton.IsChecked = false;
        }

        private void CustomCardSmall_Loaded(object sender, RoutedEventArgs e)
        {

        }
    }
}
