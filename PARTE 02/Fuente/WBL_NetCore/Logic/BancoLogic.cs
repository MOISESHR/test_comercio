using System;
using System.Collections.Generic;
using System.Text;
using WBE_NetCore.Models;
using WDA_NetCore.DataAccess;

namespace WBL_NetCore.Logic
{
    public class BancoLogic
    {
        public static BancoRespuesta Registrar(Banco oBe)
        {
            return new BancoDataAccess().Registrar(oBe);
        }

        public static BancoRespuesta Actualizar(Banco oBe)
        {
            return new BancoDataAccess().Actualizar(oBe);
        }

        public static BancoRespuesta Eliminar(Int32 ID)
        {
            return new BancoDataAccess().Eliminar(ID);
        }

        public BancoRespuesta GetReg(Int32 ID)
        {
            return new BancoDataAccess().GetReg(ID);
        }

        public BancoRespuesta ListarAll()
        {
            return new BancoDataAccess().ListarAll();
        }

        public BancoRespuesta Listar(Banco oBE)
        {
            return new BancoDataAccess().Listar(oBE);
        }
    }
}
