using System;
using System.Collections.Generic;
using System.Text;

namespace Muebleria.COMMON.Entidades
{
    public class RegistroMuebles:Base
    {
        public string categoriaRegistro { get; set; }
        public string Nombre { get; set; }
        public string Modelo { get; set; }
        public float Precio_Compra { get; set; }
        public float precio_Venta { get; set; }
        public int Can { get; set; }
        public byte[] Fotografia { get; set; }
        public override string ToString()
        {
            return Nombre;
        }
    }
}
