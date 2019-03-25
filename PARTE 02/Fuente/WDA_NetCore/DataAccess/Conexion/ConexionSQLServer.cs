using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.Configuration;

namespace WDA_NetCore.DataAccess.Conexion
{
    public class ConexionSQLServer
    {
        public ConexionSQLServer(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public IConfiguration Configuration { get; }

        public static string DB_Comercio()
        {
            string connectionString = "Server=DESKTOP-9QOH40S\\SQL2014;Database=DB_MHR_Comercio;User ID=sa;Password=moises.dev";
            return connectionString;
        }
        public string DB_Seguridad()
        {
            string connectionString = Configuration.GetConnectionString("ConnectionSeguridad");
            return connectionString;
        }
    }
}
