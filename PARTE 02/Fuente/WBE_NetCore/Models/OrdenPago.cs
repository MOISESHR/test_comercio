using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WBE_NetCore.Models
{
    public class OrdenPagoRespuesta
    {
        public DTOHeader DTOHeader { get; set; }
        public OrdenPago Entidad { get; set; }
        public List<OrdenPago> Lista { get; set; }
    }
    public class OrdenPago
    {
        [Key]
        public int ID { get; set; }
        [Required(ErrorMessage = "Campo requerido.")]
        [Display(Name = "Sucursal")]
        public int sucursal_id { get; set; }
        [Required(ErrorMessage = "Campo requerido.")]
        [Display(Name = "Monto")]
        public decimal monto { get; set; }
        [Required(ErrorMessage = "Campo requerido.")]
        [Display(Name = "Moneda")]
        public string moneda { get; set; }
        [Required(ErrorMessage = "Campo requerido.")]
        [Display(Name = "Estado")]
        public string estado { get; set; }
        [Display(Name = "Fecha de Pago")]
        [Required(ErrorMessage = "Campo requerido.")]
        [DataType(DataType.DateTime)]
        public DateTime fecha_pago { get; set; }
        public OrdenPago()
        {
            monto = 0;
            moneda = "Soles";
            estado = "Pagada";
            fecha_pago = DateTime.Now;
        }
    }
}
