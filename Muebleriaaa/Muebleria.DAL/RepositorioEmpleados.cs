using LiteDB;
using Muebleria.COMMON.Entidades;
using Muebleria.COMMON.interfacez;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Muebleria.DAL
{
    public class RepositorioEmpleados : IRepositorio<Empleado>
    {
        private string DBName = @"C:\Users\DELL\Desktop\ProyectoFer\mueble\Muebleria.db";
        private string TableName = "Empleados";
        public List<Empleado> Lista
        {
            get
            {
                List<Empleado> a = new List<Empleado>();
                using (var db = new LiteDatabase(DBName))
                {
                    a = db.GetCollection<Empleado>(TableName).FindAll().ToList();
                }
                return a;
            }
        }

        public bool Crear(Empleado entidad)
        {
            entidad.Id = Guid.NewGuid().ToString();
            try
            {
                using (var db = new LiteDatabase(DBName))
                {
                    var collection = db.GetCollection<Empleado>(TableName);
                    collection.Insert(entidad);
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool Editar(Empleado entidad)
        {
            try
            {
                using (var db = new LiteDatabase(DBName))
                {
                    var collection = db.GetCollection<Empleado>(TableName);
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
                    var collection = db.GetCollection<Empleado>(TableName);
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
