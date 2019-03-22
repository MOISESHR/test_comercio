using System;
using System.Collections.Generic;
using System.Text;
using WBE_NetCore.Models;
using WDA_NetCore.DataAccess;

namespace WBL_NetCore.Logic
{
    public class BancoLogic
    {
        public static int Registrar(Banco oBe)
        {
            return new BancoDataAccess().Registrar(oBe);
        }

        public static int Actualizar(Banco oBe)
        {
            return new BancoDataAccess().Actualizar(oBe);
        }

        public static int Eliminar(Int32 ID)
        {
            return new BancoDataAccess().Eliminar(ID);
        }

        public Banco GetReg(Int32 ID)
        {
            return new BancoDataAccess().GetReg(ID);
        }

        public List<Banco> ListarAll()
        {
            return new BancoDataAccess().ListarAll();
        }

        public List<Banco> Listar(Banco oBE)
        {
            return new BancoDataAccess().Listar(oBE);
        }
    }
}
