using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WBE_NetCore.Models;
using WBL_NetCore.Logic;

namespace WAPI_NetCore.Controllers
{
    [Produces("application/json")]
    [Route("api/OrdenPago")]
    public class OrdenPagoController : Controller
    {
        // GET: api/OrdenPago
        [HttpGet("ListarAll")]
        public IEnumerable<OrdenPago> Get()
        {
            return new OrdenPagoLogic().ListarAll();
        }

        // GET: api/OrdenPago/TotalOrdenes/1/Soles
        [Route("TotalOrdenes/{sucursal_id}/{moneda}")]
        [HttpGet]
        public IEnumerable<OrdenPago> Get(int sucursal_id, string moneda)
        {
            OrdenPagoLogic oDa = new OrdenPagoLogic();
            List<OrdenPago> oList = new List<OrdenPago>();

            oList = oDa.Listar(new OrdenPago() { sucursal_id = sucursal_id, moneda = moneda });

            return oList;
        }

        [HttpGet("Listar")]
        public IEnumerable<OrdenPago> Listar([FromBody]OrdenPago datos)
        {
            return new OrdenPagoLogic().Listar(datos);
        }

        // GET: api/OrdenPago/5
        [HttpGet("GetReg/{id}")]
        public OrdenPago Get(int id)
        {
            return new OrdenPagoLogic().GetReg(id);
        }

        // POST: api/OrdenPago
        [HttpPost("Registrar")]
        public int Post([FromBody]OrdenPago datos)
        {
            return OrdenPagoLogic.Registrar(datos);
        }
        
        // PUT: api/OrdenPago/5
        [HttpPut("Actualizar")]
        public int Put([FromBody]OrdenPago datos)
        {
            return OrdenPagoLogic.Actualizar(datos);
        }
        
        // DELETE: api/ApiWithActions/5
        [HttpDelete("Eliminar/{id}")]
        public int Delete(int id)
        {
            return OrdenPagoLogic.Eliminar(id);
        }
    }
}
