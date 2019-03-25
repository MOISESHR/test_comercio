using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
//using WApp_NetCore_v2.Models;
//using WApp_NetCore_v2.Models.DataAccess;
//using WApp_NetCore_v2.Data;
using WBE_NetCore.Models;
using WBL_NetCore.Logic;
using WApp_NetCore_v2.Services;

namespace WApp_NetCore_v2.Controllers
{
    [Authorize(Roles = "Administrador,Operador1")]
    public class BancoController : Controller
    {
        //private readonly ComercioDbContext _context;
        //public BancoController(ComercioDbContext context)
        //{
        //    _context = context;
        //}

        // GET: Banco
        public ActionResult Index()
        {
            //var result = await _context.Bancos.ToListAsync();

            BancoRespuesta result = new BancoRespuesta();
            result = new BancoService().ListarAll();

            return View(result.Lista);
        }

        // GET: Banco/Create
        public IActionResult Registro(int id = 0)
        {
            if (id == 0)
                return View(new Banco());
            else
            {
                BancoRespuesta result = new BancoRespuesta();
                result = new BancoService().GetReg(id);
                if (result.Entidad == null)
                {
                    return View(new Banco());
                }
                else
                {
                    return View(result.Entidad);
                }
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Registro([Bind("ID,nombre,direccion,fecha_registro")] Banco _banco)
        {
            if (ModelState.IsValid)
            {
                BancoRespuesta result = new BancoRespuesta();

                if (_banco.ID == 0)
                {
                    //result = BancoLogic.Registrar(_banco);
                    result = BancoService.Registrar(_banco);

                }
                else
                {
                    //result = BancoLogic.Actualizar(_banco);
                    result = BancoService.Actualizar(_banco);
                }
                    

                return RedirectToAction(nameof(Index));
            }
            return View(_banco);
        }
        public IActionResult Eliminar(int id)
        {
            try
            {
                //var res = BancoLogic.Eliminar(id);
                var res = BancoService.Eliminar(id);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Registro([Bind("ID,nombre,direccion,fecha_registro")] Banco _banco)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        if (_banco.ID == 0)
        //            _context.Add(_banco);
        //        else
        //            _context.Update(_banco);
        //        await _context.SaveChangesAsync();
        //        return RedirectToAction(nameof(Index));
        //    }
        //    return View(_banco);
        //}
        
        //public async Task<IActionResult> Eliminar(int? id)
        //{
        //    try
        //    {
        //        // TODO: Add delete logic here
        //        var _banco =await _context.Bancos.FindAsync(id);
        //        _context.Bancos.Remove(_banco);
        //        await _context.SaveChangesAsync();
        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}


        // // GET: Banco
        // public ActionResult Index()
        // {
        //     List<Banco> lista = new List<Banco>();
        //     BancoLogic objDA = new BancoLogic();
        //     lista= objDA.GetAllBancos();

        //     return View();
        // }

        // GET: Banco/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Banco/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Banco/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                //var nombreRecibido = nombre;
                //var edadRecibida = edad;
                //return View("Index");

                //TODO: Add insert logic here

                var valores = collection.Keys;

                if (collection.Files.Count > 0)
                {
                    // If the form contains a file, upload it and update the ImageUrl.
                    if (collection.Files[0] != null)
                    {
                        var file = collection.Files[0];

                    }
                }


                foreach (var item in collection)
                {
                    var Key = item.Key;
                    var Value = item.Value[0];
                }

                var nombre = collection["nombre"][0];
                var direccion = collection["direccion"][0];

                Banco oBE = new Banco() {
                    nombre = collection["nombre"][0],
                    direccion = collection["direccion"][0],
                    fecha_registro = DateTime.Now
                };

                var result = BancoLogic.Registrar(oBE);


                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Banco/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Banco/Edit/5
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

        // GET: Banco/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Banco/Delete/5
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