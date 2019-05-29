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
    public class OficinasController : Controller
    {
        private RTS_MensajeriaEntities db = new RTS_MensajeriaEntities();

        // GET: Oficinas
        public ActionResult Index()
        {
            var oficina = db.Oficina.Include(o => o.Empresa).Include(o => o.Nivel);
            return View(oficina.ToList());
        }
        // GET: Oficinas
        public ActionResult Inactive()
        {
            var oficina = db.Oficina.Include(o => o.Empresa).Include(o => o.Nivel);
            return View(oficina.ToList());
        }

        // GET: Oficinas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Oficina oficina = db.Oficina.Find(id);
            if (oficina == null)
            {
                return HttpNotFound();
            }
            return View(oficina);
        }

        // GET: Oficinas/Create
        public ActionResult Create()
        {
            ViewBag.Id_Empresa = new SelectList(db.Empresa, "Id_Empresa", "Nombre");
            ViewBag.Id_Nivel = new SelectList(db.Nivel, "Id_Nivel", "Descripcion");
            return View();
        }

        // POST: Oficinas/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id_Oficina,Id_Nivel,Id_Empresa,Ocupada,Nombre,Estado")] Oficina oficina)
        {
            if (ModelState.IsValid)
            {
                db.Oficina.Add(oficina);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Id_Empresa = new SelectList(db.Empresa, "Id_Empresa", "Nombre", oficina.Id_Empresa);
            ViewBag.Id_Nivel = new SelectList(db.Nivel, "Id_Nivel", "Descripcion", oficina.Id_Nivel);
            return View(oficina);
        }

        // GET: Oficinas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Oficina oficina = db.Oficina.Find(id);
            if (oficina == null)
            {
                return HttpNotFound();
            }
            ViewBag.Id_Empresa = new SelectList(db.Empresa, "Id_Empresa", "Nombre", oficina.Id_Empresa);
            ViewBag.Id_Nivel = new SelectList(db.Nivel, "Id_Nivel", "Descripcion", oficina.Id_Nivel);
            return View(oficina);
        }

        // POST: Oficinas/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id_Oficina,Id_Nivel,Id_Empresa,Ocupada,Nombre,Estado")] Oficina oficina)
        {
            if (ModelState.IsValid)
            {
                db.Entry(oficina).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Id_Empresa = new SelectList(db.Empresa, "Id_Empresa", "Nombre", oficina.Id_Empresa);
            ViewBag.Id_Nivel = new SelectList(db.Nivel, "Id_Nivel", "Descripcion", oficina.Id_Nivel);
            return View(oficina);
        }

        // GET: Oficinas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Oficina oficina = db.Oficina.Find(id);
            if (oficina == null)
            {
                return HttpNotFound();
            }
            return View(oficina);
        }

        // POST: Oficinas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Oficina oficina = db.Oficina.Find(id);
            oficina.Estado = "Inactivo";
            db.Entry(oficina).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        // GET: Oficinas/Active/5
        public ActionResult Active(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Oficina oficina = db.Oficina.Find(id);
            if (oficina == null)
            {
                return HttpNotFound();
            }
            return View(oficina);
        }

        // POST: Oficinas/Active/5
        [HttpPost, ActionName("Active")]
        [ValidateAntiForgeryToken]
        public ActionResult ActiveConfirmed(int id)
        {
            Oficina oficina = db.Oficina.Find(id);
            oficina.Estado = "Activo";
            db.Entry(oficina).State = EntityState.Modified;
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
