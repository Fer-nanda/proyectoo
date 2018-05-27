using Microsoft.Reporting.WinForms;
using Muebleria.BIZ;
using Muebleria.COMMON.Entidades;
using Muebleria.COMMON.Grafica;
using Muebleria.COMMON.interfacez;
using Muebleria.COMMON.Interfacez;
using Muebleria.COMMON.Modelo;
using Muebleria.DAL;
using OxyPlot;
using OxyPlot.Axes;
using OxyPlot.Series;
using System;
using System.Collections.Generic;
using System.Linq;
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

namespace Estadisticos.GUI
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Generadora generadora;
        Random ran = new Random();
        enum accion
        {
            nuevo,
            editar
        }
        IManejadorCategoria manejadorCategoria;
        IManejadorRegistro manejadorRegistro;
        IManejadorEmpleado manejadorEmpleado;
        IManejadorVentas manejadorVentas;

        public MainWindow()
        {
            InitializeComponent();
            manejadorCategoria = new ManejadorCategoria(new RepositorioCategoria());
            manejadorRegistro = new ManejadorRegistro(new RepositorioRegistro());
            manejadorEmpleado = new ManejadorEmpleado(new RepositorioEmpleados());
            manejadorVentas = new ManejadorVentas(new RepositorioVentas());
            CargarTablas();

            /*Para Estadisticos*/
            btnCalcularEstadisticos.Click += btnCalcularEstadisticos_Click;
            generadora = new Generadora();
            /*Para Estadisticos*/
        }

        private void CargarTablas()
        {
            

            CmbEstadisticosCategoria.ItemsSource = null;
            CmbEstadisticosCategoria.ItemsSource = manejadorCategoria.Lista;

           cmbFechaEstadisticos.ItemsSource = null;
            cmbFechaEstadisticos.ItemsSource = manejadorRegistro.Lista;

        }

       

        private void GenerarEstadisticos(int valor, string Deporte, string Fecha)
        {
            int contador = 1, contador1 = 1;
            List<NombreCategoria> nombre = new List<NombreCategoria>();
            foreach (var item in manejadorRegistro.Lista)
            {
                if (item.categoriaRegistro == CmbEstadisticosCategoria.Text)
                {
                    NombreCategoria a = new NombreCategoria();
                    a.Cantidad = contador1++;
                    a.Nombre = item.Nombre;
                    nombre.Add(a);
                }
            }

            List<VentasLista> listatorneo = new List<VentasLista>();

            foreach (var item in nombre)
            {
                float valores1 = 0;
                foreach (var item2 in manejadorVentas.Lista)
                {
                    if (item2.Nombre_Empleado == cmbFechaEstadisticos.Text)
                    {
                        if (item.Nombre == item2.Nombre_Empleado)
                        {
                            valores1 = valores1 + item2.Total;
                        }

                        


                    }
                }
                VentasLista a = new VentasLista();
                a.X = contador++;
                a.Mueble = item.Nombre;
                a.cantidad = valores1;
                listatorneo.Add(a);
            }


            int valores = 0;
            valores = listatorneo.Count;
            generadora.GeneradorDatos(listatorneo, 1, valores, 1);
            dtgTablaEstadisticos.ItemsSource = null;
            dtgTablaEstadisticos.ItemsSource = listatorneo;
            PlotModel model = new PlotModel();
            LinearAxis ejeX = new LinearAxis();
            ejeX.Minimum = 1;
            ejeX.Maximum = valores;
            ejeX.Position = AxisPosition.Bottom;

            LinearAxis ejeY = new LinearAxis();
            ejeY.Minimum = generadora.Puntos.Min(p => p.Y);
            ejeY.Maximum = generadora.Puntos.Max(p => p.Y);
            ejeY.Position = AxisPosition.Left;

            model.Axes.Add(ejeX);
            model.Axes.Add(ejeY);
            model.Title = "Datos generados";
            LineSeries linea = new LineSeries();
            foreach (var item in generadora.Puntos)
            {
                linea.Points.Add(new DataPoint(item.X, item.Y));
            }
            linea.Title = "Valores generados";
            linea.Color = OxyColor.FromRgb(byte.Parse(ran.Next(0, 255).ToString()), byte.Parse(ran.Next(0, 255).ToString()), byte.Parse(ran.Next(0, 255).ToString()));
            model.Series.Add(linea);
            Grafica.Model = model;
        }

        private void btnCalcularEstadisticos_Click(object sender, RoutedEventArgs e)
        {
            int valor = 0;
            if (string.IsNullOrEmpty(cmbFechaEstadisticos.Text) || string.IsNullOrEmpty(CmbEstadisticosCategoria.Text))
            {
                MessageBox.Show("Favor de llenar datos\n*categoria\n*Empleado", "Estadisticos", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            foreach (var item in manejadorVentas.Lista)
            {
                if (item.Nombre_Empleado == cmbFechaEstadisticos.Text )
                {
                    valor++;
                }
            }
            if (valor <= 0)
            {
                MessageBox.Show("No se encontro ningun empleado con esa categoria o productos", "Estadisticos", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            GenerarEstadisticos(valor, CmbEstadisticosCategoria.Text, cmbFechaEstadisticos.Text);
        }

        private void btnReportes_Click(object sender, RoutedEventArgs e)
        {
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

        }

        private void btnSalir_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            this.Close();
        }
    }
}
