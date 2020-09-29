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
    /// Interaction logic for DemandsPage.xaml
    /// </summary>
    public partial class DemandsPage : Page
    {
        private readonly DGridEntityManager<Demand> manager;
        public DemandsPage()
        {
            InitializeComponent();

            UserErrorCheack[] userErrors = {
                new UserErrorCheack("Запрещено удаление потребностей, участвующего в сделке.", IsNotSupplyInDeal)
            };
            manager = new DGridEntityManager<Demand>(DGridDemands, userErrors);
        }

        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
            var deamandForEdit = ((Button)sender).DataContext as Demand;
            var filterForEdit = deamandForEdit.Filter;

            switch(deamandForEdit.Filter.EstleType)
            {
            case EstleType.Flat:
                FrameManager.Navigate(new AddEditFlatDemandPage((FlatFilter)filterForEdit));
                break;
            case EstleType.House:
                FrameManager.Navigate(new AddEditHouseDemandPage((HouseFilter)filterForEdit));
                break;
            case EstleType.LandPlot:
                FrameManager.Navigate(new AddEditLandDemandPage((LandPlotFilter)filterForEdit));
                break;
            }
        }

        private void RemoveButton_Click(object sender, RoutedEventArgs e)
        {
            manager.RemoveSelected();
        }
        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            FrameManager.Navigate(new AddDemandTypeChoosePage());
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
            foreach(Demand item in DGridDemands.SelectedItems)
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
