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

namespace RealEstateAgency.Pages
{
    /// <summary>
    /// Interaction logic for AddDemandTypeChoosePage.xaml
    /// </summary>
    public partial class AddDemandTypeChoosePage : Page
    {
        public AddDemandTypeChoosePage()
        {
            InitializeComponent();
        }

        private void FlatButton_Click(object sender, RoutedEventArgs e)
        {
            FrameManager.Navigate(new AddEditFlatDemandPage());
        }

        private void HouseButton_Click(object sender, RoutedEventArgs e)
        {
            FrameManager.Navigate(new AddEditHouseDemandPage());
        }

        private void LandPlotButton_Click(object sender, RoutedEventArgs e)
        {
            FrameManager.Navigate(new AddEditDemandLandPage());
        }
    }
}
