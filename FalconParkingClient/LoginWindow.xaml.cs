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
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        public LoginWindow()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            if (txtEmail.Text.Length < 1)
            {
                MessageBox.Show(
                    "Ingrese un correo valido!"
                    ,"Login fallido"
                    ,MessageBoxButton.OK
                    ,MessageBoxImage.Error);

                return;
            }

            if (txtPassword.Text.Length < 1)
            {
                MessageBox.Show(
                    "Ingrese una clave valida!"
                    ,"Login fallido"
                    ,MessageBoxButton.OK
                    ,MessageBoxImage.Error);

                return;
            }

            var userId = TCPClient.TryLogin(txtEmail.Text, txtPassword.Text);

            if (userId == Guid.Empty)
                MessageBox.Show(
                    "Credenciales incorrectos!"
                    ,"Login fallido"
                    ,MessageBoxButton.OK
                    ,MessageBoxImage.Error);
            else
            {
                UserRoles.CurrentUserId = userId;
                var nombre = UserRoles.IsAdmin ? "Admin" : "Cliente";

                MessageBox.Show(
                    $"Bienvenido {nombre}!"
                    ,"Login exitoso"
                    ,MessageBoxButton.OK
                    ,MessageBoxImage.Information);

                new MainWindow().Show();
                this.Close();
            }
        }
    }
}
