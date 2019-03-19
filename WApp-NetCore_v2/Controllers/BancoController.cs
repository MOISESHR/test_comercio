using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WApp_NetCore_v2.Models;

namespace WApp_NetCore_v2.Controllers
{
    [Authorize(Roles = "Administrador")]
    public class BancoController : Controller
    {
        // GET: Banco
        public ActionResult Index()
        {
            List<Banco> lista = new List<Banco>();
            BancoDataAccess objDA = new BancoDataAccess();
            //lista= objDA.GetAllBancos();


            return View();
        }

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

                var result = new BancoDataAccess().AddBanco(oBE);


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