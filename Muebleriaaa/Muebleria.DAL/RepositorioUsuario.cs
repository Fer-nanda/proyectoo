using LiteDB;
using Muebleria.COMMON.Entidades;
using Muebleria.COMMON.interfacez;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Muebleria.DAL
{
    public class RepositorioUsuario : IRepositorio<Usuarios>
    {
        private string DBName = @"C:\Users\DELL\Desktop\ProyectoFer\mueble\Muebleria.db";
        private string TableName = "Usuario";

        public List<Usuarios> Lista
        {
            get
            {
                List<Usuarios> usuario = new List<Usuarios>();
                using (var db = new LiteDatabase(DBName))
                {
                    usuario = db.GetCollection<Usuarios>(TableName).FindAll().ToList();
                }
                return usuario;
            }
        }

        public bool Crear(Usuarios entidad)
        {
            entidad.Id = Guid.NewGuid().ToString();
            try
            {
                using (var db = new LiteDatabase(DBName))
                {
                    var collection = db.GetCollection<Usuarios>(TableName);
                    collection.Insert(entidad);
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }

        public bool Editar(Usuarios entidad)
        {
            try
            {
                using (var db = new LiteDatabase(DBName))
                {
                    var collection = db.GetCollection<Usuarios>(TableName);
                    collection.Update(entidad);
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool Eliminar(string Id)
        {
            try
            {
                int r;
                using (var db = new LiteDatabase(DBName))
                {
                    var collection = db.GetCollection<Usuarios>(TableName);
                    r = collection.Delete(e => e.Id == Id);
                }
                return r > 0;

            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
