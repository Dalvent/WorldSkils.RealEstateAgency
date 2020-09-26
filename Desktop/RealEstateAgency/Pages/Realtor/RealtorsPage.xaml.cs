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
    /// Interaction logic for RealtorsPage.xaml
    /// </summary>
    public partial class RealtorsPage
    {
        private readonly DGridEntityManager<Realtor> manager;
        private readonly LevenshteinPersonFilter levenshteinFilter;
        public RealtorsPage()
        {
            InitializeComponent();

            levenshteinFilter = new LevenshteinPersonFilter(3);
            manager = new DGridEntityManager<Realtor>(DGridRealtors);
        }

        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
            FrameManager.Navigate(new AddEditRealtorPage(((Button)sender).DataContext as Realtor));
        }

        private void RemoveButton_Click(object sender, RoutedEventArgs e)
        {
            manager.RemoveSelected();

        }
        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            FrameManager.Navigate(new AddEditRealtorPage());
        }
        private bool _isFirstVisibleChanged = true;
        /// <summary>
        /// Необходим для обновления таблицы при возрате на страницу.
        /// _isFirstVisibleChanged - необходима для чтобы не было обновления при инициализации.
        /// </summary>
        private void Page_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if(_isFirstVisibleChanged)
            {
                _isFirstVisibleChanged = false;
                return;
            }

            if((bool)e.NewValue == true)
            {
                manager.ReloadTable();
            }
        }

        private void FilterButton_Click(object sender, RoutedEventArgs e)
        {
            manager.UseFilter("LevenstainPersonFilter", levenshteinFilter, FilterTextBox.Text);
        }
    }
}
