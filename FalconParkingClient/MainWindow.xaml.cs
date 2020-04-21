using FalconParkingClient.Views;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
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

namespace FalconParkingClient
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Thread DataUpdater;
        public string Data { get; set; }
        private IEnumerable<ParkingLotView> ParkingLots { get; set; }

        public MainWindow()
        {
            InitializeComponent();
            DataUpdater = new Thread(() => FalconParkingAPI.ParkingLotDataUpdater(this));
            DataUpdater.Start();
        }

        private void DeleteTabs()
        {
            tabctlLots.Items.Clear();
        }

        private void UpdateUI()
        {
            DeleteTabs();
            foreach (var parkingLot in ParkingLots)
            {
                var tab = new TabItem();
                tab.Header = parkingLot.Code;
                tabctlLots.Items.Add(tab);
                var listView = new ListView();
                var gridView = new GridView();
                listView.View = gridView;
                gridView.Columns.Add(new GridViewColumn
                {
                    Header = "Numero",
                    DisplayMemberBinding = new Binding("SlotNumber")
                });
                gridView.Columns.Add(new GridViewColumn
                {
                    Header = "Estado",
                    DisplayMemberBinding = new Binding("Status")
                });
                gridView.Columns.Add(new GridViewColumn
                {
                    Header = "Es reservable",
                    DisplayMemberBinding = new Binding("isReservable"),
                    Width = 50.0
                });
                listView.ItemsSource = parkingLot.Slots;
                tab.Content = listView;
            }

            tabctlLots.SelectedIndex = 0;
        }

        public void UpdateData(IEnumerable<ParkingLotView> parkingLots)
        {
            ParkingLots = parkingLots;
            UpdateUI();
        }

        private async void BtnConnect_Click(object sender, RoutedEventArgs e)
        {
            //ParkingLots = await FalconParkingAPI.GetParkingLots();
            //UpdateUI();
        }
    }
}
