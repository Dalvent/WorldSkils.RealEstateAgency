using RealEstateAgency.Data;
using System;
using System.CodeDom;
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
            //Database.SetInitializer(new DropCreateDatabaseAlways<AgencyModel>());
            //ImportData(@"..\..\Resources\Data");
            //AgencyModel.Instance.SaveChanges();
            ResurceData.Load(@"..\..\Resources");
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

        /*private void ImportData(string directoryPath)
        {
            ImportClients(directoryPath);
            ImportRealtors(directoryPath);
            ImportFlats(directoryPath);
            ImportHouses(directoryPath);
            ImportLands(directoryPath);
        }
        private void ImportClients(string directoryPath)
        {
            var clientFile = new StreamReader(directoryPath + @"/clients.txt", Encoding.UTF8);
            clientFile.ReadLine();
            while(!clientFile.EndOfStream)
            {
                // Id;Phone;Email;FirstName;LastName;MiddleName
                var clientRow = clientFile.ReadLine().Split(';');
                var clientImport = new Client();
                clientImport.Id = Convert.ToInt32(clientRow[0]);
                clientImport.Phone = clientRow[1] != String.Empty ? clientRow[1] : null;
                clientImport.Email = clientRow[2] != String.Empty ? clientRow[2] : null; 
                clientImport.FirstName = clientRow[3];
                clientImport.LastName = clientRow[4];
                clientImport.MiddleName = clientRow[5];

                AgencyModel.Instance.Client.Add(clientImport);
            }

            clientFile.Dispose();
        }
        private void ImportRealtors(string directoryPath)
        {
            var realtorFile = new StreamReader(directoryPath + @"/agents.txt", Encoding.UTF8);
            realtorFile.ReadLine();
            while(!realtorFile.EndOfStream)
            {
                // Id;DealShare;FirstName;LastName;MiddleName
                var realtorRow = realtorFile.ReadLine().Split(';');
                var realtorImport = new Realtor();
                realtorImport.Id = Convert.ToInt32(realtorRow[0]);
                realtorImport.DealShare = Convert.ToDouble(realtorRow[1]);
                realtorImport.FirstName = realtorRow[2];
                realtorImport.LastName = realtorRow[3];
                realtorImport.MiddleName = realtorRow[4];

                AgencyModel.Instance.Realtor.Add(realtorImport);
            }

            realtorFile.Dispose();
        }
        private void ImportFlats(string directoryPath)
        {
            var flatFile = new StreamReader(directoryPath + @"/apartments.txt", Encoding.UTF8);
            flatFile.ReadLine();
            while(!flatFile.EndOfStream)
            {
                var flatRow = flatFile.ReadLine().Split(';');
                var flatImport = new Flat();
                flatImport.SupplyId = Convert.ToInt32(flatRow[0]);
                flatImport.City = flatRow[1];
                flatImport.Street = flatRow[2];
                flatImport.HouseNum = Convert.ToInt32(flatRow[3]);
                flatImport.FlatNum = Convert.ToInt32(flatRow[4]);
                flatImport.CoordinateLatitude = Convert.ToInt32(flatRow[5]);
                flatImport.CoordinateLongitude = Convert.ToInt32(flatRow[6]);
                flatImport.Area = Convert.ToSingle(flatRow[7]);
                flatImport.RoomCount = Convert.ToInt32(flatRow[8]);
                flatImport.Floor = Convert.ToInt32(flatRow[9]);

                AgencyModel.Instance.Flat.Add(flatImport);
            }

            flatFile.Dispose();
        }
        private void ImportHouses(string directoryPath)
        {
            var houseFile = new StreamReader(directoryPath + @"/houses.txt", Encoding.UTF8);
            houseFile.ReadLine();

            while(!houseFile.EndOfStream)
            {
                var floatRow = houseFile.ReadLine().Split(';');
                var houseImport = new House();
                houseImport.SupplyId = Convert.ToInt32(floatRow[0]);
                houseImport.City = floatRow[1];
                houseImport.Street = floatRow[2];
                if(floatRow[3] != "")
                { 
                    houseImport.HouseNum = Convert.ToInt32(floatRow[3]);
                }    
                else
                {
                    houseImport.HouseNum = null;
                }
                houseImport.CoordinateLatitude = Convert.ToInt32(floatRow[5]);
                houseImport.CoordinateLongitude = Convert.ToInt32(floatRow[6]);
                houseImport.FloorCount = Convert.ToInt32(floatRow[7]);
                houseImport.Area = Convert.ToSingle(floatRow[8]);

                AgencyModel.Instance.House.Add(houseImport);
            }

            houseFile.Dispose();
        }
        private void ImportLands(string directoryPath)
        {
            var landFile = new StreamReader(directoryPath + @"/lands.txt", Encoding.UTF8);
            landFile.ReadLine();

            while(!landFile.EndOfStream)
            {
                var floatRow = landFile.ReadLine().Split(';');
                var landImport = new LandPlot();
                landImport.SupplyId = Convert.ToInt32(floatRow[0]);
                landImport.City = floatRow[1];
                landImport.Street = floatRow[2];
                landImport.CoordinateLatitude = Convert.ToInt32(floatRow[5]);
                landImport.CoordinateLongitude = Convert.ToInt32(floatRow[6]);
                landImport.Area = Convert.ToSingle(floatRow[7]);

                AgencyModel.Instance.LandPlot.Add(landImport);
            }

            landFile.Dispose();
        }/*/**/
    }
}
