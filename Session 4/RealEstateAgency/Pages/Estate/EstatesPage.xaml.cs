using RealEstateAgency.Core;
using RealEstateAgency.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
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
        
        private readonly EqualsFilter<Estate> typeEqualsFilter;
        
        private readonly EqualsFilter<Estate> cityEqualsFilter;
        private readonly EqualsFilter<Estate> streetEqualsFilter;
        private readonly EqualsFilter<Estate> houseNumEqualsFilter;
        private readonly EqualsFilter<Estate> flatNumEqualsFilter;

        private readonly LevenshteinFieldFilter<Estate> cityLevenshteinFieldFilter;
        private readonly LevenshteinFieldFilter<Estate> streetLevenshteinFieldFilter;
        private readonly LevenshteinFieldFilter<Estate> houseLevenshteinFieldFilter;
        private readonly LevenshteinFieldFilter<Estate> flatLevenshteinFieldFilter;

        private readonly RegionFilter regionFilter;

        public EstatesPage()
        {
            InitializeComponent();

            UserErrorCheack[] userErrorCheacks = {
                new UserErrorCheack("Невозможно удалить недвижимость связанную с предложением!", IsEveryChooseForRemoveEstlesHaveNoSupply)
            };
            manager = new DGridEntityManager<Estate>(DGridEstates, userErrorCheacks);

            typeEqualsFilter = new EqualsFilter<Estate>(item => item.TypeName);
            cityEqualsFilter = new EqualsFilter<Estate>(item => item.City);
            streetEqualsFilter = new EqualsFilter<Estate>(item => item.Street);
            houseNumEqualsFilter = new EqualsFilter<Estate>(item => item.HouseNum.ToString());
            flatNumEqualsFilter = new EqualsFilter<Estate>(item => item.FlatNum.ToString());

            cityLevenshteinFieldFilter = new LevenshteinFieldFilter<Estate>(3, item => item.City);
            streetLevenshteinFieldFilter = new LevenshteinFieldFilter<Estate>(3, item => item.Street);
            houseLevenshteinFieldFilter = new LevenshteinFieldFilter<Estate>(1, item => item.HouseNum.ToString());
            flatLevenshteinFieldFilter = new LevenshteinFieldFilter<Estate>(1, item => item.FlatNum.ToString());

            regionFilter = new RegionFilter(ResurceData.Regions);

            TypeAndAdressFilterComboBoxInit();
            RegionComboBoxInit();
        }
        private void TypeAndAdressFilterComboBoxInit()
        {
            var allEstles = manager.AllEntities;

            TypeComboBox.ItemsSource = allEstles
                .Select(estle => estle.TypeName)
                .Distinct();

            CityComboBox.ItemsSource = allEstles
                .Select(estle => estle.City)
                .Distinct();

            StreetComboBox.ItemsSource = allEstles
                .Select(estle => estle.Street)
                .Distinct();

            HouseNumComboBox.ItemsSource = allEstles
                .Select(estle => estle.HouseNum)
                .Distinct();

            FlatNumComboBox.ItemsSource = allEstles
                .Select(estle => estle.FlatNum)
                .Distinct();
        }
        private void RegionComboBoxInit()
        {
            ReginonComboBox.ItemsSource = ResurceData.Regions.Select(item => item.Name);
        }

        private void ClearFilterComboBoxes()
        {
            TypeComboBox.SelectedIndex = -1;
            CityComboBox.SelectedIndex = -1;
            StreetComboBox.SelectedIndex = -1;
            HouseNumComboBox.SelectedIndex = -1;
            FlatNumComboBox.SelectedIndex = -1;
            ReginonComboBox.SelectedIndex = -1;
        }
        private void ClearSearchTextBoxes()
        {
            CitySearchTextBox.Text = String.Empty;
            StreetSearchTextBox.Text = String.Empty;
            HouseNumSearchTextBox.Text = String.Empty;
            FlatNumSearchTextBox.Text = String.Empty;
        }
        /// <summary>
        /// Добавляет фильтр, если выбран элемент ComboBox, не явялющийся null.
        /// </summary>
        private void UseSelectedFilteringIfNotEmpty(ComboBox comboBox, string filterName, ICollectionFilter filter)
        {
            if(comboBox.SelectedItem != null)
                manager.UseFilter(filterName, filter, comboBox.SelectedItem.ToString());
        }

        /// <summary>
        /// Использут фильтр если TextBox не пуст.
        /// В случае если пуст удаляет фильтр из списка используемых, в случае если он использовался.
        /// </summary>
        /// <param name="textBox"></param>
        /// <param name="filterName"></param>
        /// <param name="filter"></param>
        private void UseSelectedFilteringIfNotEmpty(TextBox textBox, string filterName, ICollectionFilter filter)
        {
            if(!String.IsNullOrEmpty(textBox.Text))
            {
                manager.UseFilter(filterName, filter, textBox.Text);
            }
            else
            {
                if(manager.IsFilterUsing(filterName))
                {
                    manager.RemoveFilter(filterName);
                }
            }
        }

        #region UI Events 
        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
            var editEstate = ((Button)sender).DataContext as Estate;

            if(editEstate is Flat)
            {
                FrameManager.Navigate(new AddEditFlatPage(editEstate as Flat));
            }
            else if(editEstate is House)
            {
                FrameManager.Navigate(new AddEditHousePage(editEstate as House));
            }
            else if(editEstate is LandPlot)
            {
                FrameManager.Navigate(new AddEditLandPlotPage(editEstate as LandPlot));
            }
            else
            {
                throw new TypeAccessException("Unown estate type.");
            }
        }
        private void RemoveButton_Click(object sender, RoutedEventArgs e)
        {
            manager.RemoveSelected();
        }
        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            FrameManager.Navigate(new AddEstleTypeChoosePage());
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
                TypeAndAdressFilterComboBoxInit();
            }
        }
        private void TypeComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UseSelectedFilteringIfNotEmpty((ComboBox)sender, "TypeEqualsFilter", typeEqualsFilter);
        }
        private void CityComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UseSelectedFilteringIfNotEmpty((ComboBox)sender, "CityEqualsFilter", cityEqualsFilter);
        }
        private void StreetComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UseSelectedFilteringIfNotEmpty((ComboBox)sender, "StreetEqualsFilter", streetEqualsFilter);
        }
        private void HouseNumComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UseSelectedFilteringIfNotEmpty((ComboBox)sender, "HouseEqualsFilter", houseNumEqualsFilter);
        }
        private void FlatNumComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UseSelectedFilteringIfNotEmpty((ComboBox)sender, "FlatEqualsFilter", flatNumEqualsFilter);
        }
        private void SearchButton_Click(object sender, RoutedEventArgs e)
        {
            UseSelectedFilteringIfNotEmpty(CitySearchTextBox, "cityLevenshteinFieldFilter", cityLevenshteinFieldFilter);
            UseSelectedFilteringIfNotEmpty(StreetSearchTextBox, "streetLevenshteinFieldFilter", streetLevenshteinFieldFilter);
            UseSelectedFilteringIfNotEmpty(HouseNumSearchTextBox, "houseLevenshteinFieldFilter", houseLevenshteinFieldFilter);
            UseSelectedFilteringIfNotEmpty(FlatNumSearchTextBox, "flatLevenshteinFieldFilter", flatLevenshteinFieldFilter);
        }
        private void ClearFiltersButton_Click(object sender, RoutedEventArgs e)
        {
            ClearFilterComboBoxes();
            ClearSearchTextBoxes();
            manager.ClearFilters();
        }
        private void ReginonComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(ReginonComboBox.SelectedIndex == -1) return;
            manager.UseFilter("regionFilter", regionFilter, ReginonComboBox.SelectedItem.ToString());
        }
        #endregion
        #region Errors cheack metods.
        private bool IsEveryChooseForRemoveEstlesHaveNoSupply()
        {
            foreach(Estate selectedEstle in manager.DisplayedEntities)
            {
                if(selectedEstle.Supplies.Count != 0)
                {
                    return false;
                }
            }
            return true;
        }
        #endregion
    }
}