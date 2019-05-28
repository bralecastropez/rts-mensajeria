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
    public class NivelesController : Controller
    {
        private RTS_MensajeriaEntities db = new RTS_MensajeriaEntities();

        // GET: Niveles
        public ActionResult Index()
        {
            return View(db.Nivel.ToList());
        }

        // GET: Niveles
        public ActionResult Inactive()
        {
            return View(db.Nivel.ToList());
        }

        // GET: Niveles/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Nivel nivel = db.Nivel.Find(id);
            if (nivel == null)
            {
                return HttpNotFound();
            }
            return View(nivel);
        }

        // GET: Niveles/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Niveles/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id_Nivel,Ubicacion,Descripcion,Estado")] Nivel nivel)
        {
            if (ModelState.IsValid)
            {
                db.Nivel.Add(nivel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(nivel);
        }

        // GET: Niveles/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Nivel nivel = db.Nivel.Find(id);
            if (nivel == null)
            {
                return HttpNotFound();
            }
            return View(nivel);
        }

        // POST: Niveles/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id_Nivel,Ubicacion,Descripcion,Estado")] Nivel nivel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(nivel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(nivel);
        }

        // GET: Niveles/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Nivel nivel = db.Nivel.Find(id);
            if (nivel == null)
            {
                return HttpNotFound();
            }
            return View(nivel);
        }

        // POST: Niveles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Nivel nivel = db.Nivel.Find(id);
            nivel.Estado = "Inactivo";
            db.Entry(nivel).State = EntityState.Modified;
            db.SaveChanges();
            /*db.Nivel.Remove(nivel);
            db.SaveChanges();*/
            return RedirectToAction("Index");
        }

        // GET: Niveles/Active/5
        public ActionResult Active(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Nivel nivel = db.Nivel.Find(id);
            if (nivel == null)
            {
                return HttpNotFound();
            }
            return View(nivel);
        }

        // POST: Niveles/Active/5
        [HttpPost, ActionName("Active")]
        [ValidateAntiForgeryToken]
        public ActionResult ActiveConfirmed(int id)
        {
            Nivel nivel = db.Nivel.Find(id);
            nivel.Estado = "Activo";
            db.Entry(nivel).State = EntityState.Modified;
            db.SaveChanges();
            /*db.Nivel.Remove(nivel);
            db.SaveChanges();*/
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
