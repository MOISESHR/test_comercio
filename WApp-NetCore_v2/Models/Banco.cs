﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WApp_NetCore_v2.Models
{
    public class Banco
    {
        public int ID { get; set; }
        public string nombre { get; set; }
        public string direccion { get; set; }
        public DateTime fecha_registro { get; set; }
    }
}
