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
        [HttpGet]
        public IEnumerable<Banco> Get()
        {
            return new BancoLogic().ListarAll();
        }

        // GET: api/Banco/5
        [HttpGet("GetBanco/{id}", Name = "GetBanco")]
        public Banco Get(int id)
        {
            return new BancoLogic().GetReg(id);
        }
        
        // POST: api/Banco
        [HttpPost("Registrar")]
        public int Post([FromBody]Banco datos)
        {
            return BancoLogic.Registrar(datos);
        }
        
        // PUT: api/Banco/5
        [HttpPut("Actualizar")]
        public int Put([FromBody]Banco datos)
        {
            return BancoLogic.Actualizar(datos);
        }
        
        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public int Delete(int id)
        {
            return BancoLogic.Eliminar(id);
        }
    }
}
