using System;
using System.Collections.Generic;
using System.Text;
using WCom_NetCore;

namespace WBE_NetCore.Models
{
    public class DTOHeader
    {
        public int CodigoOK_BD { get; set; }
        public int CodigoOK_WS { get; set; }
        public string CodigoRetorno { get; set; }
        public string DescRetorno { get; set; }
        public DTOHeader()
        {
            CodigoOK_BD = Constantes.Exito.NoOK;     //0:No OK,1:OK,-1:Error ejecucion
            CodigoOK_WS = Constantes.Exito.NoOK;     //0:No OK,1:OK,-1:Error ejecucion
            CodigoRetorno = string.Empty;
            DescRetorno = string.Empty;
        }
    }
}
