using RealEstateAgency.Data;
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
    /// Interaction logic for EstatesPage.xaml
    /// </summary>
    public partial class EstatesPage : Page
    {
        private readonly DGridEntityManager<Estate> manager;
        public EstatesPage()
        {
            InitializeComponent();
            manager = new DGridEntityManager<Estate>(DGridEstates, null);
        }

        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
            //FrameManager.Navigate(new AddEditRealtorPage(((Button)sender).DataContext as Estate));
        }

        private void RemoveButton_Click(object sender, RoutedEventArgs e)
        {
            manager.RemoveSelected();

        }
        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            FrameManager.Navigate(new AddEditEstatePage());
        }
        /// <summary>
        /// Необходим для обновления таблицы при возрате на страницу.
        /// </summary>
        private void Page_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            manager.ReloadTable();
        }

        private void FilterButton_Click(object sender, RoutedEventArgs e)
        {
            //manager.UseFilter(FilterTextBox.Text);
        }
    }
}