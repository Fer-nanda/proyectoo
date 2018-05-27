using Microsoft.Win32;
using Muebleria.BIZ;
using Muebleria.COMMON.Entidades;
using Muebleria.COMMON.interfacez;
using Muebleria.COMMON.Interfacez;
using Muebleria.DAL;
using System;
using System.Collections.Generic;
using System.IO;
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

namespace Ventas.GUI.Empleados
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        
        enum accion
        {
            Nuevo,
            Editar
        }
        ManejadorEntregas manejadorEntregas;
        ManejadorRegistro manejadorProductos;
        ManejadorEmpleado manejadorEmpleado;
        IManejadorUsuarios manejadorUsuarios;
        Entrega entrega;
        //Emple empleados;
        accion accionVale;
        public MainWindow()
        {
            InitializeComponent();
            manejadorProductos = new ManejadorRegistro(new RepositorioRegistro());
            manejadorEmpleado = new ManejadorEmpleado(new RepositorioEmpleados());
            manejadorEntregas = new ManejadorEntregas(new RepositorioEntrega());
            ActualizarTablaEntrega();
            //ActualizarListaDeMueblesEnVale();
            manejadorUsuarios = new ManejadorUsuario(new RepositorioUsuario());
            CargarTablas();
            HabilitarBotones(false);
            ActualizarCombosDetalle();
            //gridDetalle.IsEnabled = false;
        }

        private void CargarTablas()
        {
            dtgUsuarios.ItemsSource = null;
            dtgUsuarios.ItemsSource = manejadorUsuarios.Lista;

        }

        private void HabilitarBotones(bool a)
        {
            txbNombreDeUsuario.IsEnabled = a;
            txbTipoUsuario.IsEnabled = a;
            boxContrasena.IsEnabled = a;
            

            btnNuevoUsuario.IsEnabled = !a;
            btnEliminarUusraios.IsEnabled = !a;
            btnAgregar.IsEnabled = a;
            btnCancelarUsuario.IsEnabled = a;
            btnEditarUsuario.IsEnabled = !a;
        }

        private void ActualizarTablaEntrega()
        {
            dtgEntrega.ItemsSource = null;
            dtgEntrega.ItemsSource = manejadorEntregas.Lista;
        }

        private void btnNuevaEntrega_Click(object sender, RoutedEventArgs e)
        {
            //gridDetalle.IsEnabled = true;
            ActualizarCombosDetalle();
            entrega = new Entrega();
            entrega.Muebles = new List<RegistroMuebles>();
            ActualizarListaDeMueblesEnVale();
            accionVale = accion.Nuevo;
        }

        private void ActualizarListaDeMueblesEnVale()
        {
            dtgMueblesEntrega.ItemsSource = null;
            dtgMueblesEntrega.ItemsSource = entrega.Muebles;
        }

        private void ActualizarCombosDetalle()
        {
            cmbAlmacenista.ItemsSource = null;
            cmbAlmacenista.ItemsSource = manejadorEmpleado.EmpleadosPorArea("Almacen");
            cmbMuebles.ItemsSource = null;
            cmbMuebles.ItemsSource = manejadorProductos.Lista;

            cmbSolicitante.ItemsSource = null;
            cmbSolicitante.ItemsSource = manejadorEmpleado.Lista;


        }

        private void btnElimarEntrega_Click(object sender, RoutedEventArgs e)
        {
            Entrega v = dtgEntrega.SelectedItem as Entrega;
            if (v != null)
            {
                if (MessageBox.Show("Realmente deseas eliminar el vale?", "Almacén", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                {
                    if (manejadorEntregas.Eliminar(v.Id))
                    {
                        MessageBox.Show("Eliminado con éxito", "Almacén", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                        ActualizarTablaEntrega();
                    }
                    else
                    {
                        MessageBox.Show("Algo salio mal...", "Almacén", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
            }
        }

        private void btnEntregarMueble_Click(object sender, RoutedEventArgs e)
        {
            lblFechaHoraEntregaReal.Content = DateTime.Now;

        }

        private void btnGuardarEntrega_Click(object sender, RoutedEventArgs e)
        {
            if (accionVale == accion.Nuevo)
            {
                entrega.EncargadoDeEntrega = cmbAlmacenista.SelectedItem as Empleado;
                entrega.FechaEntrega = dtpFechaEntrega.SelectedDate.Value;
                entrega.FechaHoraSolicitud = DateTime.Now;
                entrega.Solicitante = cmbSolicitante.SelectedItem as Empleado;

                if (manejadorEntregas.Agregar(entrega))
                {
                    MessageBox.Show("Vale guardado con éxito", "Almacén", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                    LimpiarCamposDeEntrega();
                    //gridDetalle.IsEnabled = false;
                    ActualizarTablaEntrega();
                }
                else
                {
                    MessageBox.Show("Error al guardar el vale", "Almacén", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
            {
                entrega.EncargadoDeEntrega = cmbAlmacenista.SelectedItem as Empleado;
                entrega.FechaEntrega = dtpFechaEntrega.SelectedDate.Value;
                entrega.FechaHoraSolicitud = DateTime.Now;
                entrega.Solicitante = cmbSolicitante.SelectedItem as Empleado;
               entrega.FechaEntregaReal=DateTime.Parse(lblFechaHoraEntregaReal.Content.ToString());
                if (manejadorEntregas.Modificar(entrega))
                {
                    MessageBox.Show("Vale guardado con éxito", "Almacén", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                    LimpiarCamposDeEntrega();
                    //gridDetalle.IsEnabled = false;
                    ActualizarTablaEntrega();
                }
                else
                {
                    MessageBox.Show("Error al guardar el vale", "Almacén", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private void LimpiarCamposDeEntrega()
        {
            dtpFechaEntrega.SelectedDate = DateTime.Now;
            lblFechaHoraEntregaReal.Content = "";
            lblFechaHoraVenta.Content = "";
            dtgMueblesEntrega.ItemsSource = null;
            cmbAlmacenista.ItemsSource = null;
            cmbMuebles.ItemsSource = null;
            cmbSolicitante.ItemsSource = null;
        }

        private void btnCancelarEntrega_Click(object sender, RoutedEventArgs e)
        {
            LimpiarCamposDeEntrega();
            //gridDetalle.IsEnabled = false;
        }

        private void btnAgregarMuebles_Click(object sender, RoutedEventArgs e)
        {
            RegistroMuebles m = cmbMuebles.SelectedItem as RegistroMuebles;
            if (m != null)
            {
                entrega.Muebles.Add(m);
                ActualizarListaDeMueblesEnVale();
            }
        }

        private void btnEliminarMuebles_Click(object sender, RoutedEventArgs e)
        {
            RegistroMuebles m = dtgMueblesEntrega.SelectedItem as RegistroMuebles;
            if (m != null)
            {
                entrega.Muebles.Remove(m);
                ActualizarListaDeMueblesEnVale();
            }
        }

        private void dtgEntrega_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            Entrega v = dtgEntrega.SelectedItem as Entrega;
            if (v != null)
            {
                //gridDetalle.IsEnabled = true;
                entrega = v;
                ActualizarListaDeMueblesEnVale();
                accionVale = accion.Editar;
                lblFechaHoraVenta.Content = entrega.FechaHoraSolicitud.ToString();
                lblFechaHoraEntregaReal.Content = entrega.FechaEntregaReal.ToString();
                ActualizarCombosDetalle();
                cmbAlmacenista.Text = entrega.EncargadoDeEntrega.ToString();
                cmbSolicitante.Text = entrega.Solicitante.ToString();
                dtpFechaEntrega.SelectedDate = entrega.FechaEntrega;
            }
        }


        private void btnNuevoUsuario_Click(object sender, RoutedEventArgs e)
        {
            LimpiarCamposTablasUsuario();
            HabilitarBotones(true);
            accionVale = accion.Nuevo;
        }

        private void btnAgregar_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(boxContrasena.Password) )
            {
                MessageBox.Show("No ha ingresado los datos  de Usuario", "Usuarios", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (string.IsNullOrEmpty(txbNombreDeUsuario.Text) )
            {
                MessageBox.Show("No ha ingresado todos los datos  del Usuario", "Usuarios", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (string.IsNullOrEmpty(txbTipoUsuario.Text))
            {
                MessageBox.Show("No ha ingresado todos los datos del Usuario", "Usuarios", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            

            int contrasena = boxContrasena.Password.Count();
            if (contrasena <= 8)
            {
                MessageBox.Show("La contraseña debe de ser mayor o igual a 8 caracteres para mayor seguridad", "Usuarios", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }
            if (accionVale == accion.Nuevo)
            {
                Usuarios a = new Usuarios()
                {
                    NombreDeUsuario = txbNombreDeUsuario.Text,
                    Tipo = txbTipoUsuario.Text,
                    Contraseña = boxContrasena.Password,
                    Fotografia = ImageToByte(imgFotoos.Source),

            };
                manejadorUsuarios.Agregar(a);
                CargarTablas();
                LimpiarCamposTablasUsuario();
                HabilitarBotones(false);
            }
            else
            {
                Usuarios usuario = dtgUsuarios.SelectedItem as Usuarios;
                usuario.NombreDeUsuario = txbNombreDeUsuario.Text;
                usuario.Tipo = txbTipoUsuario.Text;
                usuario.Contraseña = boxContrasena.Password;
                usuario.Fotografia = ImageToByte(imgFotoos.Source);
                if (manejadorUsuarios.Modificar(usuario))
                {
                    CargarTablas();
                    LimpiarCamposTablasUsuario();
                    HabilitarBotones(false);
                    MessageBox.Show("Usuario editado correctamente", "Usuarios", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                {
                    MessageBox.Show("No se puedo editar correctamente el usuario", "Usuarios", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
        }

        private void btnEliminarUusraios_Click(object sender, RoutedEventArgs e)
        {
            Usuarios a = dtgUsuarios.SelectedItem as Usuarios;
            if (a != null)
            {
                if (MessageBox.Show("Realmente esta seguro de eliminar el usuario: " + a.NombreDeUsuario, "Eliminación Usuario", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                {
                    manejadorUsuarios.Eliminar(a.Id);
                    CargarTablas();
                }
            }
            else
            {
                MessageBox.Show("No ha seleccionado ningun elemento de la tabla Usuarios", "Usuarios", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void btnEditarUsuario_Click(object sender, RoutedEventArgs e)
        {
            if (dtgUsuarios.SelectedItem != null)
            {
                Usuarios a = dtgUsuarios.SelectedItem as Usuarios;
                txbNombreDeUsuario.Text = a.NombreDeUsuario;
                txbTipoUsuario.Text = a.Tipo;
                boxContrasena.Password = a.Contraseña;
                imgFotoos.Source = ByteToImage(a.Fotografia);
                accionVale = accion.Editar;
                HabilitarBotones(true);

            }
            else
            {
                MessageBox.Show("No ha seleccionado ningun elemento de la tabla Usuarios", "Usuarios", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void btnCancelarUsuario_Click(object sender, RoutedEventArgs e)
        {
            if ((MessageBox.Show("Esta realmente seguro de cancelar la operación", "Usuarios", MessageBoxButton.YesNo, MessageBoxImage.Question)) == MessageBoxResult.Yes)
            {
                HabilitarBotones(false);
                LimpiarCamposTablasUsuario();
            }
        }

        private void LimpiarCamposTablasUsuario()
        {
            txbNombreDeUsuario.Clear();
            txbTipoUsuario.Clear();
            boxContrasena.Clear();
            
        }


        private void btnCargarFotoos_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog dialogo = new OpenFileDialog();
            dialogo.Title = "Selecciona una foto";
            dialogo.Filter = "Archivos de imagen|*.jpg; *.png; *.gif";
            if (dialogo.ShowDialog().Value)
            {
                imgFotoos.Source = new BitmapImage(new Uri(dialogo.FileName));
            }
        }

        public ImageSource ByteToImage(byte[] imageData)
        {
            if (imageData == null)
            {
                return null;
            }
            else
            {
                BitmapImage biImg = new BitmapImage();
                MemoryStream ms = new MemoryStream(imageData);
                biImg.BeginInit();
                biImg.StreamSource = ms;
                biImg.EndInit();
                ImageSource imgSrc = biImg as ImageSource;
                return imgSrc;
            }
        }

        public byte[] ImageToByte(ImageSource image)
        {
            if (image != null)
            {
                MemoryStream memStream = new MemoryStream();
                JpegBitmapEncoder encoder = new JpegBitmapEncoder();
                encoder.Frames.Add(BitmapFrame.Create(image as BitmapSource));
                encoder.Save(memStream);
                return memStream.ToArray();
            }
            else
            {
                return null;
            }
        }

        private void btnSalir_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            this.Close();
        }
    }
}
