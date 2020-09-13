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
    /// Interaction logic for ClientsPage.xaml
    /// </summary>
    public partial class ClientsPage : Page
    {
        IPersonFilter _filter;
        public ClientsPage()
        {
            InitializeComponent();

            var data = RealEstateAgencyEntities.Instance.Client.ToArray();
            DGridClients.ItemsSource = data;
            _filter = new LevenshteinPersonFilter(data, 3);
        }

        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
            FrameManager.Navigate(new AddEditClientPage(((Button)sender).DataContext as Client));
        }

        private void RemoveButton_Click(object sender, RoutedEventArgs e)
        {
            var selectedItems = DGridClients.SelectedItems.Cast<Client>().ToList();

            if (selectedItems.Count <= 0)
            {
                MessageBox.Show("Вы не выбрали не однин элемент для удаления!", "Выберите элементы", 
                    MessageBoxButton.OK, MessageBoxImage.Exclamation);
                return;
            }

            if(MessageBox.Show($"Вы действительно хотите удалить {DGridClients.SelectedItems.Count} элемента", 
                "Внимание!", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                try
                {
                    RealEstateAgencyEntities.Instance.Client.RemoveRange(selectedItems);
                    RealEstateAgencyEntities.Instance.SaveChanges();
                    MessageBox.Show("Данные успешно удалены", "Успешно",
                        MessageBoxButton.OK, MessageBoxImage.Information);

                    ReloadDBClient();
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            
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
            ReloadDBClient();
        }

        private void ReloadDBClient()
        {
            RealEstateAgencyEntities.Instance.ChangeTracker.Entries().ToList().ForEach(item => item.Reload());
            DGridClients.ItemsSource = RealEstateAgencyEntities.Instance.Client.ToList();
        }

        private void FilterButton_Click(object sender, RoutedEventArgs e)
        {
            DGridClients.ItemsSource = _filter.GetFilteredPersonInfos(FilterTextBox.Text);
        }
    }
}
