using Microsoft.AspNet.Identity;
using RTS_Mensajeria.Models.DB_Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RTS_Mensajeria.Controllers
{
    [Authorize]
    public class DashboardController : BaseController
    {

        private RTS_MensajeriaEntities db = new RTS_MensajeriaEntities();

        // GET: Dashboard
        public ActionResult Index()
        {
            var userId = User.Identity;
            var model = new Models.DashboardViewModel
            {
                usuario = obtenerUsuario(userId.Name)
            };
            return View(model);
        }

        // GET: Dashboard
        public ActionResult _Layout()
        {
            var userId = User.Identity;
            ViewBag.model = new Models.BaseVM
            {
                usuario = obtenerUsuario(userId.Name)
            };
            return View();
        }

        // GET: Dashboard/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Dashboard/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Dashboard/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Dashboard/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Dashboard/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Dashboard/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Dashboard/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        [NonAction]
        public Usuario obtenerUsuario(String userId)
        {
            var usuario = new Usuario();
            usuario = db.Usuario
                    .Where(m => m.Correo == userId)
                    .Select(m => m)
                    .SingleOrDefault();
            return usuario;
        }
    }
}
