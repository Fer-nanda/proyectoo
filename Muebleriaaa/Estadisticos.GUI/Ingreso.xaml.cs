using Microsoft.Reporting.WinForms;
using Muebleria.BIZ;
using Muebleria.COMMON.interfacez;
using Muebleria.COMMON.Modelo;
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

namespace Estadisticos.GUI
{
    /// <summary>
    /// Lógica de interacción para Ingreso.xaml
    /// </summary>
    public partial class Ingreso : Window
    {
        IManejadorEmpleado manejadorEmpleado;

        public Ingreso()
        {
            InitializeComponent();
            manejadorEmpleado = new ManejadorEmpleado(new RepositorioEmpleados());
        }

        private void btnIniciarAplicacion_Click(object sender, RoutedEventArgs e)
        {


            if ((pasword.Password == "muebleria2018") && (txbUsuario.Text == "fernanda"))
            {
                //SoundPlayer player = new SoundPlayer();
                //player.SoundLocation = "C:/Users/DELL/Desktop/ProyectoFer/musica/AUD-20180426-WA0000-1.wav";
                //player.Play();
                List<ReportDataSource> datos = new List<ReportDataSource>();
                ReportDataSource reporte = new ReportDataSource();
                List<ModeloUsuarios> datosUsuarioss = new List<ModeloUsuarios>();
                foreach (var item in manejadorEmpleado.Lista)
                {
                    datosUsuarioss.Add(new ModeloUsuarios(item));
                }
                reporte.Value = datosUsuarioss;
                reporte.Name = "DataSet1";
                datos.Add(reporte);
                Reporteador ventana = new Reporteador("Estadisticos.GUI.Informes.UsuariosSinParametro.rdlc", datos);//("Torneo.GUI.Reporte.ReporteSinParametros.rdlc", datos);
                ventana.ShowDialog();
                
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
