using RealEstateAgency.Data;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
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
            if(MessageBox.Show("Пересоздать БД?", "Внимание", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            { 
                Database.SetInitializer(new DropCreateDatabaseAlways<AgencyModel>());
            }
            ImportEstles(@"D:\dev\RealEstateAgency\TaskInfo\Resources\Session 2");
        }

        private void ImportEstles(string directoryPath)
        {
            ImportFlats(directoryPath);
            ImportHouses(directoryPath);
            ImportLands(directoryPath);
        }

        private void ImportFlats(string directoryPath)
        {
            var flatFile = new StreamReader(directoryPath + @"/apartments.csv");

            while(!flatFile.EndOfStream)
            {
                var floatRow = flatFile.ReadLine().Split(';');
                var flatImport = new Flat();
                flatImport.SupplyId = Convert.ToInt32(floatRow[0]);
                flatImport.City = floatRow[1];
                flatImport.Street = floatRow[2];
                flatImport.HouseNum = Convert.ToInt32(floatRow[3]);
                flatImport.FlatNum = Convert.ToInt32(floatRow[4]);
                flatImport.CoordinateLatitude = Convert.ToInt32(floatRow[5]);
                flatImport.CoordinateLongitude = Convert.ToInt32(floatRow[6]);
                flatImport.Area = Convert.ToSingle(floatRow[7]);
                flatImport.RoomCount = Convert.ToInt32(floatRow[8]);
                flatImport.Floor = Convert.ToInt32(floatRow[9]);
            }

            flatFile.Dispose();
        }

        private void ImportHouses(string directoryPath)
        {

        }
        private void ImportLands(string directoryPath)
        {

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
