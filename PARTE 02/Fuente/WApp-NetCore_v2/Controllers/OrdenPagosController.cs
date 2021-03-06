﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WApp_NetCore_v2.Data;
//using WApp_NetCore_v2.Models;
using WBE_NetCore.Models;
using WBL_NetCore.Logic;
using WApp_NetCore_v2.Services;

namespace WApp_NetCore_v2.Controllers
{
    [Authorize(Roles = "Administrador,Operador2")]
    public class OrdenPagosController : Controller
    {
        private readonly ComercioDbContext _context;

        public OrdenPagosController(ComercioDbContext context)
        {
            _context = context;
        }

        // GET: OrdenPagos
        public IActionResult Index()
        {
            OrdenPagoRespuesta result = new OrdenPagoRespuesta();
            result = new OrdenPagoService().ListarAll();

            return View(result.Lista);
            //return View(await _context.OrdenPago.ToListAsync());
        }

        public async Task<IActionResult> Registro(int id = 0)
        {
            List<SelectListItem> ListSucursales = new List<SelectListItem>();
            ListSucursales.Add(new SelectListItem
            {
                Text = "Selecciona",
                Value = ""
            });
            var lista = await _context.Sucursales.ToListAsync();
            foreach (var item in lista)
            {
                ListSucursales.Add(new SelectListItem
                {
                    Text = item.nombre,
                    Value = item.ID.ToString()
                });
            }
            ViewBag.ListSucursales = ListSucursales;

            if (id == 0)
                return View(new OrdenPago());
            else
            {
                OrdenPagoRespuesta result = new OrdenPagoRespuesta();
                result = new OrdenPagoService().GetReg(id);
                if (result.Entidad == null)
                {
                    return View(new OrdenPago());
                }
                else
                {
                    return View(result.Entidad);
                }
            }

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Registro([Bind("ID,sucursal_id,monto,moneda,estado,fecha_pago")] OrdenPago _banco)
        {
            if (ModelState.IsValid)
            {
                OrdenPago result = new OrdenPago();

                int res = 0;
                if (_banco.ID == 0)
                    res = OrdenPagoLogic.Registrar(_banco);
                else
                    res = OrdenPagoLogic.Actualizar(_banco);
                return RedirectToAction(nameof(Index));
            }
            return View(_banco);
        }
        public IActionResult Eliminar(int id)
        {
            try
            {
                // TODO: Add delete logic here
                var res = OrdenPagoLogic.Eliminar(id);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }





        // GET: OrdenPagos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ordenPago = await _context.OrdenPago
                .SingleOrDefaultAsync(m => m.ID == id);
            if (ordenPago == null)
            {
                return NotFound();
            }

            return View(ordenPago);
        }

        // GET: OrdenPagos/Create
        public async Task<IActionResult> Create()
        {
            List<SelectListItem> ListSucursales = new List<SelectListItem>();
            ListSucursales.Add(new SelectListItem
            {
                Text = "Selecciona",
                Value = ""
            });
            var lista = await _context.Sucursales.ToListAsync();
            foreach (var item in lista)
            {
                ListSucursales.Add(new SelectListItem
                {
                    Text = item.nombre,
                    Value = item.ID.ToString()
                });
            }
            ViewBag.ListSucursales = ListSucursales;

            return View();
        }

        //public async Task<IActionResult> Create()
        //{
        //    var dato = new OrdenPago();
        //    List<SelectListItem>  ListSucursales = new List<SelectListItem>();
        //    ListSucursales.Add(new SelectListItem
        //    {
        //        Text = "Select",
        //        Value = ""
        //    });

        //    var lista = await _context.Sucursales.ToListAsync();

        //    foreach (var item in lista)
        //    {
        //        ListSucursales.Add(new SelectListItem
        //        {
        //            Text = item.nombre,
        //            Value = item.ID.ToString()
        //        });
        //    }

        //    dato.ListSucursales = ListSucursales;

        //    return View();
        //}


        // POST: OrdenPagos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,sucursal_id,monto,moneda,estado,fecha_pago")] OrdenPago ordenPago)
        {
            if (ModelState.IsValid)
            {
                _context.Add(ordenPago);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(ordenPago);
        }

        // GET: OrdenPagos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            List<SelectListItem> ListSucursales = new List<SelectListItem>();
            ListSucursales.Add(new SelectListItem
            {
                Text = "Selecciona",
                Value = ""
            });
            var lista = await _context.Sucursales.ToListAsync();
            foreach (var item in lista)
            {
                ListSucursales.Add(new SelectListItem
                {
                    Text = item.nombre,
                    Value = item.ID.ToString()
                });
            }
            ViewBag.ListSucursales = ListSucursales;

            if (id == null)
            {
                return NotFound();
            }

            var ordenPago = await _context.OrdenPago.SingleOrDefaultAsync(m => m.ID == id);
            if (ordenPago == null)
            {
                return NotFound();
            }
            return View(ordenPago);
        }

        // POST: OrdenPagos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,sucursal_id,monto,moneda,estado,fecha_pago")] OrdenPago ordenPago)
        {
            if (id != ordenPago.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(ordenPago);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OrdenPagoExists(ordenPago.ID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(ordenPago);
        }

        // GET: OrdenPagos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ordenPago = await _context.OrdenPago
                .SingleOrDefaultAsync(m => m.ID == id);
            if (ordenPago == null)
            {
                return NotFound();
            }

            return View(ordenPago);
        }

        // POST: OrdenPagos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var ordenPago = await _context.OrdenPago.SingleOrDefaultAsync(m => m.ID == id);
            _context.OrdenPago.Remove(ordenPago);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OrdenPagoExists(int id)
        {
            return _context.OrdenPago.Any(e => e.ID == id);
        }
    }
}
