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
    public class MensajerosController : BaseController
    {
        private RTS_MensajeriaEntities db = new RTS_MensajeriaEntities();

        // GET: Mensajeros
        public ActionResult Index()
        {
            var mensajero = db.Mensajero.Include(m => m.Ingreso);
            return View(mensajero.ToList());
        }

        // GET: Mensajeros/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Mensajero mensajero = db.Mensajero.Find(id);
            if (mensajero == null)
            {
                return HttpNotFound();
            }
            return View(mensajero);
        }

        // GET: Mensajeros/Create
        public ActionResult Create()
        {
            ViewBag.Id_Ingreso = new SelectList(db.Ingreso, "Id_Ingreso", "Codigo_Ingreso");
            return View();
        }

        // POST: Mensajeros/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id_Mensajero,Id_Ingreso,Orden,Tipo_Ingreso,Nombre,CUI,Carnet")] Mensajero mensajero)
        {
            if (ModelState.IsValid)
            {
                db.Mensajero.Add(mensajero);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Id_Ingreso = new SelectList(db.Ingreso, "Id_Ingreso", "Codigo_Ingreso", mensajero.Id_Ingreso);
            return View(mensajero);
        }

        // GET: Mensajeros/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Mensajero mensajero = db.Mensajero.Find(id);
            if (mensajero == null)
            {
                return HttpNotFound();
            }
            ViewBag.Id_Ingreso = new SelectList(db.Ingreso, "Id_Ingreso", "Codigo_Ingreso", mensajero.Id_Ingreso);
            return View(mensajero);
        }

        // POST: Mensajeros/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id_Mensajero,Id_Ingreso,Orden,Tipo_Ingreso,Nombre,CUI,Carnet")] Mensajero mensajero)
        {
            if (ModelState.IsValid)
            {
                db.Entry(mensajero).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Id_Ingreso = new SelectList(db.Ingreso, "Id_Ingreso", "Codigo_Ingreso", mensajero.Id_Ingreso);
            return View(mensajero);
        }

        // GET: Mensajeros/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Mensajero mensajero = db.Mensajero.Find(id);
            if (mensajero == null)
            {
                return HttpNotFound();
            }
            return View(mensajero);
        }

        // POST: Mensajeros/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Mensajero mensajero = db.Mensajero.Find(id);
            db.Mensajero.Remove(mensajero);
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
