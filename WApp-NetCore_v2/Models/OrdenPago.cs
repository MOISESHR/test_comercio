using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WApp_NetCore_v2.Models
{
    public class OrdenPago
    {
        public int ID { get; set; }
        public int sucursal_id { get; set; }
        public decimal monto { get; set; }
        public string moneda { get; set; }
        public string estado { get; set; }
        public DateTime fecha_registro { get; set; }
    }
}
