using RealEstateAgency.Data;
using System;
using System.Windows;
using System.Windows.Controls;

namespace RealEstateAgency
{
    /// <summary>
    /// Interaction logic for AddEditClientPage.xaml
    /// </summary>
    public partial class AddEditClientPage : Page
    {
        private readonly AddEditEntity<Client> _addEditClient;

        /// <summary>
        /// Редактирование выбранной сущности.
        /// </summary>
        /// <param name="editClient">В случае равентсва null страница переходет в режим создания.</param>
        public AddEditClientPage(Client editClient = null)
        {
            InitializeComponent();
            
            UserErrorCheack[] userErrorCheacks = {
                new UserErrorCheack("Email или Телефон должны быть указаны", IsPhoneOrEmailWritten)
            };
            _addEditClient = new AddEditEntity<Client>(editClient, userErrorCheacks);
            _addEditClient.SuccsessSaved += (sender, e) =>
            {
                MessageBox.Show("Информация сохранена", "Успешно.", MessageBoxButton.OK, MessageBoxImage.Information);
                FrameManager.GoBack();
            };

            DataContext = _addEditClient.EditEntity;
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                _addEditClient.Save();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        /// <summary>
        /// </summary>
        /// <returns>Написан ли телефон или email.</returns>
        private bool IsPhoneOrEmailWritten()
        {
            return !(string.IsNullOrWhiteSpace(PhoneTextBox.Text) &&
                string.IsNullOrWhiteSpace(EmailTextBox.Text));
        }
    }
}
