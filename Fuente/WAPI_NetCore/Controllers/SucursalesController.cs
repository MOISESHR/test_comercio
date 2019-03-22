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
        [HttpGet("ListarAll")]
        public IEnumerable<Sucursales> Get()
        {
            return new SucursalesLogic().ListarAll();
        }

        // GET: api/Sucursales/4
        [HttpGet("ListarPorBanco/{id}")]
        public IEnumerable<Sucursales> ListarPorBanco([FromRoute] int id)
        {
            List<Sucursales> olist = new List<Sucursales>();
            Sucursales oBe = new Sucursales();
            oBe.banco_id = id;
            SucursalesLogic objDA = new SucursalesLogic();
            olist = objDA.Listar(oBe);

            return olist;
        }

        [HttpGet("Listar")]
        public IEnumerable<Sucursales> Listar([FromBody]Sucursales datos)
        {
            return new SucursalesLogic().Listar(datos);
        }

        // GET: api/Sucursales/5
        [HttpGet("GetReg/{id}", Name = "Get")]
        public Sucursales Get(int id)
        {
            return new SucursalesLogic().GetReg(id);
        }

        // POST: api/Sucursales
        [HttpPost]
        [HttpPost("Registrar")]
        public int Post([FromBody]Sucursales datos)
        {
            return SucursalesLogic.Registrar(datos);
        }

        // PUT: api/Sucursales/5
        [HttpPut("Actualizar")]
        public int Put([FromBody]Sucursales datos)
        {
            return SucursalesLogic.Actualizar(datos);
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("Eliminar/{id}")]
        public int Delete(int id)
        {
            return SucursalesLogic.Eliminar(id);
        }
    }
}
