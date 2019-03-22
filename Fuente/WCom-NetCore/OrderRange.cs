using System;
using System.Collections.Generic;
using System.Text;

namespace WCom_NetCore
{
    public class OrderRange
    {
        public ColeccionRetorno build(List<int> parametro)
        {
            ColeccionRetorno coleccion = new ColeccionRetorno();
            //int[] parametro = new int[] { 99, 98, 92, 97, 95 };
            //var parametro = new List<int> { 99, 98, 92, 97, 95 };

            parametro.Sort();

            var datos2 = parametro;
            List<int> numPares = new List<int>();
            List<int> numImpares = new List<int>();
            foreach (var item in datos2)
            {
                if ((item % 2) == 0)
                {
                    //Numero par
                    numPares.Add(item);
                    coleccion.listaPares = numPares;
                }
                else
                {
                    //Nuemro impar
                    numImpares.Add(item);
                    coleccion.listaNumeros = numImpares;
                }
            }

            return coleccion;
        }

    }

    public class ColeccionRetorno
    {
        public List<int> listaPares { get; set; }
        public List<int> listaNumeros { get; set; }
    }
}
