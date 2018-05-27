using LiteDB;
using Muebleria.COMMON.Entidades;
using Muebleria.COMMON.interfacez;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Muebleria.DAL
{
    public class RepositorioRegistro : IRepositorio<RegistroMuebles>
    {
        private string DBName = @"C:\Users\DELL\Desktop\ProyectoFer\mueble\Muebleria.db";
        private string TableName = "Registros";
        public List<RegistroMuebles> Lista
        {
            get
            {
                List<RegistroMuebles> a = new List<RegistroMuebles>();
                using (var db = new LiteDatabase(DBName))
                {
                    a = db.GetCollection<RegistroMuebles>(TableName).FindAll().ToList();
                }
                return a;
            }
        }

        public bool Crear(RegistroMuebles entidad)
        {
            entidad.Id = Guid.NewGuid().ToString();
            try
            {
                using (var db = new LiteDatabase(DBName))
                {
                    var collection = db.GetCollection<RegistroMuebles>(TableName);
                    collection.Insert(entidad);
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool Editar(RegistroMuebles entidad)
        {
            try
            {
                using (var db = new LiteDatabase(DBName))
                {
                    var collection = db.GetCollection<RegistroMuebles>(TableName);
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
                    var collection = db.GetCollection<RegistroMuebles>(TableName);
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
