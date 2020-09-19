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

namespace RealEstateAgency
{
    /// <summary>
    /// Interaction logic for RealtorsPage.xaml
    /// </summary>
    public partial class RealtorsPage
    {
        DGridEntityManager<Realtor> manager;
        public RealtorsPage()
        {
            InitializeComponent();

            IFilter filter = new LevenshteinPersonFilter(3);
            manager = new DGridEntityManager<Realtor>(DGridRealtors, filter);
        }

        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
            FrameManager.Navigate(new AddEditRealtorPage(((Button)sender).DataContext as Realtor));
        }

        private void RemoveButton_Click(object sender, RoutedEventArgs e)
        {
            manager.RemoveSelected();

        }
        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            FrameManager.Navigate(new AddEditRealtorPage());
        }
        /// <summary>
        /// Необходим для обновления таблицы при возрате на страницу.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Page_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            manager.ReloadTable();
        }
   
        private void FilterButton_Click(object sender, RoutedEventArgs e)
        {
            manager.UseFilter(FilterTextBox.Text);
        }
    }
}
