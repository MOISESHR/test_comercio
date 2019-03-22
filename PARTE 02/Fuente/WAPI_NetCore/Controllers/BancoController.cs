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
    [Route("api/Banco")]
    public class BancoController : Controller
    {
        // GET: api/Banco
        [HttpGet("ListarAll")]
        public BancoRespuesta Get()
        {
            return new BancoLogic().ListarAll();
        }

        [HttpGet("Listar")]
        public BancoRespuesta Listar([FromBody]Banco datos)
        {
            return new BancoLogic().Listar(datos);
        }

        // GET: api/Banco/5
        [HttpGet("GetReg/{id}")]
        public BancoRespuesta Get(int id)
        {
            return new BancoLogic().GetReg(id);
        }
        
        // POST: api/Banco
        [HttpPost("Registrar")]
        public BancoRespuesta Post([FromBody]Banco datos)
        {
            return BancoLogic.Registrar(datos);
        }
        
        // PUT: api/Banco/5
        [HttpPut("Actualizar")]
        public BancoRespuesta Put([FromBody]Banco datos)
        {
            return BancoLogic.Actualizar(datos);
        }
        
        // DELETE: api/ApiWithActions/5
        [HttpDelete("Eliminar/{id}")]
        public BancoRespuesta Delete(int id)
        {
            return BancoLogic.Eliminar(id);
        }
    }
}
