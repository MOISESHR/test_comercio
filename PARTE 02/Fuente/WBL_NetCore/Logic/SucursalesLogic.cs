using System;
using System.Collections.Generic;
using System.Text;
using WBE_NetCore.Models;
using WDA_NetCore.DataAccess;

namespace WBL_NetCore.Logic
{
    public class SucursalesLogic
    {
        public static int Registrar(Sucursales oBe)
        {
            return new SucursalesDataAccess().Registrar(oBe);
        }

        public static int Actualizar(Sucursales oBe)
        {
            return new SucursalesDataAccess().Actualizar(oBe);
        }

        public static int Eliminar(Int32 ID)
        {
            return new SucursalesDataAccess().Eliminar(ID);
        }

        public Sucursales GetReg(Int32 ID)
        {
            return new SucursalesDataAccess().GetReg(ID);
        }

        public List<Sucursales> ListarAll()
        {
            return new SucursalesDataAccess().ListarAll();
        }

        public List<Sucursales> Listar(Sucursales oBE)
        {
            return new SucursalesDataAccess().Listar(oBE);
        }
    }
}
