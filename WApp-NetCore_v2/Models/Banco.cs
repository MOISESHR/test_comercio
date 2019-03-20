using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WApp_NetCore_v2.Models
{
    public class Banco
    {
        [Key]
        public int ID { get; set; }
        // [Column(TypeName = "nvarchar(50)")]
        [Required]
        [Display(Name ="Nombre")]
        public string nombre { get; set; }
        // [Column(TypeName = "nvarchar(50)")]
        [Display(Name = "Dirección")]
        public string direccion { get; set; }
        // [Column(TypeName = "Date")]
        [Display(Name = "Fecha de Registro")]
        public DateTime fecha_registro { get; set; }
    }
}
