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
    /// Interaction logic for AddEditDealPage.xaml
    /// </summary>
    public partial class AddEditDealPage : Page
    {
        private readonly AddEditEntity<Deal> _addEditDeal;

        /// <summary>
        /// Редактирование выбранной сущности.
        /// </summary>
        /// <param name="editDeal">В случае равентсва null страница переходет в режим создания.</param>
        public AddEditDealPage(Deal editDeal = null)
        {
            InitializeComponent();

            if(editDeal == null)
            {
                SupplyComboBox.ItemsSource = AgencyModel.Instance.Supply
                    .Where(item => item.Deal.Count == 0)
                    .ToList();
                DemandComboBox.ItemsSource = AgencyModel.Instance.Demand
                    .Where(item => item.Deal.Count == 0)
                    .ToList();
            }
            else
            {
                SupplyComboBox.IsReadOnly = true;
                SupplyComboBox.ItemsSource = new Supply[] { editDeal.Supply };
                DemandComboBox.IsReadOnly = true;
                DemandComboBox.ItemsSource = new Demand[] { editDeal.Demand };
            }

            _addEditDeal = new AddEditEntity<Deal>(editDeal);
            _addEditDeal.SuccsessSaved += (sender, e) =>
            {
                MessageBox.Show("Информация сохранена", "Успешно.", MessageBoxButton.OK, MessageBoxImage.Information);
                FrameManager.GoBack();
            };

            DataContext = _addEditDeal.EditEntity; 
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                _addEditDeal.Save();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void FillCommissionTextBoxes()
        {
            var commission = _addEditDeal.EditEntity.CalculateCommission();
            SupplinderCommisionTextBox.Text = commission.SupplinderCommision.ToString();
            DemanderCommisionTextBox.Text = commission.DemanderCommision.ToString();
            SupplinderRealtorCommisionTextBox.Text = commission.SupplinderRealtorCommision.ToString();
            DemanderRealtorCommisionTextBox.Text = commission.DemanderRealtorCommision.ToString();
            ComponyCommisionTextBox.Text = commission.ComponyCommision.ToString();
        }

        private void SupplyComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(DemandComboBox.SelectedItem != null)
            {
                FillCommissionTextBoxes();
            }
        }

        private void DemandComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(SupplyComboBox.SelectedItem != null)
            {
                FillCommissionTextBoxes();
            }
        }
    }
}
