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
    /// Interaction logic for AddEditSupplyPage.xaml
    /// </summary>
    public partial class AddEditSupplyPage : Page
    {
        private readonly AddEditEntity<Supply> _addEditSupply;

        /// <summary>
        /// Редактирование выбранной сущности.
        /// </summary>
        /// <param name="editRaltor">В случае равентсва null страница переходет в режим создания.</param>
        public AddEditSupplyPage(Supply editRaltor = null)
        {
            InitializeComponent();
           
            _addEditSupply = new AddEditEntity<Supply>(editRaltor);
            _addEditSupply.SuccsessSaved += (sender, e) =>
            {
                MessageBox.Show("Информация сохранена", "Успешно.", MessageBoxButton.OK, MessageBoxImage.Information);
                FrameManager.GoBack();
            };
            ClientInput.ItemsSource = AgencyModel.Instance.Client.ToList();
            RealtorInput.ItemsSource = AgencyModel.Instance.Realtor.ToList();
            EstateInput.ItemsSource = AgencyModel.Instance.Estate.ToList();
            DataContext = _addEditSupply.EditEntity;
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                _addEditSupply.Save();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
