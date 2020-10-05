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
    /// Interaction logic for AddEditHousePage.xaml
    /// </summary>
    public partial class AddEditHousePage : Page
    {
        private readonly AddEditEntity<House> _addEditHouse;

        /// <summary>
        /// Редактирование выбранной сущности.
        /// </summary>
        /// <param name="editHouse">В случае равентсва null страница переходет в режим создания.</param>
        public AddEditHousePage(House editHouse = null)
        {
            InitializeComponent();

            UserErrorCheack[] userErrorCheacks = {
                new UserErrorCheack("Цена должна быть указана.", IsPriceWritten),
                new UserErrorCheack("Широта должна быть в промежутке от -90 до 90.", IsLatitudeInInterval),
                new UserErrorCheack("Широта должна быть в промежутке от -180 до 180", IsLongitudeInInterval)
            };
            _addEditHouse = new AddEditEntity<House>(editHouse, userErrorCheacks);
            _addEditHouse.SuccsessSaved += (sender, e) =>
            {
                MessageBox.Show("Информация сохранена", "Успешно.", MessageBoxButton.OK, MessageBoxImage.Information);
                FrameManager.GoBack();
            };

            DataContext = _addEditHouse.EditEntity;
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                _addEditHouse.Save();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private bool IsPriceWritten()
        {
            return !String.IsNullOrEmpty(PriceTextBox.Text);
        }
        private bool IsLatitudeInInterval()
        {
            if(!Single.TryParse(CoordinateLatitudeTextBox.Text, out float num))
            {
                return false;
            }

            if(num < -90 || num > 90)
            {
                return false;
            }

            return true;
        }
        private bool IsLongitudeInInterval()
        {
            if(!Single.TryParse(CoordinateLongitudeTextBox.Text, out float num))
            {
                return false;
            }

            if(num < -180 || num > 180)
            {
                return false;
            }

            return true;
        }
    }
}
