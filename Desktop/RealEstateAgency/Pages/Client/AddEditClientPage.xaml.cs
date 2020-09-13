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

namespace RealEstateAgency
{
    /// <summary>
    /// Interaction logic for AddEditClientPage.xaml
    /// </summary>
    public partial class AddEditClientPage : Page
    {
        private Client _editEntity;
        private AddEditPageOperation _currentOperation;
        
        /// <summary>
        /// Редактирование выбранной сущности.
        /// </summary>
        /// <param name="editClient">В случае равентсва null страница переходет в режим создания.</param>
        public AddEditClientPage(Client editClient = null)
        {
            InitializeComponent();
            if(editClient == null)
            {
                _editEntity = new Client();
                _currentOperation = AddEditPageOperation.Add;
            }
            else
            {
                _editEntity = editClient;
                _currentOperation = AddEditPageOperation.Edit;
            }
            DataContext = _editEntity;
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            var errors = new ErrorBuilder();
            errors.AssertError(IsPhoneOrEmailWritten(), "Email или Телефон должны быть указаны");
            if(errors.IsAnyError())
            {
                MessageBox.Show(errors.GetMessage(), "Ошибка",
                    MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (string.IsNullOrWhiteSpace(_editEntity.Phone))
                _editEntity.Phone = null;
            if (string.IsNullOrWhiteSpace(_editEntity.Email))
                _editEntity.Email = null;

            if (_currentOperation == AddEditPageOperation.Add)
            {
                RealEstateAgencyEntities.Instance.Client.Add(_editEntity);
            }

            try
            {
                RealEstateAgencyEntities.Instance.SaveChanges();
                MessageBox.Show("Информация сохранена");
                FrameManager.GoBack();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка сохранения",
                   MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private bool IsPhoneOrEmailWritten()
        {
            return !(string.IsNullOrWhiteSpace(PhoneTextBox.Text) &&
                string.IsNullOrWhiteSpace(EmailTextBox.Text));
        }
    }
}
