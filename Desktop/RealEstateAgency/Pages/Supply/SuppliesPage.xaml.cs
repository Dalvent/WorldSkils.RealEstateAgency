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
    /// Interaction logic for SuppliesPage.xaml
    /// </summary>
    public partial class SuppliesPage : Page
    {
        private readonly DGridEntityManager<Supply> manager;
        public SuppliesPage()
        {
            InitializeComponent();

            UserErrorCheack[] userErrors = {
                new UserErrorCheack("Запрещено удаление предложения, участвующего в сделке.", IsNotSupplyInDeal)
            };
            manager = new DGridEntityManager<Supply>(DGridSupplies, userErrors);
        }
        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
            FrameManager.Navigate(new AddEditSupplyPage(((Button)sender).DataContext as Supply));
        }

        private void RemoveButton_Click(object sender, RoutedEventArgs e)
        {
            manager.RemoveSelected();
        }
        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            FrameManager.Navigate(new AddEditSupplyPage());
        }
        private bool _isFirstVisibleChanged = true;
        /// <summary>
        /// Необходим для обновления таблицы при возрате на страницу.
        /// _isFirstVisibleChanged - необходима для чтобы не было обновления при инициализации.
        /// </summary>
        private void Page_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if(_isFirstVisibleChanged)
            {
                _isFirstVisibleChanged = false;
                return;
            }

            if((bool)e.NewValue == true)
            {
                manager.ReloadTable();
            }
        }
        private bool IsNotSupplyInDeal()
        {
            foreach(Supply item in DGridSupplies.SelectedItems)
            {
                if(item.Deal.Count != 0)
                {
                    return false;
                }
            }
            return true;
        }
    }
}
