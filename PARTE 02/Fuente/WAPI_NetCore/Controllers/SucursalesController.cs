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
        public SucursalesRespuesta Get()
        {
            SucursalesRespuesta objRespon = new SucursalesRespuesta();
            objRespon.Lista = new SucursalesLogic().ListarAll();
            return objRespon;
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
        public SucursalesRespuesta Listar([FromBody]Sucursales datos)
        {
            SucursalesRespuesta objRespon = new SucursalesRespuesta();
            objRespon.Lista = new SucursalesLogic().Listar(datos);
            return objRespon;
        }

        // GET: api/Sucursales/5
        [HttpGet("GetReg/{id}", Name = "Get")]
        public SucursalesRespuesta Get(int id)
        {
            SucursalesRespuesta objRespon = new SucursalesRespuesta();
            objRespon.Entidad = new SucursalesLogic().GetReg(id);
            return objRespon;
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
