using Muebleria.COMMON.Entidades;
using Muebleria.COMMON.interfacez;
using Muebleria.COMMON.Interfacez;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Muebleria.BIZ
{
    public class ManejadorUsuario : IManejadorUsuarios
    {
        IRepositorio<Usuarios> usuario;
        public ManejadorUsuario(IRepositorio<Usuarios> usuario)
        {
            this.usuario = usuario;
        }
        public List<Usuarios> Lista => usuario.Lista;
        /// <summary>
        /// Agregar
        /// </summary>
        /// <param name="entidad"></param>
        /// <returns>agrega un usuario</returns>
        public bool Agregar(Usuarios entidad)
        {
            return usuario.Crear(entidad);
        }
        /// <summary>
        /// Buscador
        /// </summary>
        /// <param name="Id"></param>
        /// <returns>Lista de usuarios por id</returns>
        public Usuarios Buscador(string Id)
        {
            return Lista.Where(e => e.Id == Id).SingleOrDefault();

        }
        /// <summary>
        /// Eliminar
        /// </summary>
        /// <param name="Id"></param>
        /// <returns>elimina un usuario por id</returns>
        public bool Eliminar(string Id)
        {
            return usuario.Eliminar(Id);
        }
        /// <summary>
        /// Modificar
        /// </summary>
        /// <param name="entidad"></param>
        /// <returns>modifica un usuario</returns>
        public bool Modificar(Usuarios entidad)
        {
            return usuario.Editar(entidad);
        }
    }
}
