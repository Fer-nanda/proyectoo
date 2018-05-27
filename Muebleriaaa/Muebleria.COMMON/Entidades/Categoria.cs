using System;
using System.Collections.Generic;
using System.Text;

namespace Muebleria.COMMON.Entidades
{
    public class Categoria:Base
    {
        public string TipoCategoria { get; set; }
        public byte[] Fotografia { get; set; }
        public override string ToString()
        {
            return TipoCategoria;
        }
    }
}
