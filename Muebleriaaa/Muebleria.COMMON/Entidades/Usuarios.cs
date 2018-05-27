using System;
using System.Collections.Generic;
using System.Text;

namespace Muebleria.COMMON.Entidades
{
    public class Usuarios:Base
    {
        public string NombreDeUsuario { get; set; }
        public string Tipo { get; set; }
        public string Contraseña { get; set; }
        public byte[] Fotografia { get; set; }
        public override string ToString()
        {
            return NombreDeUsuario;
        }
    }
}
