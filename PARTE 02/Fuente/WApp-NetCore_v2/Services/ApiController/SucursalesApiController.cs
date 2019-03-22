using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WApp_NetCore_v2.Data;
//using WApp_NetCore_v2.Models;
//using WApp_NetCore_v2.Models.DataAccess;
using WBE_NetCore.Models;
using WBL_NetCore.Logic;

namespace WApp_NetCore_v2.Services.ApiController
{
    [Produces("application/json")]
    [Route("api/SucursalesApi")]
    public class SucursalesApiController : Controller
    {
        private readonly ComercioDbContext _context;

        public SucursalesApiController(ComercioDbContext context)
        {
            _context = context;
        }

        // GET: api/SucursalesApi
        [HttpGet]
        public IEnumerable<Sucursales> GetSucursales()
        {
            return _context.Sucursales;
        }
        // GET: api/SucursalesApi
        [Route("Listar")]
        [HttpGet]
        public IEnumerable<Sucursales> ObtenerSucursales(string nombre)
        {
            List<Sucursales> olist = new List<Sucursales>();
            Sucursales oBe = new Sucursales();
            oBe.nombre = nombre;
            SucursalesLogic objDA = new SucursalesLogic();
            olist = objDA.Listar(oBe);

            return olist;
        }
        // GET: api/SucursalesApi
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
        //// GET: api/SucursalesApi/5
        //[HttpGet("{id}")]
        //public async Task<IActionResult> GetSucursales([FromRoute] int id)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    var sucursales = await _context.Sucursales.SingleOrDefaultAsync(m => m.ID == id);

        //    if (sucursales == null)
        //    {
        //        return NotFound();
        //    }

        //    return Ok(sucursales);
        //}

        // PUT: api/SucursalesApi/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSucursales([FromRoute] int id, [FromBody] Sucursales sucursales)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != sucursales.ID)
            {
                return BadRequest();
            }

            _context.Entry(sucursales).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SucursalesExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/SucursalesApi
        [HttpPost]
        public async Task<IActionResult> PostSucursales([FromBody] Sucursales sucursales)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Sucursales.Add(sucursales);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSucursales", new { id = sucursales.ID }, sucursales);
        }

        // DELETE: api/SucursalesApi/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSucursales([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var sucursales = await _context.Sucursales.SingleOrDefaultAsync(m => m.ID == id);
            if (sucursales == null)
            {
                return NotFound();
            }

            _context.Sucursales.Remove(sucursales);
            await _context.SaveChangesAsync();

            return Ok(sucursales);
        }

        private bool SucursalesExists(int id)
        {
            return _context.Sucursales.Any(e => e.ID == id);
        }
    }
}