using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace WApp_NetCore_v2.Models.DataAccess
{
    public class ConexionData
    {
        public ConexionData(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public IConfiguration Configuration { get; }

        public static string DB_Comercio()
        {
            string connectionString = "Server=DESKTOP-9QOH40S\\SQL2014;Database=DB_MHR_Comercio;User ID=sa;Password=moises.dev";
            //return ConfigurationManager.ConnectionStrings["dddd"].ConnectionString;
            return connectionString;
        }
        public string DB_Seguridad()
        {
            //string connectionString = "Server=DESKTOP-9QOH40S\\SQL2014;Database=DB_Comercio;User ID=sa;Password=moises.dev";
            string connectionString = Configuration.GetConnectionString("DevConnection");
            //return ConfigurationManager.ConnectionStrings["dddd"].ConnectionString;
            return connectionString;
        }
    }
}
