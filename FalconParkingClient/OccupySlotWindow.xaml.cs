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
    /// Interaction logic for OccupySlotWindow.xaml
    /// </summary>
    public partial class OccupySlotWindow : Window
    {
        private Guid ParkingSlotId { get; set; }

        public OccupySlotWindow(Guid parkingSlotId)
        {
            InitializeComponent();
            ParkingSlotId = parkingSlotId;
        }

        private async void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            if (txtLicensePlate.Text.Length < 1)
            {
                MessageBox.Show(
                    "Ingrese un numero de placa valido!"
                    , "Ocupar espacio fallido"
                    , MessageBoxButton.OK
                    , MessageBoxImage.Error);

                return;
            }

            if (txtUserIdentification.Text.Length < 1)
            {
                MessageBox.Show(
                    "Ingrese un numero de cedula valido!"
                    ,"Ocupar espacio fallido"
                    ,MessageBoxButton.OK
                    ,MessageBoxImage.Error);

                return;
            }

            var result = await FalconParkingAPI.OccupyParkingSlot(
                ParkingSlotId
                ,txtLicensePlate.Text
                ,txtUserIdentification.Text);

            if (result)
            {
                MessageBox.Show(
                    "El campo ha sido ocupado!"
                    , "Exito"
                    , MessageBoxButton.OK
                    , MessageBoxImage.Information);

                this.Close();
            }
            else
                MessageBox.Show(
                    "Ocurrio un error!"
                    ,"Ocupar espacio fallido"
                    ,MessageBoxButton.OK
                    ,MessageBoxImage.Error);

        }
    }
}
