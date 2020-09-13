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
    /// Interaction logic for AddEditRealtorPage.xaml
    /// </summary>
    public partial class AddEditRealtorPage
    {
        private Realtor _editEntity;
        private AddEditPageOperation _currentOperation;
        /// <summary>
        /// Редактирование выбранной сущности.
        /// </summary>
        /// <param name="editClient">В случае равентсва null страница переходет в режим создания.</param>
        public AddEditRealtorPage(Realtor editRealtor = null)
        {
            InitializeComponent();
            if (editRealtor == null)
            {
                _editEntity = new Realtor();
                _currentOperation = AddEditPageOperation.Add;
            }
            else
            {
                _editEntity = editRealtor;
                _currentOperation = AddEditPageOperation.Edit;
            }
            DataContext = _editEntity;
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            var errors = new ErrorBuilder();

            errors.AssertError(!IsFullNameWritten(),
                "Риелтор обязан иметь полное имя!");
            errors.AssertError(!IsDealShareTextNormalizedPersent(), 
                "Коммисия обязана быть от 0 до 100!");
            if (errors.IsAnyError())
            {
                MessageBox.Show(errors.GetMessage(), "Ошибка",
                    MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }


            if (_currentOperation == AddEditPageOperation.Add)
            {
                RealEstateAgencyEntities.Instance.Realtor.Add(_editEntity);
            }

            try
            {
                RealEstateAgencyEntities.Instance.SaveChanges();
                MessageBox.Show("Информация сохранена");
                FrameManager.GoBack();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка сохранения",
                   MessageBoxButton.OK, MessageBoxImage.Error);
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
            if (!Single.TryParse(DealShareTextBox.Text, out float dealShareNum))
            {
                return false;
            }

            if (dealShareNum < 0 || dealShareNum > 100)
            {
                return false;
            }

            return true;
        }

    }
}
