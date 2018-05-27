using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Registros.GUI.Administrador
{
    /// <summary>
    /// Lógica de interacción para Ingreso.xaml
    /// </summary>
    public partial class Ingreso : Window
    {
        public Ingreso()
        {
            InitializeComponent();
        }

        private void btnIniciarAplicacion_Click(object sender, RoutedEventArgs e)
        {
            
           
                if ((pasword.Password == "muebleria2018")&& (txbUsuario.Text=="muebleria"))
                {

                /*Prueba*/
                
                MainWindow s = new MainWindow();
                SoundPlayer player = new SoundPlayer();
                player.SoundLocation = "C:/Users/DELL/Desktop/ProyectoFer/musica/AUD-20180426-WA0000-1.wav";
                player.Play();
                s.Show();
                this.Close();
                /*Prueba*/
            }
                else
                {
                    MessageBox.Show("Datos incorrectos", "Inicio", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
            
            
        }

        private void btnCancelarAplicacion_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Esta realmente seguro de cancelar la operación", "Inicio", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                this.Close();
            }
        }
    }
}
