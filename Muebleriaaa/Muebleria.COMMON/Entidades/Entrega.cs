using System;
using System.Collections.Generic;
using System.Text;

namespace Muebleria.COMMON.Entidades
{
    public class Entrega:Base
    {
        public DateTime FechaHoraSolicitud { get; set; }
        public DateTime FechaEntrega { get; set; }
        public DateTime? FechaEntregaReal { get; set; }
        public List<RegistroMuebles> Muebles { get; set; }
        public Empleado Solicitante { get; set; }
        public Empleado EncargadoDeEntrega { get; set; }

        public override string ToString()
        {
            return String.Format("{0} {1} debe {2} artículos y los debería de entregar el {3}", Solicitante.Nombre, Solicitante.Ape_paterno, Muebles.Count, FechaEntrega.ToShortDateString());
        }
    }
}
