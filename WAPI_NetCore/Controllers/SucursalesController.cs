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
    [Route("api/Sucursales")]
    public class SucursalesController : Controller
    {
        // GET: api/Sucursales
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "Probar con ", "api/Sucursales/2" };
        }

        // GET: api/Sucursales/4
        [Route("ListarPorBanco")]
        [HttpGet("{id}")]
        public IEnumerable<Sucursales> ListarPorBanco([FromRoute] int id)
        {
            List<Sucursales> olist = new List<Sucursales>();
            Sucursales oBe = new Sucursales();
            oBe.banco_id = id;
            SucursalesLogic objDA = new SucursalesLogic();
            olist = objDA.Listar(oBe);

            return olist;
        }

        //// GET: api/Sucursales/5
        //[HttpGet("{id}", Name = "Get")]
        //public string Get(int id)
        //{
        //    return "value";
        //}
        
        // POST: api/Sucursales
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }
        
        // PUT: api/Sucursales/5
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
