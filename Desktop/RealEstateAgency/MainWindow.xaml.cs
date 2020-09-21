using RealEstateAgency.Data.EF;
using System;
using System.Collections.Generic;
using System.Data.Entity;
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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            FrameManager.Init(MainFrame);
            FrameManager.Navigate(new NavigationPage());
            Database.SetInitializer(new DropCreateDatabaseAlways<RealEstateAgencyEntities>());
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            FrameManager.GoBack();
        }

        private void MainFrame_Navigated(object sender, NavigationEventArgs e)
        {
            // Устанавливает видимость кнопки возрата в зависимости можно ли вернуться.
            // Вызывается при каждой навигации.
            if(MainFrame.CanGoBack)
            {
                BackButton.Visibility = Visibility.Visible;
            }
            else
            {
                BackButton.Visibility = Visibility.Hidden;
            }
        }
    }
}
