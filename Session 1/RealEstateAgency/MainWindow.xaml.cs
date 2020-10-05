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
            ImportEstles(@"..\..\..\..\TaskInfo\Resources\DataBaseEntity");
            Database.SetInitializer(new DropCreateDatabaseAlways<AgencyModel>());
            AgencyModel.Instance.SaveChanges();
        }

        private void ImportEstles(string directoryPath)
        {
            ImportClients(directoryPath);
            ImportRealtors(directoryPath);
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
