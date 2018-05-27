using Muebleria.COMMON.Entidades;
using Muebleria.COMMON.interfacez;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Muebleria.BIZ
{
    public class ManejadorRegistro : IManejadorRegistro
    {
        IRepositorio<RegistroMuebles> registro;
        public ManejadorRegistro(IRepositorio<RegistroMuebles> registro)
        {
            this.registro = registro;
        }

        public List<RegistroMuebles> Lista => registro.Lista;
        /// <summary>
        /// Agregar
        /// </summary>
        /// <param name="entidad"></param>
        /// <returns>agrega un regristo</returns>
        public bool Agregar(RegistroMuebles entidad)
        {
            return registro.Crear(entidad);
        }
        /// <summary>
        /// Buscador
        /// </summary>
        /// <param name="Id"></param>
        /// <returns>regresa una lista de registro de muebles</returns>
        public RegistroMuebles Buscador(string Id)
        {
            return Lista.Where(e => e.Id == Id).SingleOrDefault();
        }
        /// <summary>
        /// Elimimar
        /// </summary>
        /// <param name="Id"></param>
        /// <returns>elimina un registro pro id</returns>
        public bool Eliminar(string Id)
        {
            return registro.Eliminar(Id);
        }
        /// <summary>
        /// Modificar
        /// </summary>
        /// <param name="entidad"></param>
        /// <returns>modifica un registro</returns>
        public bool Modificar(RegistroMuebles entidad)
        {
            return registro.Editar(entidad);
        }
    }
}
