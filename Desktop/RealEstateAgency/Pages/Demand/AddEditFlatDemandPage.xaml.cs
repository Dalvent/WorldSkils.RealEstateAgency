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
    /// Interaction logic for AddEditFlatDemandPage.xaml
    /// </summary>
    public partial class AddEditFlatDemandPage : Page
    {
        private readonly AddEditEntity<FlatFilter> _addEditFlatFilter;

        /// <summary>
        /// Редактирование выбранной сущности.
        /// </summary>
        /// <param name="editFlatFilter">В случае равентсва null страница переходет в режим создания.</param>
        public AddEditFlatDemandPage(FlatFilter editFlatFilter = null)
        {
            InitializeComponent();

            UserErrorCheack[] userErrorCheacks = {
            };
            _addEditFlatFilter = new AddEditEntity<FlatFilter>(editFlatFilter, userErrorCheacks);
            _addEditFlatFilter.SuccsessSaved += (sender, e) =>
            {
                MessageBox.Show("Информация сохранена", "Успешно.", MessageBoxButton.OK, MessageBoxImage.Information);
                FrameManager.GoBack();
            };

            ClientInput.ItemsSource = AgencyModel.Instance.Client.ToList();
            RealtorInput.ItemsSource = AgencyModel.Instance.Realtor.ToList();

            DataContext = _addEditFlatFilter.EditEntity;
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                _addEditFlatFilter.Save();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
