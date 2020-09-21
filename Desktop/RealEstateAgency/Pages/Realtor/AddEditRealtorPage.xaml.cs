using RealEstateAgency.Data.EF;
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
    /// Interaction logic for AddEditRealtorPage.xaml
    /// </summary>
    public partial class AddEditRealtorPage
    {
        private readonly AddEditEntity<Realtor> _addEditRealtor;

        /// <summary>
        /// Редактирование выбранной сущности.
        /// </summary>
        /// <param name="editRaltor">В случае равентсва null страница переходет в режим создания.</param>
        public AddEditRealtorPage(Realtor editRaltor = null)
        {
            InitializeComponent();

            UserErrorCheack[] userErrorCheacks = {
                new UserErrorCheack("Вы должны написать ФИО", IsFullNameWritten),
                new UserErrorCheack("Вы должны указать коммисию в виде числа от 0 до 100", IsDealShareTextNormalizedPersent)
            };
            _addEditRealtor = new AddEditEntity<Realtor>(editRaltor, userErrorCheacks);
            _addEditRealtor.SuccsessSaved += (sender, e) =>
            {
                MessageBox.Show("Информация сохранена", "Успешно.", MessageBoxButton.OK, MessageBoxImage.Information);
                FrameManager.GoBack();
            };
            DataContext = _addEditRealtor.EditEntity;
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                _addEditRealtor.Save();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        /// <summary>
        /// Написаны ли ФИО.
        /// </summary>
        /// <returns></returns>
        private bool IsFullNameWritten()
        {
            return !(String.IsNullOrWhiteSpace(FirstNameTextBox.Text) ||
                String.IsNullOrWhiteSpace(LastNameTextBox.Text) ||
                String.IsNullOrWhiteSpace(MiddleNameTextBox.Text));
        }

        /// <summary>
        /// Является ли текст коммиссии числом от 0 до 100.
        /// </summary>
        /// <returns></returns>
        private bool IsDealShareTextNormalizedPersent()
        {
            if(!Single.TryParse(DealShareTextBox.Text, out float dealShareNum))
            {
                return false;
            }

            if(dealShareNum < 0 || dealShareNum > 100)
            {
                return false;
            }

            return true;
        }

    }
}
