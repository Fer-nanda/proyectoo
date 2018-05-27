using Muebleria.COMMON.Entidades;
using Muebleria.COMMON.interfacez;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Muebleria.BIZ
{
    public class ManejadorCategoria : IManejadorCategoria
    {
        IRepositorio<Categoria> categoria;
        public ManejadorCategoria(IRepositorio<Categoria> categoria)
        {
            this.categoria = categoria;
        }
        

        public List<Categoria> Lista => categoria.Lista;
       /// <summary>
       /// Agregar
       /// </summary>
       /// <param name="entidad"></param>
       /// <returns>regresa una categoria </returns>
        public bool Agregar(Categoria entidad)
        {
            return categoria.Crear(entidad);
        }


        /// <summary>
        /// Buscardor
        /// </summary>
        /// <param name="Id"></param>
        /// <returns>regresa una Lista de categoria </returns>
        public Categoria Buscador(string Id)
        {
            return Lista.Where(e => e.TipoCategoria== Id).SingleOrDefault();
        }


        /// <summary>
        /// Eliminar
        /// </summary>
        /// <param name="Id"></param>
        /// <returns>regresa una categoria</returns>
        public bool Eliminar(string Id)
        {
            return categoria.Eliminar(Id);
        }


        /// <summary>
        /// Modificar
        /// </summary>
        /// <param name="entidad"></param>
        /// <returns>regresa una categoria</returns>
        public bool Modificar(Categoria entidad)
        {
            return categoria.Editar(entidad);
        }
    }
}
