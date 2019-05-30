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
    public class DetalleIngresoProveedoresController : BaseController
    {
        private RTS_MensajeriaEntities db = new RTS_MensajeriaEntities();

        // GET: DetalleIngresoProveedores
        public ActionResult Index()
        {
            var detalleIngresoProveedor = db.DetalleIngresoProveedor.Include(d => d.IngresoProveedor);
            return View(detalleIngresoProveedor.ToList());
        }

        // GET: DetalleIngresoProveedores/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DetalleIngresoProveedor detalleIngresoProveedor = db.DetalleIngresoProveedor.Find(id);
            if (detalleIngresoProveedor == null)
            {
                return HttpNotFound();
            }
            return View(detalleIngresoProveedor);
        }

        // GET: DetalleIngresoProveedores/Create
        public ActionResult Create()
        {
            ViewBag.Id_IngresoProveedor = new SelectList(db.IngresoProveedor, "Id_IngresoProveedor", "Codigo_IngresoProveedor");
            return View();
        }

        // POST: DetalleIngresoProveedores/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id_DetalleIngresoProveedor,Id_IngresoProveedor,CodigoDetalle,Detalle_Rechazo,Hora_Entrega,Estado_Entrega")] DetalleIngresoProveedor detalleIngresoProveedor)
        {
            if (ModelState.IsValid)
            {
                db.DetalleIngresoProveedor.Add(detalleIngresoProveedor);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Id_IngresoProveedor = new SelectList(db.IngresoProveedor, "Id_IngresoProveedor", "Codigo_IngresoProveedor", detalleIngresoProveedor.Id_IngresoProveedor);
            return View(detalleIngresoProveedor);
        }

        // GET: DetalleIngresoProveedores/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DetalleIngresoProveedor detalleIngresoProveedor = db.DetalleIngresoProveedor.Find(id);
            if (detalleIngresoProveedor == null)
            {
                return HttpNotFound();
            }
            ViewBag.Id_IngresoProveedor = new SelectList(db.IngresoProveedor, "Id_IngresoProveedor", "Codigo_IngresoProveedor", detalleIngresoProveedor.Id_IngresoProveedor);
            return View(detalleIngresoProveedor);
        }

        // POST: DetalleIngresoProveedores/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id_DetalleIngresoProveedor,Id_IngresoProveedor,CodigoDetalle,Detalle_Rechazo,Hora_Entrega,Estado_Entrega")] DetalleIngresoProveedor detalleIngresoProveedor)
        {
            if (ModelState.IsValid)
            {
                db.Entry(detalleIngresoProveedor).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Id_IngresoProveedor = new SelectList(db.IngresoProveedor, "Id_IngresoProveedor", "Codigo_IngresoProveedor", detalleIngresoProveedor.Id_IngresoProveedor);
            return View(detalleIngresoProveedor);
        }

        // GET: DetalleIngresoProveedores/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DetalleIngresoProveedor detalleIngresoProveedor = db.DetalleIngresoProveedor.Find(id);
            if (detalleIngresoProveedor == null)
            {
                return HttpNotFound();
            }
            return View(detalleIngresoProveedor);
        }

        // POST: DetalleIngresoProveedores/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DetalleIngresoProveedor detalleIngresoProveedor = db.DetalleIngresoProveedor.Find(id);
            db.DetalleIngresoProveedor.Remove(detalleIngresoProveedor);
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
