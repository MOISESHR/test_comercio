using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WApp_NetCore_v2.Data;
//using WApp_NetCore_v2.Models;
//using WApp_NetCore_v2.Models.DataAccess;
using WBE_NetCore.Models;
using WBL_NetCore.Logic;

namespace WApp_NetCore_v2.Controllers
{
    [Authorize(Roles = "Administrador,Operador1")]
    public class SucursalesController : Controller
    {
        private readonly ComercioDbContext _context;

        public SucursalesController(ComercioDbContext context)
        {
            _context = context;
        }

        // GET: Sucursales        
        public ActionResult Index()
        {
            SucursalesLogic objDA = new SucursalesLogic();
            List<Sucursales> result = new List<Sucursales>();
            result = objDA.ListarAll();

            return View(result);
        }
        // GET: Banco/Create
        public async Task<IActionResult> Registro(int id = 0)
        {
            List<SelectListItem> ListBancos = new List<SelectListItem>();
            ListBancos.Add(new SelectListItem
            {
                Text = "Selecciona",
                Value = ""
            });
            var lista = await _context.Banco.ToListAsync();
            foreach (var item in lista)
            {
                ListBancos.Add(new SelectListItem
                {
                    Text = item.nombre,
                    Value = item.ID.ToString()
                });
            }
            ViewBag.ListBancos = ListBancos;

            if (id == 0)
                return View(new Sucursales());
            else
            {
                SucursalesLogic objDA = new SucursalesLogic();
                Sucursales result = new Sucursales();
                result = objDA.GetReg(id);
                if (result == null)
                {
                    return View(new Sucursales());
                }
                else
                {
                    return View(result);
                }
            }

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Registro([Bind("ID,banco_id,nombre,direccion,fecha_registro")] Sucursales _banco)
        {
            if (ModelState.IsValid)
            {
                Sucursales result = new Sucursales();

                int res = 0;
                if (_banco.ID == 0)
                    res = SucursalesLogic.Registrar(_banco);
                else
                    res = SucursalesLogic.Actualizar(_banco);
                return RedirectToAction(nameof(Index));
            }
            return View(_banco);
        }
        public IActionResult Eliminar(int id)
        {
            try
            {
                // TODO: Add delete logic here
                var res = SucursalesLogic.Eliminar(id);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }



        // GET: Sucursales/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Sucursales/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Sucursales/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Sucursales/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Sucursales/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Sucursales/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Sucursales/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}