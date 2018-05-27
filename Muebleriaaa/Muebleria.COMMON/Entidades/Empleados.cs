using System;
using System.Collections.Generic;
using System.Text;

namespace Muebleria.COMMON.Entidades
{
    public class Empleado:Base
    {
        public string Nombre { get; set; }
        public string Ape_paterno { get; set; }
        public string Ape_Materno { get; set; }
        public string domicilio { get; set; }
        public string telefono { get; set; }
        public string Rfc { get; set; }
        public int edad { get; set; }
        public string puesto { get; set; }
        public byte[] Fotografia { get; set; }
        public override string ToString()
        {
            return string.Format("{0} {1}", Nombre, Ape_paterno);
        }
    }
}
