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
    /// Interaction logic for EntityPage.xaml
    /// </summary>
    public partial class ClientsPage : Page
    {
        private readonly DGridEntityManager<Client> manager;
        public ClientsPage()
        {
            InitializeComponent();

            IFilter filter = new LevenshteinPersonFilter(3);
            manager = new DGridEntityManager<Client>(DGridClients, filter);
        }

        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
            FrameManager.Navigate(new AddEditClientPage(((Button)sender).DataContext as Client));
        }

        private void RemoveButton_Click(object sender, RoutedEventArgs e)
        {
            manager.RemoveSelected();

        }
        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            FrameManager.Navigate(new AddEditClientPage());
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
