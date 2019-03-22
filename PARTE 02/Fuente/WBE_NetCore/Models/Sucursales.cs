using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WBE_NetCore.Models
{
    public class SucursalesRespuesta
    {
        public DTOHeader DTOHeader { get; set; }
        public Sucursales Entidad { get; set; }
        public List<Sucursales> Lista { get; set; }
    }
    public class Sucursales
    {
        [Key]
        public int ID { get; set; }
        [Display(Name = "Banco")]
        [Required(ErrorMessage = "Campo requerido.")]
        public int banco_id { get; set; }
        [Display(Name = "Nombre Sucursal")]
        [Required(ErrorMessage = "Campo requerido.")]
        public string nombre { get; set; }
        [Display(Name = "Dirección")]
        public string direccion { get; set; }
        [Display(Name = "Fecha de Registro")]
        [Required(ErrorMessage = "Campo requerido.")]
        [DataType(DataType.DateTime)]
        public DateTime fecha_registro { get; set; }

        public Sucursales()
        {
            nombre = string.Empty;
            fecha_registro = DateTime.Now;
            
        }
    }
}
