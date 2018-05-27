using Muebleria.COMMON.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace Muebleria.COMMON.Modelo
{
    public class ModeloUsuarios
    {
        public string Nombre { get; set; }
        public string Telefono { get; set; }
        public string Puesto { get; set; }
        public ModeloUsuarios(Empleado empleado)
        {
            Nombre = string.Format("{0} {1} {2}", empleado.Nombre, empleado.Ape_Materno, empleado.Ape_paterno);
            Telefono = string.Format("{0}", empleado.telefono);
            Puesto = string.Format("{0}", empleado.puesto);
        }
    }
}
