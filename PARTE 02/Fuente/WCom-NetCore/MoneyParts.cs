using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WCom_NetCore
{
    public class MoneyParts
    {
        public List<CombinacionesRetorno> build(string parametro)
        {
            decimal[] denominacion = new decimal[] { 0.05m, 0.1m, 0.2m, 0.5m, 1m, 2m, 5m, 10m, 20m, 50m, 100m, 200m };

            //int[] data = new int[] { 0, 1, 2, 3 };
            //decimal[][] expected2 = new decimal[][] { new decimal[] { 0, 1, 2 }, new decimal[] { 0, 1, 3, 45, 2 }, new decimal[] { 0, 2, 3 }, new decimal[] { 1, 2, 3 } };
            //int[,] intArray = { { 1, 1 }, { 1, 2 }, { 1, 3 } };

            decimal valorParametro = Convert.ToDecimal(parametro);

            List<CombinacionesRetorno> objCombinaciones = new List<CombinacionesRetorno>();
            CombinacionesRetorno objConbina = null;

            List<decimal> lstCombina = null;
            for (int i = 0; i < denominacion.Length; i++)
            {
                objConbina = new CombinacionesRetorno();
                lstCombina = new List<decimal>();
                var valorDenominacion = denominacion[i];
                if (valorParametro == valorDenominacion)
                {
                    lstCombina.Add(valorDenominacion);
                    objConbina.lstCombinacion = lstCombina.ToArray();
                    objCombinaciones.Add(objConbina);
                    break;
                }
                else if (valorParametro > valorDenominacion)
                {
                    lstCombina = recalcular(denominacion, lstCombina, valorParametro, i);
                    objConbina.lstCombinacion = lstCombina.ToArray();
                    objCombinaciones.Add(objConbina);
                }
                else
                {
                    break;
                }

            }

            return objCombinaciones;
        }
        public List<decimal> recalcular(decimal[] denominacion, List<decimal> lstCombina, decimal valorParametro, int indice)
        {
            //double suma = miLista.Sum(item => item.precio);
            int logitud = denominacion.Length - 1;
            for (int i = 0; i < denominacion.Length; i++)
            {
                if (i == indice)
                {
                    var valorDenominacion = denominacion[i];
                    if (logitud == indice)
                    {
                        lstCombina = RepetirDenominacion(lstCombina, valorParametro, valorDenominacion);
                        var suma = lstCombina.Sum();
                        if (valorParametro > suma)
                        {
                            lstCombina = recalcular(denominacion, lstCombina, valorParametro, 0);
                            break;
                        }
                    }
                    else
                    {
                        lstCombina = RepetirDenominacion(lstCombina, valorParametro, valorDenominacion);
                        var suma = lstCombina.Sum();
                        if (valorParametro == suma)
                        {
                            break;
                        }
                        else if (valorParametro > suma)
                        {
                            lstCombina = recalcular(denominacion, lstCombina, valorParametro, 0);
                            suma = lstCombina.Sum();
                            if (valorParametro == suma)
                            {
                                break;
                            }
                        }
                        else
                        {

                        }
                    }
                }
            }
            return lstCombina;
        }
        public List<decimal> RepetirDenominacion(List<decimal> lstCombina, decimal valorParametro, decimal valorDenominacion)
        {
            int numMaximoVeces = 1000;
            decimal suma = lstCombina.Sum();
            for (int i = 0; i < numMaximoVeces; i++)
            {
                suma += valorDenominacion;
                if (valorParametro == suma)
                {
                    lstCombina.Add(valorDenominacion);
                    break;
                }
                else if (valorParametro < suma)
                {
                    break;
                }
                else
                {
                    lstCombina.Add(valorDenominacion);
                }
            }
            return lstCombina;
        }
        
    }

    public class CombinacionesRetorno
    {
        //public List<decimal> lstCombinacion { get; set; }
        public decimal[] lstCombinacion { get; set; }
    }
}
