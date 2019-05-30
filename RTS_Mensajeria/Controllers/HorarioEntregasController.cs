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
    public class HorarioEntregasController : BaseController
    {
        private RTS_MensajeriaEntities db = new RTS_MensajeriaEntities();

        // GET: HorarioEntregas
        public ActionResult Index()
        {
            return View(db.HorarioEntrega.ToList());
        }
        // GET: HorarioEntregas
        public ActionResult Inactive()
        {
            return View(db.HorarioEntrega.ToList());
        }

        // GET: HorarioEntregas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HorarioEntrega horarioEntrega = db.HorarioEntrega.Find(id);
            if (horarioEntrega == null)
            {
                return HttpNotFound();
            }
            return View(horarioEntrega);
        }

        // GET: HorarioEntregas/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: HorarioEntregas/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id_HorarioEntrega,Hora_Entrega,Hora_Salida,Estado")] HorarioEntrega horarioEntrega)
        {
            if (ModelState.IsValid)
            {
                db.HorarioEntrega.Add(horarioEntrega);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(horarioEntrega);
        }

        // GET: HorarioEntregas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HorarioEntrega horarioEntrega = db.HorarioEntrega.Find(id);
            if (horarioEntrega == null)
            {
                return HttpNotFound();
            }
            return View(horarioEntrega);
        }

        // POST: HorarioEntregas/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id_HorarioEntrega,Hora_Entrega,Hora_Salida,Estado")] HorarioEntrega horarioEntrega)
        {
            if (ModelState.IsValid)
            {
                db.Entry(horarioEntrega).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(horarioEntrega);
        }

        // GET: HorarioEntregas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HorarioEntrega horarioEntrega = db.HorarioEntrega.Find(id);
            if (horarioEntrega == null)
            {
                return HttpNotFound();
            }
            return View(horarioEntrega);
        }

        // POST: HorarioEntregas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            HorarioEntrega horarioEntrega = db.HorarioEntrega.Find(id);
            horarioEntrega.Estado = "Inactivo";
            db.Entry(horarioEntrega).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        // GET: HorarioEntregas/Active/6
        public ActionResult Active(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HorarioEntrega horarioEntrega = db.HorarioEntrega.Find(id);
            if (horarioEntrega == null)
            {
                return HttpNotFound();
            }
            return View(horarioEntrega);
        }

        // POST: HorarioEntregas/Active/6
        [HttpPost, ActionName("Active")]
        [ValidateAntiForgeryToken]
        public ActionResult ActiveConfirmed(int id)
        {
            HorarioEntrega horarioEntrega = db.HorarioEntrega.Find(id);
            horarioEntrega.Estado = "Activo";
            db.Entry(horarioEntrega).State = EntityState.Modified;
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
