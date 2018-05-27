using Muebleria.COMMON.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace Muebleria.COMMON.interfacez
{
    public interface IManejadorGenerico<T> where T : Base
    {
        bool Agregar(T entidad);
        List<T> Lista { get; }
        bool Eliminar(string Id);
        bool Modificar(T entidad);
        T Buscador(string Id);
    }
}
