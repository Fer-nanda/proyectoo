using System;
using System.Collections.Generic;
using System.Text;

namespace Muebleria.COMMON.Grafica
{
    public class Generadora
    {
        public Generadora()
        {
            Puntos = new List<Puntos>();
        }

        public List<Puntos> Puntos { get; set; }

        public List<Puntos> GeneradorDatos(List<VentasLista> Ventaslista, double limiteInferior, double limiteSuperior, double incremento)
        {
            Puntos = new List<Puntos>();
            double contador = 1;
            foreach (var item in Ventaslista)
            {
                Puntos.Add(new Puntos(contador++, item.cantidad));
            }
            return Puntos;
        }
    }
}
