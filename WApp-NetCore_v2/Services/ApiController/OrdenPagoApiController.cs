using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WApp_NetCore_v2.Models;
using WApp_NetCore_v2.Models.DataAccess;

namespace WApp_NetCore_v2.Services.ApiController
{
    [Produces("application/json")]
    [Route("api/OrdenPagoApi")]
    public class OrdenPagoApiController : Controller
    {
        // GET: api/OrdenPagoApi
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        [Route("TotalOrdenes/{sucursal_id}/{moneda}")]
        [HttpGet]
        public IEnumerable<OrdenPago> Get(int sucursal_id, string moneda)
        {
            OrdenPagoDataAccess oDa = new OrdenPagoDataAccess();
            List<OrdenPago> oList = new List<OrdenPago>();

            oList = oDa.Listar(new OrdenPago() { sucursal_id = sucursal_id, moneda = moneda });

            return oList;
        }

        //[HttpGet]
        //public IEnumerable<OrdenPago> Lista([FromBody]OrdenPago item)
        //{
        //    OrdenPagoDataAccess oDa = new OrdenPagoDataAccess();
        //    List<OrdenPago> oList = new List<OrdenPago>();

        //    oList = oDa.Listar(new OrdenPago() { sucursal_id = item.sucursal_id, moneda = item.moneda});

        //    return oList;
        //}

        // GET: api/OrdenPagoApi/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }
        
        // POST: api/OrdenPagoApi
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }
        
        // PUT: api/OrdenPagoApi/5
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
