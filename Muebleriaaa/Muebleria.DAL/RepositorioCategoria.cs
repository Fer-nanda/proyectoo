using LiteDB;
using Muebleria.COMMON.Entidades;
using Muebleria.COMMON.interfacez;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Muebleria.DAL
{
    public class RepositorioCategoria : IRepositorio<Categoria>
    {
        private string DBName = @"C:\Users\DELL\Desktop\ProyectoFer\mueble\Muebleria.db";
        private string TableName = "Categorias";
        public List<Categoria> Lista
        {
            get
            {
                List<Categoria> a = new List<Categoria>();
                using (var db = new LiteDatabase(DBName))
                {
                    a = db.GetCollection<Categoria>(TableName).FindAll().ToList();
                }
                return a;
            }
        }

        public bool Crear(Categoria entidad)
        {
            entidad.Id = Guid.NewGuid().ToString();
            try
            {
                using (var db = new LiteDatabase(DBName))
                {
                    var collection = db.GetCollection<Categoria>(TableName);
                    collection.Insert(entidad);
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool Editar(Categoria entidad)
        {
            try
            {
                using (var db = new LiteDatabase(DBName))
                {
                    var collection = db.GetCollection<Categoria>(TableName);
                    collection.Update(entidad);
                }
                return true;
            }
            catch (Exception)
            {
                return false;
                throw;
            }
        }

        public bool Eliminar(string Id)
        {
            try
            {
                int a;
                using (var db = new LiteDatabase(TableName))
                {
                    var collection = db.GetCollection<Categoria>(TableName);
                    a = collection.Delete(e => e.Id == Id);
                }
                return a > 0;
            }
            catch (Exception)
            {
                return false;
                throw;
            }
        }
    }
}
