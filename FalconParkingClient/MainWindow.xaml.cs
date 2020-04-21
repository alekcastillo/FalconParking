using FalconParkingClient.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

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

        /// <summary>
        /// Revisa si el campo del parqueo esta disponible o no,
        /// y luego muestra la opcion correspondiente para el admin
        /// (Sease ocupar o desocupar), o para el cliente, que seria
        /// reservar
        /// </summary>
        private async void SlotClickHandlerAsync(object sender, SelectionChangedEventArgs e)
        {
            var item = (ParkingSlotView)e.AddedItems[0];
            MessageBoxResult option;

            if (UserRoles.IsAdmin)
            {
                var verb = item.IsAvailable ? "ocupar" : "desocupar";
                option = MessageBox.Show(
                        $"Desea {verb} el campo {item.SlotNumber}?"
                        , "Confirmacion"
                        , MessageBoxButton.YesNo
                        , MessageBoxImage.Exclamation);

                if (option == MessageBoxResult.Yes)
                {
                    if (item.IsAvailable)
                    {
                        new OccupySlotWindow(item.AggregateId).Show();
                    }
                    else
                    {
                        var result = await FalconParkingAPI.FreeParkingSlot(
                            item.AggregateId
                            , "");

                        if (result)
                            MessageBox.Show(
                                $"El campo {item.SlotNumber} ha sido desocupado!"
                                , "Exito"
                                , MessageBoxButton.OK
                                , MessageBoxImage.Information);
                    }
                }
            } else
            {
                if (item.IsAvailable && item.IsReservable)
                {
                    option = MessageBox.Show(
                            $"Desea reservar el campo {item.SlotNumber}?"
                            , "Confirmacion"
                            , MessageBoxButton.YesNo
                            , MessageBoxImage.Exclamation);

                    if (option == MessageBoxResult.Yes)
                        new ReserveSlotWindow(item.AggregateId).Show();
                }
            }
        }

        /// <summary>
        /// Limpia las tabs del tabcontrol para repopularlas
        /// con la nueva data del servidor
        /// </summary>
        private void DeleteTabs()
        {
            tabctlLots.Items.Clear();
        }

        /// <summary>
        /// Crear tabs para cada parqueo, y dentro de cada una
        /// una listview con una grid para mostrar los espacios
        /// </summary>
        private void UpdateUI()
        {
            var currentTab = tabctlLots.SelectedIndex;
            DeleteTabs();
            foreach (var parkingLot in ParkingLots)
            {
                var tab = new TabItem();
                tab.Header = parkingLot.Code;
                tabctlLots.Items.Add(tab);
                var listView = new ListView();
                var gridView = new GridView();
                listView.View = gridView;
                listView.SelectionChanged += SlotClickHandlerAsync;
                gridView.Columns.Add(new GridViewColumn
                {
                    Header = "Numero de campo",
                    DisplayMemberBinding = new Binding("SlotNumber")
                });
                gridView.Columns.Add(new GridViewColumn
                {
                    Header = "Estado",
                    DisplayMemberBinding = new Binding("StatusText")
                });
                gridView.Columns.Add(new GridViewColumn
                {
                    Header = "Es reservable",
                    DisplayMemberBinding = new Binding("IsReservableText")
                });
                gridView.Columns.Add(new GridViewColumn
                {
                    Header = "Ocupante actual",
                    DisplayMemberBinding = new Binding("CurrentOccupantLicensePlate")
                });
                parkingLot.Slots = parkingLot.Slots.OrderBy(sv => sv.SlotNumber).ToList();
                listView.ItemsSource = parkingLot.Slots;
                tab.Content = listView;
            }
            tabctlLots.SelectedIndex = currentTab;
        }

        /// <summary>
        /// Actualiza la ventana con la nueva data del servidor
        /// </summary>
        public void UpdateData(IEnumerable<ParkingLotView> parkingLots)
        {
            ParkingLots = parkingLots;
            UpdateUI();
        }
    }
}
