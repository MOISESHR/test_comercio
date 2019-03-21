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
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/OrdenPago/1/Soles
        [Route("TotalOrdenes/{sucursal_id}/{moneda}")]
        [HttpGet]
        public IEnumerable<OrdenPago> Get(int sucursal_id, string moneda)
        {
            OrdenPagoLogic oDa = new OrdenPagoLogic();
            List<OrdenPago> oList = new List<OrdenPago>();

            oList = oDa.Listar(new OrdenPago() { sucursal_id = sucursal_id, moneda = moneda });

            return oList;
        }

        // GET: api/OrdenPago/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }
        
        // POST: api/OrdenPago
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }
        
        // PUT: api/OrdenPago/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }
        
        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
