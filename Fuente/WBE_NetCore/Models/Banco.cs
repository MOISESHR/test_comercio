using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WBE_NetCore.Models
{
    public class Banco
    {
        [Key]
        public int ID { get; set; }
        // [Column(TypeName = "nvarchar(50)")]
        [Required(ErrorMessage = "Campo requerido.")]
        [Display(Name ="Nombre Banco")]
        public string nombre { get; set; }
        // [Column(TypeName = "nvarchar(50)")]
        [Display(Name = "Dirección")]
        public string direccion { get; set; }
        // [Column(TypeName = "Date")]
        [Display(Name = "Fecha de Registro")]
        [DataType(DataType.Date)]
        [Required(ErrorMessage = "Campo requerido.")]
        public DateTime fecha_registro { get; set; }
        public Banco()
        {
            nombre = string.Empty;
            fecha_registro = DateTime.Now;

        }
    }
}
