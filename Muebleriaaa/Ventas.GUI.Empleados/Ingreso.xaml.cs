using Muebleria.BIZ;
using Muebleria.COMMON.Entidades;
using Muebleria.COMMON.Interfacez;
using Muebleria.DAL;
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

namespace Ventas.GUI.Empleados
{
    /// <summary>
    /// Lógica de interacción para Ingreso.xaml
    /// </summary>
    public partial class Ingreso : Window
    {
        IManejadorUsuarios manejadorUsuario;
        public Ingreso()
        {
            InitializeComponent();
            manejadorUsuario = new ManejadorUsuario(new RepositorioUsuario());

            ActualizarBase();
        }
        private void ActualizarBase()
        {
            cmbUsuario.ItemsSource = null;
            cmbUsuario.ItemsSource = manejadorUsuario.Lista;
        }

        private void btnIniciarAplicacion_Click(object sender, RoutedEventArgs e)
        {
            if (cmbUsuario.Text == "")
            {
                MessageBox.Show("No ha colocado el usuario al que corresponde\nSelecciones uno", "Inicio", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (string.IsNullOrEmpty(pasword.Password))
            {
                MessageBox.Show("No ha ingresado la contraseña", "Inicio", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (cmbUsuario.SelectedItem != null)
            {
                Usuarios b = cmbUsuario.SelectedItem as Usuarios;
                if (pasword.Password == b.Contraseña)
                {
                    SoundPlayer player = new SoundPlayer();
                    player.SoundLocation = "C:/Users/DELL/Desktop/ProyectoFer/musica/AUD-20180426-WA0000-1.wav";
                    player.Play();
                    MainWindow a = new MainWindow();
                    a.Show();
                    this.Close();
                    
                }
                else
                {
                    MessageBox.Show("Contraseña Inconrrecta", "Inicio", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
            }
            else
            {
                MessageBox.Show("No ha seleccionado ningun usuario", "Inicio", MessageBoxButton.OK, MessageBoxImage.Error);
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
