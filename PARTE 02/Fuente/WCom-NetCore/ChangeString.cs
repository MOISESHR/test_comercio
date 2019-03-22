using System;
using System.Collections.Generic;
using System.Text;

namespace WCom_NetCore
{
    public class ChangeString
    {
        public string build(string parametro)
        {
            string cadenaRetorno = string.Empty;
            //string abcMinuscula = "abcdefghijklmnñopqrstuvwxyz.";
            //string abcMayuscula = abcMinuscula.ToUpper();

            int numASCII = 0;
            string caracter = string.Empty;
            string nuevoCar=string.Empty;
            for (int i = 0; i < parametro.Length; i++)
            {
                caracter = parametro.Substring(i, 1);
                char cart1 = Convert.ToChar(caracter);
                numASCII = (int)cart1;                
                //numASCII = Encoding.ASCII.GetBytes(parametro)[i];

                //Caracter ASCCI ADC mayusculas desde 65 al 90 mas 209 (Ñ), minuscula desde 97 al 122 mas 241 (ñ).
                if (numASCII >= 65 && numASCII < 90)
                {
                    nuevoCar = ((char)(numASCII + 1)).ToString();
                }
                else if (numASCII >= 97 && numASCII < 122)
                {
                    nuevoCar = ((char)(numASCII + 1)).ToString();
                }
                else if (numASCII == 209)       //valor:Ñ
                {
                    numASCII = 78;
                    nuevoCar = ((char)(numASCII + 1)).ToString();
                }
                else if (numASCII == 241)       //valor:ñ
                {
                    numASCII = 110;
                    nuevoCar = ((char)(numASCII + 1)).ToString();
                }
                else if (numASCII == 90)       //valor:Z
                {
                    numASCII = 31;
                    nuevoCar = ((char)(numASCII + 1)).ToString();
                }
                else if (numASCII == 122)       //valor:z
                {
                    numASCII = 31;
                    nuevoCar = ((char)(numASCII + 1)).ToString();
                }
                else
                {
                    nuevoCar = ((char)(numASCII)).ToString();
                }

                cadenaRetorno += nuevoCar;
            }

            return cadenaRetorno;
        }
        
    }
}
