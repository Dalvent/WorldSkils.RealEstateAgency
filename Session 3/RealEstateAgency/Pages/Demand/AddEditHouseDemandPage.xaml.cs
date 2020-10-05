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
    /// Interaction logic for AddEditHouseDemandPage.xaml
    /// </summary>
    public partial class AddEditHouseDemandPage : Page
    {
        private readonly AddEditEntity<HouseFilter> _addEditHouseFilter;

        /// <summary>
        /// Редактирование выбранной сущности.
        /// </summary>
        /// <param name="editHouseDemand">В случае равентсва null страница переходет в режим создания.</param>
        public AddEditHouseDemandPage(HouseFilter editHouseFilter = null)
        {
            InitializeComponent();

            UserErrorCheack[] userErrorCheacks = {
            };
            _addEditHouseFilter = new AddEditEntity<HouseFilter>(editHouseFilter, userErrorCheacks);
            _addEditHouseFilter.SuccsessSaved += (sender, e) =>
            {
                MessageBox.Show("Информация сохранена", "Успешно.", MessageBoxButton.OK, MessageBoxImage.Information);
                FrameManager.GoBack();
            };

            ClientComboBox.ItemsSource = AgencyModel.Instance.Client.ToList();
            RealtorComboBox.ItemsSource = AgencyModel.Instance.Realtor.ToList();

            DataContext = _addEditHouseFilter.EditEntity;
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                _addEditHouseFilter.Save();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
