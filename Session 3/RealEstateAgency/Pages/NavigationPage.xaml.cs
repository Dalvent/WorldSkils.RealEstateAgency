using RealEstateAgency.Pages;
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

namespace RealEstateAgency
{
    /// <summary>
    /// Interaction logic for NavigationPage.xaml
    /// </summary>
    public partial class NavigationPage : Page
    {
        public NavigationPage()
        {
            InitializeComponent();
        }

        private void ReltorButton_Click(object sender, RoutedEventArgs e)
        {
            FrameManager.Navigate(new RealtorsPage());
        }

        private void ClientButton_Click(object sender, RoutedEventArgs e)
        {
            FrameManager.Navigate(new ClientsPage());
        }

        private void EstleButton_Click(object sender, RoutedEventArgs e)
        {
            FrameManager.Navigate(new EstatesPage());
        }

        private void SupplyButton_Click(object sender, RoutedEventArgs e)
        {
            FrameManager.Navigate(new SuppliesPage());
        }

        private void DemandButton_Click(object sender, RoutedEventArgs e)
        {
            FrameManager.Navigate(new DemandsPage());
        }
    }
}
