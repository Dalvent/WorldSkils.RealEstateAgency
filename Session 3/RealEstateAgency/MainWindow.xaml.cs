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
            ResurceData.Load(@"..\..\Resources");
            //if(MessageBox.Show("Пересоздать базу данных?", "Да/Нет", MessageBoxButton.YesNo, MessageBoxImage.Question)
            //    == MessageBoxResult.Yes)
            //{
            //    Database.SetInitializer(new DropCreateDatabaseAlways<AgencyModel>());
            //    ImportData(@"..\..\Resources\Data");
            //    AgencyModel.Instance.SaveChanges();
            //}
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

        /* private void ImportData(string directoryPath)
        {
            ImportClients(directoryPath);
            ImportRealtors(directoryPath);
            ImportFlats(directoryPath);
            ImportHouses(directoryPath);
            ImportLands(directoryPath);
            ImportSupplies(directoryPath);
            ImportDemandFlat(directoryPath);
            ImportDemandHouse(directoryPath);
            ImportDemandLand(directoryPath);
        }

        private void ImportDemandFlat(string directoryPath)
        {
            var demandFlatFile = new StreamReader(directoryPath + @"/apartment-demands.txt", Encoding.UTF8);
            demandFlatFile.ReadLine();
            while(!demandFlatFile.EndOfStream)
            {
                // Id,Address_City,Address_Street,Address_House,Address_Number,
                //MinPrice,MaxPrice,AgentId,ClientId,
                //MinArea,MaxArea,MinRooms,MaxRooms,MinFloor,MaxFloor
                var demandFlatRow = demandFlatFile.ReadLine().Split(';');
                var demandImport = new Demand();
                var demandFlatFilter = new FlatFilter();
                int index = -1;
                demandImport.Id = Convert.ToInt32(demandFlatRow[++index]);
                demandFlatFilter.DemandId = Convert.ToInt32(demandFlatRow[index]);
                demandFlatFilter.City = demandFlatRow[++index] != String.Empty ? demandFlatRow[index] : null;
                demandFlatFilter.Street = demandFlatRow[++index] != String.Empty ? demandFlatRow[index] : null;
                demandFlatFilter.HouseNum = demandFlatRow[++index] != String.Empty ? Convert.ToInt32(demandFlatRow[index]) : new Nullable<int>();
                demandFlatFilter.FlatNum = demandFlatRow[++index] != String.Empty ? Convert.ToInt32(demandFlatRow[index]) : new Nullable<int>();
                demandFlatFilter.MinPrice = demandFlatRow[++index] != String.Empty ? Convert.ToDecimal(demandFlatRow[index]) : new Nullable<decimal>();
                demandFlatFilter.MaxPrice = demandFlatRow[++index] != String.Empty ? Convert.ToDecimal(demandFlatRow[index]) : new Nullable<decimal>();
                demandImport.RealtorId = Convert.ToInt32(demandFlatRow[++index]);
                demandImport.ClientId = Convert.ToInt32(demandFlatRow[++index]);
                demandFlatFilter.MinArea = demandFlatRow[++index] != String.Empty ? Convert.ToDouble(demandFlatRow[index]) : new Nullable<double>();
                demandFlatFilter.MaxArea = demandFlatRow[++index] != String.Empty ? Convert.ToDouble(demandFlatRow[index]) : new Nullable<double>();
                demandFlatFilter.MinRoomCount = demandFlatRow[++index] != String.Empty ? Convert.ToInt32(demandFlatRow[index]) : new Nullable<int>();
                demandFlatFilter.MaxRoomCount = demandFlatRow[++index] != String.Empty ? Convert.ToInt32(demandFlatRow[index]) : new Nullable<int>();
                demandFlatFilter.MinFloor = demandFlatRow[++index] != String.Empty ? Convert.ToInt32(demandFlatRow[index]) : new Nullable<int>();
                demandFlatFilter.MaxFloor = demandFlatRow[++index] != String.Empty ? Convert.ToInt32(demandFlatRow[index]) : new Nullable<int>();

                AgencyModel.Instance.Demand.Add(demandImport);
                AgencyModel.Instance.FlatFilter.Add(demandFlatFilter);
            }

            demandFlatFile.Dispose();
        }
        private void ImportDemandHouse(string directoryPath)
        {
            var demandHouseFile = new StreamReader(directoryPath + @"/house-demands.txt", Encoding.UTF8);
            demandHouseFile.ReadLine();
            while(!demandHouseFile.EndOfStream)
            {
                // Id,Address_City,Address_Street,Address_House,Address_Number,
                // MinPrice,MaxPrice,AgentId,ClientId,
                // MinFloors,MaxFloors,MinArea,MaxArea,MinRooms,MaxRooms
                var demandHouseRow = demandHouseFile.ReadLine().Split(';');
                var demandImport = new Demand();
                var demandHouseFilter = new HouseFilter();
                int index = -1;
                demandImport.Id = Convert.ToInt32(demandHouseRow[++index]);
                demandHouseFilter.DemandId = Convert.ToInt32(demandHouseRow[index]);
                demandHouseFilter.City = demandHouseRow[++index] != String.Empty ? demandHouseRow[index] : null;
                demandHouseFilter.Street = demandHouseRow[++index] != String.Empty ? demandHouseRow[index] : null;
                demandHouseFilter.HouseNum = demandHouseRow[++index] != String.Empty ? Convert.ToInt32(demandHouseRow[index]) : new Nullable<int>();
                index++;
                demandHouseFilter.MinPrice = demandHouseRow[++index] != String.Empty ? Convert.ToDecimal(demandHouseRow[index]) : new Nullable<decimal>();
                demandHouseFilter.MaxPrice = demandHouseRow[++index] != String.Empty ? Convert.ToDecimal(demandHouseRow[index]) : new Nullable<decimal>();
                demandImport.RealtorId = Convert.ToInt32(demandHouseRow[++index]);
                demandImport.ClientId = Convert.ToInt32(demandHouseRow[++index]);
                demandHouseFilter.MinFloorCount = demandHouseRow[++index] != String.Empty ? Convert.ToInt32(demandHouseRow[index]) : new Nullable<int>();
                demandHouseFilter.MaxFloorCount = demandHouseRow[++index] != String.Empty ? Convert.ToInt32(demandHouseRow[index]) : new Nullable<int>();
                demandHouseFilter.MinArea = demandHouseRow[++index] != String.Empty ? Convert.ToDouble(demandHouseRow[index]) : new Nullable<double>();
                demandHouseFilter.MaxArea = demandHouseRow[++index] != String.Empty ? Convert.ToDouble(demandHouseRow[index]) : new Nullable<double>();
                demandHouseFilter.MinRoomCount = demandHouseRow[++index] != String.Empty ? Convert.ToInt32(demandHouseRow[index]) : new Nullable<int>();
                demandHouseFilter.MaxRoomCount = demandHouseRow[++index] != String.Empty ? Convert.ToInt32(demandHouseRow[index]) : new Nullable<int>();

                AgencyModel.Instance.Demand.Add(demandImport);
                AgencyModel.Instance.HouseFilter.Add(demandHouseFilter);
            }

            demandHouseFile.Dispose();
        }
        private void ImportDemandLand(string directoryPath)
        {
            var demandLandFile = new StreamReader(directoryPath + @"/land-demands.txt", Encoding.UTF8);
            demandLandFile.ReadLine();
            while(!demandLandFile.EndOfStream)
            {
                // Id;Address_City;Address_Street;Address_House;Address_Number;MinPrice;MaxPrice;AgentId;ClientId;MinArea;MaxArea
                var demandLandRow = demandLandFile.ReadLine().Split(';');
                var demandImport = new Demand();
                var demandLandFilter = new LandPlotFilter();
                int index = -1;
                demandImport.Id = Convert.ToInt32(demandLandRow[++index]);
                demandLandFilter.DemandId = Convert.ToInt32(demandLandRow[index]);
                demandLandFilter.City = demandLandRow[++index] != String.Empty ? demandLandRow[index] : null;
                demandLandFilter.Street = demandLandRow[++index] != String.Empty ? demandLandRow[index] : null;
                index++;
                index++;
                demandLandFilter.MinPrice = demandLandRow[++index] != String.Empty ? Convert.ToDecimal(demandLandRow[index]) : new Nullable<decimal>();
                demandLandFilter.MaxPrice = demandLandRow[++index] != String.Empty ? Convert.ToDecimal(demandLandRow[index]) : new Nullable<decimal>();
                demandImport.RealtorId = Convert.ToInt32(demandLandRow[++index]);
                demandImport.ClientId = Convert.ToInt32(demandLandRow[++index]);
                demandLandFilter.MinArea = demandLandRow[++index] != String.Empty ? Convert.ToDouble(demandLandRow[index]) : new Nullable<double>();
                demandLandFilter.MaxArea = demandLandRow[++index] != String.Empty ? Convert.ToDouble(demandLandRow[index]) : new Nullable<double>();

                AgencyModel.Instance.Demand.Add(demandImport);
                AgencyModel.Instance.LandPlotFilter.Add(demandLandFilter);
            }

            demandLandFile.Dispose();
        }

        private void ImportSupplies(string directoryPath)
        {
            var supplyFile = new StreamReader(directoryPath + @"/supplies.txt", Encoding.UTF8);
            supplyFile.ReadLine();
            while(!supplyFile.EndOfStream)
            {
                // Id;Price;AgentId;ClientId;RealEstateId
                var clientRow = supplyFile.ReadLine().Split(';');
                var supplyImport = new Supply();
                supplyImport.Id = Convert.ToInt32(clientRow[0]);
                supplyImport.Price = Convert.ToDecimal(clientRow[1]);
                supplyImport.RealtorId = Convert.ToInt32(clientRow[2]);
                supplyImport.ClientId = Convert.ToInt32(clientRow[3]);
                supplyImport.EstleId = Convert.ToInt32(clientRow[4]);

                AgencyModel.Instance.Supply.Add(supplyImport);
            }
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
                flatImport.Id = Convert.ToInt32(flatRow[0]);
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
                houseImport.Id = Convert.ToInt32(floatRow[0]);
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
                landImport.Id = Convert.ToInt32(floatRow[0]);
                landImport.City = floatRow[1];
                landImport.Street = floatRow[2];
                landImport.CoordinateLatitude = Convert.ToInt32(floatRow[5]);
                landImport.CoordinateLongitude = Convert.ToInt32(floatRow[6]);
                landImport.Area = Convert.ToSingle(floatRow[7]);

                AgencyModel.Instance.LandPlot.Add(landImport);
            }

            landFile.Dispose();
        }/* /**/
    }
}
