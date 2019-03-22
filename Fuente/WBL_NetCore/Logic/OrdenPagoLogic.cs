using System;
using System.Collections.Generic;
using System.Text;
using WBE_NetCore.Models;
using WDA_NetCore.DataAccess;

namespace WBL_NetCore.Logic
{
    public class OrdenPagoLogic
    {
        public static int Registrar(OrdenPago oBe)
        {
            return new OrdenPagoDataAccess().Registrar(oBe);
        }

        public static int Actualizar(OrdenPago oBe)
        {
            return new OrdenPagoDataAccess().Actualizar(oBe);
        }

        public static int Eliminar(Int32 ID)
        {
            return new OrdenPagoDataAccess().Eliminar(ID);
        }

        public OrdenPago GetReg(Int32 ID)
        {
            return new OrdenPagoDataAccess().GetReg(ID);
        }

        public List<OrdenPago> ListarAll()
        {
            return new OrdenPagoDataAccess().ListarAll();
        }

        public List<OrdenPago> Listar(OrdenPago oBE)
        {
            return new OrdenPagoDataAccess().Listar(oBE);
        }
    }
}
