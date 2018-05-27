using Muebleria.COMMON.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace Muebleria.COMMON.interfacez
{
    public interface IManejadorEmpleado : IManejadorGenerico<Empleado>
    {
        List<Empleado> EmpleadosPorArea(string area);
    }
}
