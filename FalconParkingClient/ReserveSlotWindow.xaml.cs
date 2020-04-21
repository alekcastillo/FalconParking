using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace FalconParkingClient
{
    /// <summary>
    /// Interaction logic for ReserveSlotWindow.xaml
    /// </summary>
    public partial class ReserveSlotWindow : Window
    {
        private Guid ParkingSlotId { get; set; }

        public ReserveSlotWindow(Guid parkingSlotId)
        {
            InitializeComponent();
            ParkingSlotId = parkingSlotId;
        }

        private async void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            if (cboxTime.SelectedIndex < 0)
            {
                MessageBox.Show(
                    "Seleccione un tiempo de reservacion!"
                    ,"Reservar espacio fallido"
                    ,MessageBoxButton.OK
                    ,MessageBoxImage.Error);

                return;
            }

            var result = await FalconParkingAPI.ReserveParkingSlot(
                ParkingSlotId
                ,cboxTime.SelectedIndex);

            if (result)
                MessageBox.Show(
                    "El campo ha sido reservado con exito!"
                    , "Exito"
                    , MessageBoxButton.OK
                    , MessageBoxImage.Information);
            else
                MessageBox.Show(
                    "Ocurrio un error!"
                    ,"Ocupar espacio fallido"
                    ,MessageBoxButton.OK
                    ,MessageBoxImage.Error);

            this.Close();
        }
    }
}
