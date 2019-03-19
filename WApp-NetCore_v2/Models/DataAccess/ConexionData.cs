using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WApp_NetCore_v2.Models.DataAccess
{
    public class ConexionData
    {
        public static string DB_Comercio()
        {
            string connectionString = "Server=CHPROV177-027\\SQL2014EX;Database=DB_Comercio;User ID=sa;Password=moises.dev";
            //return ConfigurationManager.ConnectionStrings["SOL_CONTABILIDADConnectionString"].ConnectionString;
            return connectionString;
        }
    }
}
