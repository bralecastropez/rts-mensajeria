using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using RTS_Mensajeria.Models.DB_Model;

namespace RTS_Mensajeria.Controllers
{
    public class ModulosController : BaseController
    {
        private RTS_MensajeriaEntities db = new RTS_MensajeriaEntities();

        // GET: Modulos
        public ActionResult Index()
        {
            var modulo = db.Modulo.Include(m => m.TipoUsuario);
            return View(modulo.ToList());
        }

        // GET: Modulos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Modulo modulo = db.Modulo.Find(id);
            if (modulo == null)
            {
                return HttpNotFound();
            }
            return View(modulo);
        }

        // GET: Modulos/Create
        public ActionResult Create()
        {
            ViewBag.Id_TipoUsuario = new SelectList(db.TipoUsuario, "Id_TipoUsuario", "Nombre");
            return View();
        }

        // POST: Modulos/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id_Modulo,Id_TipoUsuario,Nombre,Enlace,Extra")] Modulo modulo)
        {
            if (ModelState.IsValid)
            {
                db.Modulo.Add(modulo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Id_TipoUsuario = new SelectList(db.TipoUsuario, "Id_TipoUsuario", "Nombre", modulo.Id_TipoUsuario);
            return View(modulo);
        }

        // GET: Modulos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Modulo modulo = db.Modulo.Find(id);
            if (modulo == null)
            {
                return HttpNotFound();
            }
            ViewBag.Id_TipoUsuario = new SelectList(db.TipoUsuario, "Id_TipoUsuario", "Nombre", modulo.Id_TipoUsuario);
            return View(modulo);
        }

        // POST: Modulos/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id_Modulo,Id_TipoUsuario,Nombre,Enlace,Extra")] Modulo modulo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(modulo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Id_TipoUsuario = new SelectList(db.TipoUsuario, "Id_TipoUsuario", "Nombre", modulo.Id_TipoUsuario);
            return View(modulo);
        }

        // GET: Modulos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Modulo modulo = db.Modulo.Find(id);
            if (modulo == null)
            {
                return HttpNotFound();
            }
            return View(modulo);
        }

        // POST: Modulos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Modulo modulo = db.Modulo.Find(id);
            db.Modulo.Remove(modulo);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
