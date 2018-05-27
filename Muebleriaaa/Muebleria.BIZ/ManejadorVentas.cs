using Muebleria.COMMON.Entidades;
using Muebleria.COMMON.interfacez;
using Muebleria.COMMON.Interfacez;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Muebleria.BIZ
{
    public class ManejadorVentas : IManejadorVentas
    {
        IRepositorio<InventarioVentas> venta;
        public ManejadorVentas(IRepositorio<InventarioVentas> venta)
        {
            this.venta = venta;
        }

        public List<InventarioVentas> Lista => venta.Lista;
        /// <summary>
        /// Agregar
        /// </summary>
        /// <param name="entidad"></param>
        /// <returns>agrega ventas</returns>
        public bool Agregar(InventarioVentas entidad)
        {
            return venta.Crear(entidad);
        }
        /// <summary>
        /// InventarioVentas
        /// </summary>
        /// <param name="Id"></param>
        /// <returns>lista de ventas</returns>
        public InventarioVentas Buscador(string Id)
        {
            return Lista.Where(e => e.Id == Id).SingleOrDefault();
        }
        /// <summary>
        /// Eliminar
        /// </summary>
        /// <param name="Id"></param>
        /// <returns>elimina venta</returns>
        public bool Eliminar(string Id)
        {
            return venta.Eliminar(Id);
        }
        /// <summary>
        /// Modificar
        /// </summary>
        /// <param name="entidad"></param>
        /// <returns>modicar una venta</returns>
        public bool Modificar(InventarioVentas entidad)
        {
            return venta.Editar(entidad);
        }
    }
}
