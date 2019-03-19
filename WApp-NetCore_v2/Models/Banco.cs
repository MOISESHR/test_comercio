using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WApp_NetCore_v2.Models
{
    public class Banco
    {
        public int ID { get; set; }
        [Required]
        [Display(Name ="Nombre")]
        public string nombre { get; set; }
        [Display(Name = "Dirección")]
        public string direccion { get; set; }
        public DateTime fecha_registro { get; set; }
    }
}
