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

namespace Registros.GUI.Administrador
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        bool N;
        List<Ventaas> venta;
        float iva = 0.10f;
        enum accion
        {
            Nuevo,
            Editar
        }
        accion acc;
        IManejadorCategoria manejadorCategoria;
        IManejadorEmpleado manejadorEmpleado;
        //IManejadorClientes manejadorCliente;
        IManejadorRegistro manejadorProductos;
        IManejadorVentas manejadorVenta;

        public MainWindow()
        {
            InitializeComponent();
            manejadorCategoria = new ManejadorCategoria(new RepositorioCategoria());
            //manejadorCliente = new ManejadorCliente(new RepositorioCliente());
            manejadorEmpleado = new ManejadorEmpleado(new RepositorioEmpleados());
            manejadorProductos = new ManejadorRegistro(new RepositorioRegistro());
            manejadorVenta = new ManejadorVentas(new RepositorioVentas());
            venta = new List<Ventaas>();
            AccionesParaProductos();
            AccionesParaCategoria();
            AccionesParaEmpleado();
            AccionesAlmacenDeVentanas();
            CargarFormularioVenta();
        }

        private void AccionesAlmacenDeVentanas()
        {
            ActualizarTablaInvenatarioDeVenta();
            LimpiarBotonesEnAlmacen();
        }

        private void ActualizarTablaInvenatarioDeVenta()
        {
            dtgAlmacenDeVentaInventario.ItemsSource = null;
            dtgAlmacenDeVentaInventario.ItemsSource = manejadorVenta.Lista;
        }

        private void ActualizarTablaVentaAlmacen()
        {
            dtgProductosVentaAlmacen.ItemsSource = null;
            dtgProductosVentaAlmacen.ItemsSource = manejadorProductos.Lista;
        }

        private void CargarFormularioVenta()
        {
            txtVentaFecha.Text = DateTime.Now.ToShortDateString();
            ActualizarTablaEmpleado();
            ActualizarComboxDeTodosLosFormularios();
            ActualizarTablaVentaAlmacen();
            ActualizarTablaProductosEnVenta(); // tabla de la de venta
            InabilitarCamposVenta(false);// los botones de la venta
        }

        private void ActualizarComboxDeTodosLosFormularios()
        {
            manejadorCategoria = new ManejadorCategoria(new RepositorioCategoria());
            manejadorEmpleado = new ManejadorEmpleado(new RepositorioEmpleados());
            CmbCategoriaRegistro.ItemsSource = manejadorCategoria.Lista;//carga de combobox
            cmbVentaNombreEmpleado.ItemsSource = manejadorEmpleado.Lista;
        }

        private void AccionesParaEmpleado()
        {
            LimpiarEmpleado(false);
            BotonesEmpleado(false);
            ActualizarTablaEmpleado();
        }

        private void BotonesEmpleado(bool v)
        {
            EmpleadoBtnCancelar.IsEnabled = v;
            EmpleadoBtnEliminar.IsEnabled = !v;
            EmpleadoBtnGuardar.IsEnabled = v;
            EmpleadoBtnNuevo.IsEnabled = !v;
            EmpleadoBtnEditar.IsEnabled = !v;
        }

        private void ActualizarTablaEmpleado()
        {
            dtgEmpleado.ItemsSource = null;
            dtgEmpleado.ItemsSource = manejadorEmpleado.Lista;
        }

        private void LimpiarEmpleado(bool v)
        {
            txbA_MaternoEmpleado.Clear();
            txbA_PaternoEmpleado.Clear();
            txbDireccionEmpleado.Clear();
            txbEdadEmpleado.Clear();
            txbNombreEmpleado.Clear();
            txbPuestoEmpleado.Clear();
            txbRfcEmpleado.Clear();
            txbTelefonoEmpleado.Clear();

            txbA_MaternoEmpleado.IsEnabled = v;
            txbA_PaternoEmpleado.IsEnabled = v;
            txbDireccionEmpleado.IsEnabled = v;
            txbEdadEmpleado.IsEnabled = v;
            txbNombreEmpleado.IsEnabled = v;
            txbPuestoEmpleado.IsEnabled = v;
            txbRfcEmpleado.IsEnabled = v;
            
        }

        private void AccionesParaProductos()
        {
            BotonesProductos(false);
            LimpiarProductos(false);
            ActualizarTablaProductos();
            ActualizarTablaVentaAlmacen();
        }

        private void AccionesParaCategoria()
        {
            BotonesCategoria(false);
            LimpiarCategoria(false);
            ActualizarTablaCategoria();
            ActualizarComboxDeTodosLosFormularios();
        }

        private void ActualizarTablaCategoria()
        {
            dtgCategoria.ItemsSource = null;
            dtgCategoria.ItemsSource = manejadorCategoria.Lista;
        }

        private void LimpiarCategoria(bool v)
        {
            TxbCategoriaNombre.Clear();
            TxbCategoriaNombre.IsEnabled = v;
        }

        private void BotonesCategoria(bool v)
        {
            CategoriaBtnCancelar.IsEnabled = v;
            CategoriaBtnEditar.IsEnabled = !v;
            CategoriaBtnEliminar.IsEnabled = !v;
            CategoriaBtnGuardar.IsEnabled = v;
            CategoriaBtnNuevo.IsEnabled = !v;
        }

        private void ActualizarTablaProductos()
        {
            dtgProductos.ItemsSource = null;
            dtgProductos.ItemsSource = manejadorProductos.Lista;
        }

        private void LimpiarProductos(bool v)
        {
            txbNombreRegistro.Clear();
            txbDescripcionRegistro.Clear();
            txbCanRegistro.Clear();
            txbP_CompraRegistro.Clear();
            txbp_VentaRegistro.Clear();

            txbNombreRegistro.IsEnabled = v;
            txbDescripcionRegistro.IsEnabled = v;
            txbCanRegistro.IsEnabled = v;
            txbp_VentaRegistro.IsEnabled = v;
            txbP_CompraRegistro.IsEnabled = v;
            CmbCategoriaRegistro.IsEnabled = v;
           

        }

        private void BotonesProductos(bool v)
        {
            ProductosBtnCancelar.IsEnabled = v;
            ProductosBtnEditar.IsEnabled = !v;
            ProductosBtnEliminar.IsEnabled = !v;
            ProductosBtnGuardar.IsEnabled = v;
            ProductosBtnNuevo.IsEnabled = !v;
        }

        private void ProductosBtnNuevo_Click(object sender, RoutedEventArgs e)
        {
            LimpiarProductos(true);
            BotonesProductos(true);
            acc = accion.Nuevo;
        }

        private void ProductosBtnGuardar_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(txbNombreRegistro.Text))
            {
                MessageBox.Show("No ha llenado el campo Nombre", "Registro", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (string.IsNullOrEmpty(txbDescripcionRegistro.Text))
            {
                MessageBox.Show("No ha llenado el campo Descripción", "Registro", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (string.IsNullOrEmpty(txbP_CompraRegistro.Text))
            {
                MessageBox.Show("No ha llenado el campo Precio de Compra", "Registro", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            /*Para checar si son numeros*/
            foreach (var item in txbP_CompraRegistro.Text)
            {
                if (!(char.IsNumber(item)))
                {
                    MessageBox.Show("Solo se permiten números en el Precio Compra, no caracteres", "Registro", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
            }

            if (string.IsNullOrEmpty(txbp_VentaRegistro.Text))
            {
                MessageBox.Show("No ha llenado el campo Precio de venta", "Registro", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            /*Para checar si son numeros*/
            foreach (var item in txbp_VentaRegistro.Text)
            {
                if (!(char.IsNumber(item)))
                {
                    MessageBox.Show("Solo se permiten números en Precio Venta, no caracteres", "Registro", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
            }
            
            if (string.IsNullOrEmpty(txbCanRegistro.Text))
            {
                MessageBox.Show("No ha llenado el campo Cantidad", "Registro", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            /*Para checar si son numeros*/
            foreach (var item in txbCanRegistro.Text)
            {
                if (!(char.IsNumber(item)))
                {
                    MessageBox.Show("Solo se permiten números en Cantidad, no caracteres", "Registro", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
            }

            if (string.IsNullOrEmpty(CmbCategoriaRegistro.Text))
            {
                MessageBox.Show("No ha llenado el campo Categoria", "Registro", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            
            if (acc == accion.Nuevo)
            {
                RegistroMuebles productos = new RegistroMuebles()
                {
                    categoriaRegistro= (CmbCategoriaRegistro.Text).ToString(),
                    Nombre = txbNombreRegistro.Text,
                    Modelo = txbDescripcionRegistro.Text,
                    Precio_Compra = float.Parse(txbP_CompraRegistro.Text),
                    precio_Venta = float.Parse(txbp_VentaRegistro.Text),
                    Can = int.Parse(txbCanRegistro.Text),
                    Fotografia = ImageToByte(imgFoto.Source)

                };
                if (manejadorProductos.Agregar(productos))
                {
                    MessageBox.Show("Registro agregado correctamente", "Registro", MessageBoxButton.OK, MessageBoxImage.Information);
                    AccionesParaProductos();
                }
                else
                {
                    MessageBox.Show("El Registro no se pudo agregar", "Registro", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
            {
                RegistroMuebles productos = dtgProductos.SelectedItem as RegistroMuebles;
                productos.categoriaRegistro = CmbCategoriaRegistro.Text.ToString();
                productos.Nombre = txbNombreRegistro.Text;
                productos.Modelo = txbDescripcionRegistro.Text;
                productos.Precio_Compra = float.Parse(txbP_CompraRegistro.Text);
                productos.precio_Venta = float.Parse(txbp_VentaRegistro.Text);
                productos.Can = int.Parse(txbCanRegistro.Text);
                productos.Fotografia = ImageToByte(imgFoto.Source);
                if (manejadorProductos.Modificar(productos))
                {
                    MessageBox.Show("Registro modificado correctamente", "Registro", MessageBoxButton.OK, MessageBoxImage.Information);
                    AccionesParaProductos();
                }
                else
                {
                    MessageBox.Show("El Registro no se pudo actualizar", "Registro", MessageBoxButton.OK, MessageBoxImage.Error);
                }
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
        private void btnCargarFoto_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog dialogo = new OpenFileDialog();
            dialogo.Title = "Selecciona una foto";
            dialogo.Filter = "Archivos de imagen|*.jpg; *.png; *.gif";
            if (dialogo.ShowDialog().Value)
            {
                imgFoto.Source = new BitmapImage(new Uri(dialogo.FileName));
            }
        }

        private void ProductosBtnEditar_Click(object sender, RoutedEventArgs e)
        {
            if (manejadorProductos.Lista.Count == 0)
            {
                MessageBox.Show("No cuenta con ningun Registro para editar", "Registro", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
            if (dtgProductos.SelectedItem != null)
            {
                try
                {

                    RegistroMuebles productos = dtgProductos.SelectedItem as RegistroMuebles;
                    LimpiarProductos(true);
                    CmbCategoriaRegistro.Text = productos.categoriaRegistro;
                    txbNombreRegistro.Text = productos.Nombre;
                    txbDescripcionRegistro.Text = productos.Modelo;
                    txbP_CompraRegistro.Text = productos.Precio_Compra.ToString();
                   txbp_VentaRegistro.Text = productos.precio_Venta.ToString();
                    txbCanRegistro.Text = productos.Can.ToString();
                    imgFoto.Source = ByteToImage(productos.Fotografia);

                    acc = accion.Editar;
                    BotonesProductos(true);
                }
                catch (Exception)
                {

                    MessageBox.Show("No se puedo realizar la operacion", "Registro", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
            {
                MessageBox.Show("No ha seleccionado ningun Registro para modificar", "Registro", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        

        private void ProductosBtnCancelar_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Esta seguro de cancelar la operación", "Registro", MessageBoxButton.YesNo, MessageBoxImage.Exclamation) == MessageBoxResult.Yes)
            {
                AccionesParaProductos();
            }
        }

        private void ProductosBtnEliminar_Click(object sender, RoutedEventArgs e)
        {
            RegistroMuebles productos = dtgProductos.SelectedItem as RegistroMuebles;
            if (productos != null)
            {
                if (MessageBox.Show("Realmente deseas eliminar este Registro?", "Registro", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                {
                    if (manejadorProductos.Eliminar(productos.Id))
                    {
                        MessageBox.Show("Producto eliminado", "Registro", MessageBoxButton.OK, MessageBoxImage.Information);
                        ActualizarTablaProductos();
                    }
                    else
                    {
                        MessageBox.Show("No se pudo eliminar el Registro", "Registro", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                }
            }
            else
            {
                MessageBox.Show("No ha seleccionado ningun Registro", "Registro", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private void CategoriaBtnNuevo_Click(object sender, RoutedEventArgs e)
        {
            LimpiarCategoria(true);
            BotonesCategoria(true);
            acc = accion.Nuevo;
        }

        private void CategoriaBtnGuardar_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(TxbCategoriaNombre.Text))
            {
                MessageBox.Show("No ha agregado el campo categoria", "Categoria", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (acc == accion.Nuevo)
            {
                Categoria categoria = new Categoria();
                categoria.TipoCategoria = TxbCategoriaNombre.Text;
                categoria.Fotografia = ImageToByte(imgFotos.Source);
                if (manejadorCategoria.Agregar(categoria))
                {
                    MessageBox.Show("Categoria agregado correctamente", "Categoria", MessageBoxButton.OK, MessageBoxImage.Information);
                    AccionesParaCategoria();
                }
                else
                {
                    MessageBox.Show("La Categoria no se pudo agregar ", "Categoria", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
            {
                Categoria categoria = dtgCategoria.SelectedItem as Categoria;
                categoria.TipoCategoria = TxbCategoriaNombre.Text;
                categoria.Fotografia = ImageToByte(imgFotos.Source);
                if (manejadorCategoria.Modificar(categoria))
                {
                    MessageBox.Show("Categoria editada correctamente", "Categoria", MessageBoxButton.OK, MessageBoxImage.Information);
                    AccionesParaCategoria();
                }
                else
                {
                    MessageBox.Show("La Categoria no se pudo modificar ", "Categoria", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private void CategoriaBtnCancelar_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Esta seguro de cancelar la operación", "Categoria", MessageBoxButton.YesNo, MessageBoxImage.Exclamation) == MessageBoxResult.Yes)
            {
                AccionesParaCategoria();
            }
        }

        private void CategoriaBtnEditar_Click(object sender, RoutedEventArgs e)
        {
            Categoria categoria = dtgCategoria.SelectedItem as Categoria;
            if (categoria != null)
            {
                LimpiarCategoria(true);
                TxbCategoriaNombre.Text = categoria.TipoCategoria;
                imgFotos.Source = ByteToImage(categoria.Fotografia);
                acc = accion.Editar;
                BotonesCategoria(true);
            }
            else
            {
                MessageBox.Show("No ha seleccionado ninguna categoria", "Categoria", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private void CategoriaBtnEliminar_Click(object sender, RoutedEventArgs e)
        {
            Categoria categoria = dtgCategoria.SelectedItem as Categoria;
            if (categoria != null)
            {
                if (MessageBox.Show("Realmente esta seguro de eliminar esta categoria", "Categoria", MessageBoxButton.YesNo, MessageBoxImage.Exclamation) == MessageBoxResult.Yes)
                {
                    if (manejadorCategoria.Eliminar(categoria.Id))
                    {
                        MessageBox.Show("Categoria eliminada", "Categoria", MessageBoxButton.OK, MessageBoxImage.Information);
                        ActualizarTablaCategoria();
                        ActualizarComboxDeTodosLosFormularios();
                    }
                    else
                    {
                        MessageBox.Show("Realmente esta seguro de eliminar esta categoria", "Categoria", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                }
            }
            else
            {
                MessageBox.Show("No ha seleccionado ninguna categoria", "Categoria", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private void btnCargarFotos_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog dialogo = new OpenFileDialog();
            dialogo.Title = "Selecciona una foto";
            dialogo.Filter = "Archivos de imagen|*.jpg; *.png; *.gif";
            if (dialogo.ShowDialog().Value)
            {
                imgFotos.Source = new BitmapImage(new Uri(dialogo.FileName));
            }
        }

        private void EmpleadoBtnNuevo_Click(object sender, RoutedEventArgs e)
        {
            LimpiarEmpleado(true);
            BotonesEmpleado(true);
            acc = accion.Nuevo;
        }

        private void EmpleadoBtnGuardar_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(txbNombreEmpleado.Text))
            {
                MessageBox.Show("Falta ingresar en Nombre", "Empleado", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (string.IsNullOrEmpty(txbA_PaternoEmpleado.Text))
            {
                MessageBox.Show("Falta ingresar el Apelliodo Paterno", "Empleado", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (string.IsNullOrEmpty(txbA_MaternoEmpleado.Text))
            {
                MessageBox.Show("Falta ingresar el Apelliodo Materno", "Empleado", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (string.IsNullOrEmpty(txbDireccionEmpleado.Text))
            {
                MessageBox.Show("Falta ingresar la Dirección", "Empleado", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (string.IsNullOrEmpty(txbTelefonoEmpleado.Text))
            {
                MessageBox.Show("Falta ingresar el telefono", "Empleado", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (string.IsNullOrEmpty(txbRfcEmpleado.Text))
            {
                MessageBox.Show("Falta ingresar el RFC", "Empleado", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (string.IsNullOrEmpty(txbEdadEmpleado.Text))
            {
                MessageBox.Show("Falta ingresar la Edad", "Empleado", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            /*Para checar si son numeros*/
            foreach (var item in txbEdadEmpleado.Text)
            {
                if (!(char.IsNumber(item)))
                {
                    MessageBox.Show("Solo se permiten números en la edad del empleado, no caracteres", "Empleado", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
            }

            if (string.IsNullOrEmpty(txbPuestoEmpleado.Text))
            {
                MessageBox.Show("Falta ingresar el Telefono", "Empleado", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

      

            if (acc == accion.Nuevo)
            {
                Empleado empleado = new Empleado();
                empleado.Nombre = txbNombreEmpleado.Text;
                empleado.Ape_paterno = txbA_PaternoEmpleado.Text;
                empleado.Ape_Materno = txbA_MaternoEmpleado.Text;
                empleado.domicilio = txbDireccionEmpleado.Text;
                empleado.telefono = txbTelefonoEmpleado.Text;
                empleado.Rfc = txbRfcEmpleado.Text;
                empleado.edad = int.Parse(txbEdadEmpleado.Text);
                empleado.puesto = txbPuestoEmpleado.Text;
                empleado.Fotografia = ImageToByte(imgFotoos.Source);

                if (manejadorEmpleado.Agregar(empleado))
                {
                    MessageBox.Show("Empleado agregado correctamente", "Empleado", MessageBoxButton.OK, MessageBoxImage.Information);
                    AccionesParaEmpleado();
                }
                else
                {
                    MessageBox.Show("El empleado no se pudo agregar ", "Empleado", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
            {
                Empleado empleado = dtgEmpleado.SelectedItem as Empleado;
                empleado.Nombre = txbNombreEmpleado.Text;
                empleado.Ape_paterno = txbA_PaternoEmpleado.Text;
                empleado.Ape_Materno = txbA_MaternoEmpleado.Text;
                empleado.domicilio = txbDireccionEmpleado.Text;
                empleado.telefono = txbTelefonoEmpleado.Text;
                empleado.Rfc = txbRfcEmpleado.Text;
                empleado.edad = int.Parse(txbEdadEmpleado.Text);
                empleado.puesto = txbPuestoEmpleado.Text;
                empleado.Fotografia = ImageToByte(imgFotoos.Source);

                if (manejadorEmpleado.Modificar(empleado))
                {
                    MessageBox.Show("Empleado editada correctamente", "Empleado", MessageBoxButton.OK, MessageBoxImage.Information);
                    AccionesParaEmpleado();
                }
                else
                {
                    MessageBox.Show("El empleado no se pudo modificar ", "Empleado", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }

        }

        private void EmpleadoBtnCancelar_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Esta seguro de cancelar la operación", "Empleado", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                AccionesParaEmpleado();
            }
        }

        private void EmpleadoBtnEditar_Click(object sender, RoutedEventArgs e)
        {
            Empleado empleado = dtgEmpleado.SelectedItem as Empleado;
            if (empleado != null)
            {
                LimpiarEmpleado(true);
                txbNombreEmpleado.Text = empleado.Nombre;
                txbA_PaternoEmpleado.Text = empleado.Ape_paterno;
                txbA_MaternoEmpleado.Text = empleado.Ape_Materno;
                txbDireccionEmpleado.Text = empleado.domicilio;
                txbTelefonoEmpleado.Text = empleado.telefono;
                txbRfcEmpleado.Text = empleado.Rfc;
                txbEdadEmpleado.Text = empleado.edad.ToString();
                txbPuestoEmpleado.Text = empleado.puesto;
                imgFotoos.Source = ByteToImage(empleado.Fotografia);

                acc = accion.Editar;
                BotonesEmpleado(true);
            }
            else
            {
                MessageBox.Show("No ha seleccionado ningun empleado para modificar", "Empleado", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void EmpleadoBtnEliminar_Click(object sender, RoutedEventArgs e)
        {
            Empleado empleado = dtgEmpleado.SelectedItem as Empleado;
            if (empleado != null)
            {
                if (MessageBox.Show("Realmente deseas eliminar este empleado: " + empleado.Nombre + "?", "Empleado", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                {
                    if (manejadorEmpleado.Eliminar(empleado.Id))
                    {
                        MessageBox.Show("Empleado eliminado", "Empleado", MessageBoxButton.OK, MessageBoxImage.Information);
                        ActualizarTablaEmpleado();
                        ActualizarComboxDeTodosLosFormularios();
                    }
                    else
                    {
                        MessageBox.Show("No se pudo eliminar el Empleado", "Empleado", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                }
            }
            else
            {
                MessageBox.Show("No ha seleccionado ningun Empleado", "Empleado", MessageBoxButton.OK, MessageBoxImage.Information);
            }
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


        private void VentaBtnAgregar_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(txtVentaCantidadProducto.Text))
            {
                MessageBox.Show("No ha colocado la cantidad de producto", "Venta", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            /*Validacion para saber si son numeros */
            foreach (var item in txtVentaCantidadProducto.Text)
            {
                if (!(char.IsNumber(item)))
                {
                    MessageBox.Show("Solo se permiten números, no caracteres", "Ventas", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
            }

            if (int.Parse(txtVentaCantidadProducto.Text) <= 0)
            {
                MessageBox.Show("No se aceptan números inferiores a 1", "Venta", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (N == false)
            {
                Ventaas v = new Ventaas();
                RegistroMuebles p = dtgProductosVentaAlmacen.SelectedItem as RegistroMuebles;
                if (p == null)
                {
                    MessageBox.Show("No ha seleccionado ningun produto", "Venta", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
                if (int.Parse(txtVentaCantidadProducto.Text) > (p.Can))
                {
                    MessageBox.Show("No cuenta con suficiente Stock", "Venta", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
                v.Producto = p.Nombre;
                v.Precio = p.precio_Venta;
                v.Cantidad = int.Parse(txtVentaCantidadProducto.Text);
                v.Total = v.Cantidad * v.Precio;
                venta.Add(v);
                ActualizarTablaProductosEnVenta();
                txtVentaCantidadProducto.Clear();
                /*Para Actualizar La tabla deProductos de la tabla/**/
                try
                {
                    p.categoriaRegistro = p.categoriaRegistro;
                    p.Nombre = p.Nombre;
                    p.Modelo = p.Modelo;
                    p.Precio_Compra = p.Precio_Compra;
                    p.precio_Venta = p.precio_Venta;
                    
                    p.Can = ((p.Can) - v.Cantidad);
                   
                    manejadorProductos.Modificar(p);
                    ActualizarTablaVentaAlmacen();
                    ActualizarTablaProductos();
                }
                catch (Exception)
                {

                    MessageBox.Show("Error no se puede descontar los productos del almacen", "Ventas", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
            }
            else
            {
                Ventaas a = dtgListaDeVenta.SelectedItem as Ventaas;
                if (a == null)
                {
                    MessageBox.Show("No ha seleccionado ningun produto", "Venta", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
                int evaluarStock = 0;
                foreach (var item in manejadorProductos.Lista)
                {
                    if (item.Nombre == a.Producto)
                    {
                        if (item.Can < int.Parse(txtVentaCantidadProducto.Text))
                        {
                            MessageBox.Show("No hay suficiente Cantidad. Almacenamiento: " + item.Can + " De: " + txtVentaCantidadProducto.Text, "Venta", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                            txtVentaCantidadProducto.Clear();
                            return;
                        }
                        evaluarStock = item.Can + a.Cantidad;
                    }
                }
                a.Producto = a.Producto;
                a.Cantidad = int.Parse(txtVentaCantidadProducto.Text);
                a.Precio = (a.Precio);
                a.Total = ((a.Precio)) * (int.Parse(txtVentaCantidadProducto.Text));
                ActualizarTablaProductosEnVenta();
                txtVentaCantidadProducto.Clear();
                /*Para actualizar la tabla de los productps igual*/
                try
                {
                    foreach (var item in manejadorProductos.Lista)
                    {
                        if (item.Nombre == a.Producto)
                        {
                            item.categoriaRegistro = item.categoriaRegistro;
                            item.Nombre = item.Nombre;
                            item.Modelo = item.Modelo;
                            item.Precio_Compra = item.Precio_Compra;
                            item.precio_Venta = item.precio_Venta;
                            item.Can = evaluarStock - a.Cantidad;
                            
                            manejadorProductos.Modificar(item);
                            ActualizarTablaVentaAlmacen();
                            ActualizarTablaProductos();
                        }
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("No se puedo Editar correctamente el producto en Almacen", "Almacen", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
                /*Fin de la actulizacion*/
                N = false;
            }
        }

        private void ActualizarTablaProductosEnVenta()
        {
            dtgListaDeVenta.ItemsSource = null;
            dtgListaDeVenta.ItemsSource = venta;
        }

        private void VentaBtnCalcular_Click(object sender, RoutedEventArgs e)//object sender, RoutedEventArgs e
        {
            if (venta.Count == 0)
            {
                MessageBox.Show("No cuenta con ningun producto en la lista para calcular", "Venta", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            float total = 0;
            foreach (Ventaas item in venta)
            {
                total += item.Total;
            }
            txtVentaSubtotal.Text = total.ToString();
            txtVentaIva.Text = (iva * total).ToString();
            txtVentaTotal.Text = (total + (total * iva)).ToString();// MessageBox.Show("MONTO\nSub-total: $"+ total.ToString()+ "\nIva: $"+ (iva*total)+ "\ntotal: $"+(total+(total*iva)), "Venta", MessageBoxButton.OK, MessageBoxImage.Information);
            HabilitarCajaventa(true);
            HabilitarNuevaVenta(false);
            BotonEjecutarVEnta(true);
            InabilitarElbotonCalcular(false);
        }

        private void HabilitarNuevaVenta(bool v)
        {
            VentaNuevaVenta.IsEnabled = v;
        }

        private void BotonEjecutarVEnta(bool v)
        {
            VentaBtnVenta.IsEnabled = v;
        }

        private void VentaBtnVenta_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(txtVentaPago.Text))
            {
                MessageBox.Show("No ha llenado la casilla de 'Forma de pago'", "Venta", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (string.IsNullOrEmpty(txtVentaCliente.Text))
            {
                MessageBox.Show("No ha llenado la casilla de 'Nombre de Cliente'", "Venta", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (string.IsNullOrEmpty(cmbVentaNombreEmpleado.Text))
            {
                MessageBox.Show("No ha seleccionado  el 'Nombre del Empleado'", "Venta", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            float total = 0;
            foreach (Ventaas item in venta)
            {
                total += item.Total;
            }
            /* txtVentaSubtotal.Text = total.ToString();
             txtVentaIva.Text = (iva * total).ToString();
             txtVentaTotal.Text = (total + (total * iva)).ToString();*/

            if (float.Parse(txtVentaPago.Text) < (total + (total * iva)))
            {
                MessageBox.Show("Forma de pago inferior a la venta", "Venta", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            float cambio = 0;
            cambio = (float.Parse(txtVentaPago.Text)) - (total + (total * iva));
            MessageBox.Show("MONTO\nSub-total: $" + total.ToString() + "\nIva: $" + (iva * total) + "\ntotal: $" + (total + (total * iva)) + "\nForma de pago: $" + txtVentaPago.Text + "\nCambio: $" + cambio, "Venta", MessageBoxButton.OK, MessageBoxImage.Information);

            /*Guardar los datos en el archivo*/
            AccionesArchivo reporte = new AccionesArchivo(txtVentaCliente.Text.ToUpper() + ".poo");
            string datos = "";
            datos = string.Format("Farmacia 'Mi QUERIDO ENFERMITO'\nFecha: {0}\nEmpleado: {1}\nCliente: {2}\n-------------------------------------\nProducto   Precio Cantidad Total\n-------------------------------------\n", txtVentaFecha.Text, cmbVentaNombreEmpleado.Text.ToUpper(), txtVentaCliente.Text.ToUpper());
            string elementos = "";
            foreach (Ventaas item in venta)
            {
                elementos += string.Format("{0}      {1}     {2}     {3}\n", item.Producto, item.Precio, item.Cantidad, item.Total);
            }
            string informacion = string.Format("\nSubtotal: ${0}\nIva: ${1}\nTotal: ${2}\nForma de pago: ${3}\nCambio: ${4}\n\n   ¡¡¡Vuelva pronto!!!", txtVentaSubtotal.Text, txtVentaIva.Text, txtVentaTotal.Text, txtVentaPago.Text, cambio);
            reporte.Guardar(datos + elementos + informacion);
            MessageBox.Show("Reporte Guardado con Exito: " + txtVentaCliente.Text.ToUpper() + ".poo", "Reporte", MessageBoxButton.OK, MessageBoxImage.Information);
            /*Guardar los datos en el archivo*/
            /*LLenar los datos del Inventario*/
            try
            {
                InventarioVentas Ventas = new InventarioVentas()
                {
                    Nombre_Cliente = txtVentaCliente.Text,
                    Cambio = cambio,
                    Fecha = DateTime.Now,
                    Iva = float.Parse(txtVentaIva.Text),
                    Nombre_Empleado = cmbVentaNombreEmpleado.Text,
                    Subtotal = float.Parse(txtVentaSubtotal.Text),
                    Total = total + (total * iva),
                    Forma_Pago = float.Parse(txtVentaPago.Text),
                    Productos_Venta = venta,
                };
                manejadorVenta.Agregar(Ventas);
                AccionesAlmacenDeVentanas();
            }
            catch (Exception)
            {

                MessageBox.Show("No se pudo generar Lista en Inventario de Ventas", "Ventas", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            /*Fin de LLenar Los datos delInvenatrio*/
            InabilitarCamposVenta(false);
            venta = new List<Ventaas>();//limpia la lista
            dtgListaDeVenta.ItemsSource = null;//limpia la tabla
            ActualizarTablaProductosEnVenta();
            InabilitarBotonVentaVenta(true);
        }



        private void HabilitarCajaventa(bool v)
        {
            VentaBtnVenta.IsEnabled = v;
            VentaNuevaVenta.IsEnabled = v;
        }

        private void VentaBtnCancelar_Click(object sender, RoutedEventArgs e)
        {
            if ((MessageBox.Show("Esta realmente seguro de cancelar el producto", "Venta", MessageBoxButton.YesNo, MessageBoxImage.Question)) == MessageBoxResult.Yes)
            {
                txtVentaCantidadProducto.Clear();
                //txtVentaNombreProducto.Clear();
            }
        }

        private void InabilitarCamposVenta(bool v)
        {
            txtVentaCantidadProducto.IsEnabled = v;
            txtVentaCantidadProducto.Clear();
            txtVentaCliente.IsEnabled = v;
            txtVentaCliente.Clear();
            //  txtVentaFolio.IsEnabled = v;
            //txtVentaFolio.Clear();
            txtVentaIva.IsEnabled = v;
            txtVentaIva.Clear();
            txtVentaPago.IsEnabled = v;
            txtVentaPago.Clear();
            txtVentaSubtotal.IsEnabled = v;
            txtVentaSubtotal.Clear();
            txtVentaTotal.IsEnabled = v;
            txtVentaTotal.Clear();
            cmbVentaNombreEmpleado.IsEnabled = v;
            //txtVentaNombreProducto.IsEnabled = v;
            VentaBtnAgregar.IsEnabled = v;
            VentaBtnCalcular.IsEnabled = v;
            VentaBtnCancelar.IsEnabled = v;
            VentaBtnVenta.IsEnabled = v;
            VentaBrnCancelarVenta.IsEnabled = v;
            //VentaBtnBuscarProducto.IsEnabled = v;
            VentaBtnEditarProducto.IsEnabled = v;
            VentaBtnEliminarProducto.IsEnabled = v;
            txtVentaFecha.IsEnabled = v;
        }

        private void VentaBrnCancelarVenta_Click(object sender, RoutedEventArgs e)
        {
            if ((MessageBox.Show("Esta realmente seguro de cancelar toda la operación?\nSe descartara toda la venta", "Venta", MessageBoxButton.YesNo, MessageBoxImage.Question)) == MessageBoxResult.Yes)
            {/*Para Actualizar el stock de la venta*/
                if (venta.Count > 0)
                {
                    foreach (Ventaas item in venta)
                    {
                        foreach (var dos in manejadorProductos.Lista)
                        {

                            if (item.Producto == dos.Nombre)
                            {
                                dos.categoriaRegistro = dos.categoriaRegistro;
                                dos.Nombre = dos.Nombre;
                                dos.Modelo =dos.Modelo;
                                dos.Precio_Compra = dos.Precio_Compra;
                                dos.precio_Venta = dos.precio_Venta;
                                
                                dos.Can = item.Cantidad + dos.Can;
                                
                                manejadorProductos.Modificar(dos);
                                ActualizarTablaVentaAlmacen();
                                ActualizarTablaProductos();
                            }
                        }
                    }

                }/*Fin de  la actualizacion del stock*/
                InabilitarCamposVenta(false);
                venta = new List<Ventaas>();//limpia la lista
                dtgListaDeVenta.ItemsSource = null;//limpia la tabla
                ActualizarTablaProductosEnVenta();
                InabilitarBotonVentaVenta(true);
            }
        }

        private void InabilitarBotonVentaVenta(bool v)
        {
            VentaNuevaVenta.IsEnabled = v;
        }

        private void InabilitarElbotonCalcular(bool v)
        {
            VentaBtnCalcular.IsEnabled = v;
        }


        private void VentaNuevaVenta_Click(object sender, RoutedEventArgs e)
        {
            InabilitarCamposVenta(true);
            HabilitarCajaventa(true);
            venta = new List<Ventaas>();//limpia la lista
            dtgListaDeVenta.ItemsSource = null;//limpia la tabla
            ActualizarTablaProductosEnVenta();
            InabilitarBotonVentaVenta(false);
            BotonEjecutarVEnta(false);
        }

        private void VentaBtnEliminarProducto_Click(object sender, RoutedEventArgs e)
        {
            if (dtgListaDeVenta.SelectedItem == null)
            {
                MessageBox.Show("No ha seleccionado ningun elemento de la Lista de productos!!!\nSeleccione la fila a eliminar.", "Venta", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            else
            {
                if (MessageBox.Show("Realmente esta seguro de eliminar este producto de su lista", "Venta", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                {
                    Ventaas p = dtgListaDeVenta.SelectedItem as Ventaas;
                    /*Para actualizar la tabla de los productps igual*/
                    try
                    {
                        foreach (var item in manejadorProductos.Lista)
                        {
                            if (item.Nombre == p.Producto)
                            {
                                item.categoriaRegistro = item.categoriaRegistro;
                                item.Nombre = item.Nombre;
                                item.Precio_Compra = item.Precio_Compra;
                                item.precio_Venta = item.precio_Venta;
                                item.Modelo = item.Modelo;
                                item.Can = (p.Cantidad + item.Can);
                                
                                manejadorProductos.Modificar(item);
                                ActualizarTablaVentaAlmacen();
                                ActualizarTablaProductos();
                            }
                        }
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("No se puedo Editar correctamente el producto en Almacen", "Almacen", MessageBoxButton.OK, MessageBoxImage.Error);
                        return;
                    }
                    /*Fin de la actulizacion*/
                    venta.Remove(p);
                    ActualizarTablaProductosEnVenta();
                    MessageBox.Show("Producto eliminado Correctamente", "Venta", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
        }

        private void VentaBtnEditarProducto_Click(object sender, RoutedEventArgs e)
        {
            if (venta.Count == 0)
            {
                MessageBox.Show("No cuenta con ningun producto en la lista", "Venta", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            else
            {
                if (dtgListaDeVenta.SelectedItem != null)
                {
                    Ventaas a = dtgListaDeVenta.SelectedItem as Ventaas;
                    txtVentaCantidadProducto.Text = a.Cantidad.ToString();
                    N = true;
                }
                else
                {
                    MessageBox.Show("No ha seleccionado ningun elemento", "Venta", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private void dtgAlmacenDeVentaInventario_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            InventarioVentas a = dtgAlmacenDeVentaInventario.SelectedItem as InventarioVentas;
            if (a != null)
            {
                txtAlmacenSub_Total.Text = a.Subtotal.ToString();
                txtAlmacenIva.Text = a.Iva.ToString();
                txtAlmacenTotal.Text = a.Total.ToString();
                txtAlmacenCambio.Text = a.Cambio.ToString();
                txtAlmacenCliente.Text = a.Nombre_Cliente.ToString();
                txtAlmacenEmpleado.Text = a.Nombre_Empleado.ToString();
                txtAlmacenFecha.Text = a.Fecha.ToString();
                txtAlmacenPago.Text = a.Forma_Pago.ToString();
                dtgAlmacenDeVentaObservarVenta.ItemsSource = a.Productos_Venta;

            }
            else
            {
                MessageBox.Show("No ha seleccionado ninguna fila", "Inventario", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
        }

        private void btnAlmacenVentaEliminar_Click(object sender, RoutedEventArgs e)
        {
            InventarioVentas a = dtgAlmacenDeVentaInventario.SelectedItem as InventarioVentas;
            if (a != null)
            {
                if (MessageBox.Show("Realmente quiere eliminar la venta", "Almacen de Ventas", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                {
                    manejadorVenta.Eliminar(a.Id);
                    AccionesAlmacenDeVentanas();
                }
            }
            else
            {
                MessageBox.Show("No ha seleccionado ninguna fila", "Inventario", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
        }

        private void LimpiarBotonesEnAlmacen()
        {
            txtAlmacenCambio.Clear();
            txtAlmacenCliente.Clear();
            txtAlmacenEmpleado.Clear();
            txtAlmacenFecha.Clear();
            txtAlmacenIva.Clear();
            txtAlmacenSub_Total.Clear();
            txtAlmacenTotal.Clear();
            dtgAlmacenDeVentaObservarVenta.ItemsSource = null;
        }

        private void btnAlmacenVentanaLimpiar_Click(object sender, RoutedEventArgs e)
        {
            LimpiarBotonesEnAlmacen();
        }


        private void btnSalir_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            this.Close();
        }

    }
}
