using Muebleria.COMMON.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace Muebleria.COMMON.interfacez
{
    public interface IRepositorio<T> where T : Base
    {
        bool Crear(T entidad);
        bool Editar(T entidad);
        bool Eliminar(string Id);
        List<T> Lista { get; }
    }
}
