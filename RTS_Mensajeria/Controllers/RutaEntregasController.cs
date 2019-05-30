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
    public class RutaEntregasController : BaseController
    {
        private RTS_MensajeriaEntities db = new RTS_MensajeriaEntities();

        // GET: RutaEntregas
        public ActionResult Index()
        {
            var rutaEntrega = db.RutaEntrega.Include(r => r.Ingreso).Include(r => r.IngresoProveedor);
            return View(rutaEntrega.ToList());
        }

        // GET: RutaEntregas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RutaEntrega rutaEntrega = db.RutaEntrega.Find(id);
            if (rutaEntrega == null)
            {
                return HttpNotFound();
            }
            return View(rutaEntrega);
        }

        // GET: RutaEntregas/Create
        public ActionResult Create()
        {
            ViewBag.Id_Ingreso = new SelectList(db.Ingreso, "Id_Ingreso", "Codigo_Ingreso");
            ViewBag.Id_SolicitudProveedor = new SelectList(db.IngresoProveedor, "Id_IngresoProveedor", "Codigo_IngresoProveedor");
            return View();
        }

        // POST: RutaEntregas/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id_RutaEntrega,Id_Ingreso,Id_SolicitudProveedor,Orden,Anticipada")] RutaEntrega rutaEntrega)
        {
            if (ModelState.IsValid)
            {
                db.RutaEntrega.Add(rutaEntrega);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Id_Ingreso = new SelectList(db.Ingreso, "Id_Ingreso", "Codigo_Ingreso", rutaEntrega.Id_Ingreso);
            ViewBag.Id_SolicitudProveedor = new SelectList(db.IngresoProveedor, "Id_IngresoProveedor", "Codigo_IngresoProveedor", rutaEntrega.Id_SolicitudProveedor);
            return View(rutaEntrega);
        }

        // GET: RutaEntregas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RutaEntrega rutaEntrega = db.RutaEntrega.Find(id);
            if (rutaEntrega == null)
            {
                return HttpNotFound();
            }
            ViewBag.Id_Ingreso = new SelectList(db.Ingreso, "Id_Ingreso", "Codigo_Ingreso", rutaEntrega.Id_Ingreso);
            ViewBag.Id_SolicitudProveedor = new SelectList(db.IngresoProveedor, "Id_IngresoProveedor", "Codigo_IngresoProveedor", rutaEntrega.Id_SolicitudProveedor);
            return View(rutaEntrega);
        }

        // POST: RutaEntregas/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id_RutaEntrega,Id_Ingreso,Id_SolicitudProveedor,Orden,Anticipada")] RutaEntrega rutaEntrega)
        {
            if (ModelState.IsValid)
            {
                db.Entry(rutaEntrega).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Id_Ingreso = new SelectList(db.Ingreso, "Id_Ingreso", "Codigo_Ingreso", rutaEntrega.Id_Ingreso);
            ViewBag.Id_SolicitudProveedor = new SelectList(db.IngresoProveedor, "Id_IngresoProveedor", "Codigo_IngresoProveedor", rutaEntrega.Id_SolicitudProveedor);
            return View(rutaEntrega);
        }

        // GET: RutaEntregas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RutaEntrega rutaEntrega = db.RutaEntrega.Find(id);
            if (rutaEntrega == null)
            {
                return HttpNotFound();
            }
            return View(rutaEntrega);
        }

        // POST: RutaEntregas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            RutaEntrega rutaEntrega = db.RutaEntrega.Find(id);
            db.RutaEntrega.Remove(rutaEntrega);
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
