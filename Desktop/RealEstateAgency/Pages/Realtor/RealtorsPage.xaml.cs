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
    public partial class RealtorsPage : Page
    {
        IPersonFilter _filter;
        public RealtorsPage()
        {
            InitializeComponent();

            var data = RealEstateAgencyEntities.Instance.Realtor.ToArray();
            DGridRealtors.ItemsSource = data;
            _filter = new LevenshteinPersonFilter(data, 3);
        }

        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
            FrameManager.Navigate(new AddEditRealtorPage(((Button)sender).DataContext as Realtor));
        }

        private void RemoveButton_Click(object sender, RoutedEventArgs e)
        {
            var selectedItems = DGridRealtors.SelectedItems.Cast<Realtor>().ToList();

            if (selectedItems.Count <= 0)
            {
                MessageBox.Show("Вы не выбрали не однин элемент для удаления!", "Выберите элементы",
                    MessageBoxButton.OK, MessageBoxImage.Exclamation);
                return;
            }

            if (MessageBox.Show($"Вы действительно хотите удалить {DGridRealtors.SelectedItems.Count} элемента",
                "Внимание!", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                try
                {
                    RealEstateAgencyEntities.Instance.Realtor.RemoveRange(selectedItems);
                    RealEstateAgencyEntities.Instance.SaveChanges();
                    MessageBox.Show("Данные успешно удалены", "Успешно",
                        MessageBoxButton.OK, MessageBoxImage.Information);

                    ReloadDBRealtor();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }

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
            ReloadDBRealtor();
        }
        private void ReloadDBRealtor()
        {
            RealEstateAgencyEntities.Instance.ChangeTracker.Entries().ToList().ForEach(item => item.Reload());
            DGridRealtors.ItemsSource = RealEstateAgencyEntities.Instance.Realtor.ToList();
        }

        private void FilterButton_Click(object sender, RoutedEventArgs e)
        {
            DGridRealtors.ItemsSource = _filter.GetFilteredPersonInfos(FilterTextBox.Text);
        }
    }
}
