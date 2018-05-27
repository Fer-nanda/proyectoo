using Muebleria.COMMON.Entidades;
using Muebleria.COMMON.interfacez;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Muebleria.COMMON.Interfacez
{
    public interface IManejadorEntregas : IManejadorGenerico<Entrega>
    {
        List<Entrega> ValesPorLiquidar();
        List<Entrega> ValesEnIntervalo(DateTime inicio, DateTime fin);
        IEnumerable BuscarNoEntregadorPorEmpleado(Empleado empleado);
    }
}
