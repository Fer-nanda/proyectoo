using System;
using System.Collections.Generic;
using System.Text;

namespace Muebleria.COMMON.Entidades
{
    public class InventarioVentas:Base
    {
        public DateTime Fecha { get; set; }
        public string Nombre_Empleado { get; set; }
        public string Nombre_Cliente { get; set; }
        public List<Ventaas> Productos_Venta { get; set; }
        public float Subtotal { get; set; }
        public float Iva { get; set; }
        public float Total { get; set; }
        public float Forma_Pago { get; set; }
        public float Cambio { get; set; }
    }
}
