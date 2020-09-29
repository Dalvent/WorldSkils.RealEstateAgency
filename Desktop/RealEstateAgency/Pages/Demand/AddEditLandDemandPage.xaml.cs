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
    /// Interaction logic for AddDemandLandPage.xaml
    /// </summary>
    public partial class AddEditLandDemandPage : Page
    {
        private readonly AddEditEntity<LandPlotFilter> _addEditLandPlotFilter;

        /// <summary>
        /// Редактирование выбранной сущности.
        /// </summary>
        /// <param name="editLandPlotFilter">В случае равентсва null страница переходет в режим создания.</param>
        public AddEditLandDemandPage(LandPlotFilter editLandPlotFilter = null)
        {
            InitializeComponent();


            UserErrorCheack[] userErrorCheacks = {
            };
            _addEditLandPlotFilter = new AddEditEntity<LandPlotFilter>(editLandPlotFilter, userErrorCheacks);
            _addEditLandPlotFilter.SuccsessSaved += (sender, e) =>
            {
                MessageBox.Show("Информация сохранена", "Успешно.", MessageBoxButton.OK, MessageBoxImage.Information);
                FrameManager.GoBack();
            };

            ClientInput.ItemsSource = AgencyModel.Instance.Client.ToList();
            RealtorInput.ItemsSource = AgencyModel.Instance.Realtor.ToList();

            if(editLandPlotFilter == null)
            {
                _addEditLandPlotFilter.EditEntity.Demand = new Demand();
            }

            DataContext = _addEditLandPlotFilter.EditEntity;
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                _addEditLandPlotFilter.Save();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
