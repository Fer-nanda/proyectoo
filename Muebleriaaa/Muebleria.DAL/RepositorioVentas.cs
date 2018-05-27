using LiteDB;
using Muebleria.COMMON.Entidades;
using Muebleria.COMMON.interfacez;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Muebleria.DAL
{
    public class RepositorioVentas : IRepositorio<InventarioVentas>
    {
        private string DBName = @"C:\Users\DELL\Desktop\ProyectoFer\mueble\Muebleria.db";
        private string TableName = "Venta";//nombre de la tabla
        public List<InventarioVentas> Lista
        {
            get
            {
                List<InventarioVentas> inventario = new List<InventarioVentas>();
                using (var db = new LiteDatabase(DBName))
                {
                    inventario = db.GetCollection<InventarioVentas>(TableName).FindAll().ToList();
                }
                return inventario;
            }
        }

        public bool Crear(InventarioVentas entidad)
        {
            entidad.Id = Guid.NewGuid().ToString();//este genera un numero aleatorio unico
            try
            {
                using (var db = new LiteDatabase(DBName))
                {
                    var coleccion = db.GetCollection<InventarioVentas>(TableName);
                    coleccion.Insert(entidad);
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool Editar(InventarioVentas entidad)
        {
            try
            {
                using (var db = new LiteDatabase(DBName))
                {
                    var coleccion = db.GetCollection<InventarioVentas>(TableName);
                    coleccion.Update(entidad);
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
                    var coleccion = db.GetCollection<InventarioVentas>(TableName);
                    r = coleccion.Delete(e => e.Id == Id); //expresion landa cambia deun foreach//especifique para encontar los elementos a eliminar
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
