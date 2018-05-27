using Muebleria.COMMON.Entidades;
using Muebleria.COMMON.interfacez;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Muebleria.BIZ
{
    public class ManejadorEmpleado : IManejadorEmpleado
    {
        IRepositorio<Empleado> empleado;
        public ManejadorEmpleado(IRepositorio<Empleado> empleado)
        {
            this.empleado = empleado;
        }

        public List<Empleado> Lista => empleado.Lista;
/// <summary>
/// Agregar
/// </summary>
/// <param name="entidad"></param>
/// <returns> regresa un empleado agregado</returns>
        public bool Agregar(Empleado entidad)
        {
            return empleado.Crear(entidad);
        }
        /// <summary>
        /// Buscador
        /// </summary>
        /// <param name="Id"></param>
        /// <returns>una lista de empleado por Id</returns>
        public Empleado Buscador(string Id)
        {
            return Lista.Where(e => e.Id == Id).SingleOrDefault();
        }

        /// <summary>
        /// Eliminar
        /// </summary>
        /// <param name="Id"></param>
        /// <returns>regreda un empleado eliminado </returns>

        public bool Eliminar(string Id)
        {
            return empleado.Eliminar(Id);
        }

        public List<Empleado> EmpleadosPorArea(string area)
        {
            return Lista.Where(e => e.puesto == area).ToList();
        }
        /// <summary>
        /// Modificar
        /// </summary>
        /// <param name="entidad"></param>
        /// <returns>regresa un empleado modificado</returns>
        public bool Modificar(Empleado entidad)
        {
            return empleado.Editar(entidad);
        }
    }
}
