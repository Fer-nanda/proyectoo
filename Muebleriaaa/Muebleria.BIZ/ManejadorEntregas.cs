using Muebleria.COMMON.Entidades;
using Muebleria.COMMON.interfacez;
using Muebleria.COMMON.Interfacez;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Muebleria.BIZ
{
    public class ManejadorEntregas : IManejadorEntregas
    {
        IRepositorio<Entrega> repositorio;
        public ManejadorEntregas(IRepositorio<Entrega> repositorio)
        {
            this.repositorio = repositorio;
        }

        public List<Entrega> Lista => repositorio.Lista;
        /// <summary>
        /// Agregar
        /// </summary>
        /// <param name="entidad"></param>
        /// <returns>Agrega una entrega</returns>
        public bool Agregar(Entrega entidad)
        {
            return repositorio.Crear(entidad);
        }
        /// <summary>
        /// Buscador
        /// </summary>
        /// <param name="Id"></param>
        /// <returns>regresa una lista de id</returns>
        public Entrega Buscador(string Id)
        {
            return Lista.Where(e => e.Id == Id).SingleOrDefault();
        }
        /// <summary>
        /// BuscadorNoEntregadorPorEmpleado
        /// </summary>
        /// <param name="empleado"></param>
        /// <returns>regresa una lista de empleados</returns>
        public IEnumerable BuscarNoEntregadorPorEmpleado(Empleado empleado)
        {
            return repositorio.Lista.Where(p => p.Solicitante.Id == empleado.Id && p.FechaEntregaReal == null).OrderBy(p => p.FechaEntrega);
        }
        /// <summary>
        /// Eliminar
        /// </summary>
        /// <param name="Id"></param>
        /// <returns>Regresa un empleado eliminado</returns>
        public bool Eliminar(string Id)
        {
            return repositorio.Eliminar(Id);
        }
        /// <summary>
        /// Modificar
        /// </summary>
        /// <param name="entidad"></param>
        /// <returns>regresa un empleado modificado</returns>
        public bool Modificar(Entrega entidad)
        {
            return repositorio.Editar(entidad);
        }
        
        public List<Entrega> ValesEnIntervalo(DateTime inicio, DateTime fin)
        {
            throw new NotImplementedException();
        }

        public List<Entrega> ValesPorLiquidar()
        {
            throw new NotImplementedException();
        }
    }
}
