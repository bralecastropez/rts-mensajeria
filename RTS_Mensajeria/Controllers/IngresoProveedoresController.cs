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
    public class IngresoProveedoresController : BaseController
    {
        private RTS_MensajeriaEntities db = new RTS_MensajeriaEntities();

        // GET: IngresoProveedores
        public ActionResult Index()
        {
            var ingresoProveedor = db.IngresoProveedor.Include(i => i.HorarioEntrega).Include(i => i.Proveedor).Include(i => i.Usuario);
            return View(ingresoProveedor.ToList());
        }

        // GET: IngresoProveedores/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            IngresoProveedor ingresoProveedor = db.IngresoProveedor.Find(id);
            if (ingresoProveedor == null)
            {
                return HttpNotFound();
            }
            return View(ingresoProveedor);
        }

        // GET: IngresoProveedores/Create
        public ActionResult Create()
        {
            ViewBag.Id_HorarioEntrega = new SelectList(db.HorarioEntrega, "Id_HorarioEntrega", "Estado");
            ViewBag.Id_Proveedor = new SelectList(db.Proveedor, "Id_Proveedor", "Nombre");
            ViewBag.Id_Usuario = new SelectList(db.Usuario, "Id_Usuario", "Usuario1");
            return View();
        }

        // POST: IngresoProveedores/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id_IngresoProveedor,Codigo_IngresoProveedor,Id_Proveedor,Id_Usuario,Id_HorarioEntrega,Fecha_Ingreso,Fecha_Creacion,Detalle_Ingreso,Detalle_Producto,No_Paquetes,Elevador,Aprobada")] IngresoProveedor ingresoProveedor)
        {
            if (ModelState.IsValid)
            {
                db.IngresoProveedor.Add(ingresoProveedor);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Id_HorarioEntrega = new SelectList(db.HorarioEntrega, "Id_HorarioEntrega", "Estado", ingresoProveedor.Id_HorarioEntrega);
            ViewBag.Id_Proveedor = new SelectList(db.Proveedor, "Id_Proveedor", "Nombre", ingresoProveedor.Id_Proveedor);
            ViewBag.Id_Usuario = new SelectList(db.Usuario, "Id_Usuario", "Usuario1", ingresoProveedor.Id_Usuario);
            return View(ingresoProveedor);
        }

        // GET: IngresoProveedores/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            IngresoProveedor ingresoProveedor = db.IngresoProveedor.Find(id);
            if (ingresoProveedor == null)
            {
                return HttpNotFound();
            }
            ViewBag.Id_HorarioEntrega = new SelectList(db.HorarioEntrega, "Id_HorarioEntrega", "Estado", ingresoProveedor.Id_HorarioEntrega);
            ViewBag.Id_Proveedor = new SelectList(db.Proveedor, "Id_Proveedor", "Nombre", ingresoProveedor.Id_Proveedor);
            ViewBag.Id_Usuario = new SelectList(db.Usuario, "Id_Usuario", "Usuario1", ingresoProveedor.Id_Usuario);
            return View(ingresoProveedor);
        }

        // POST: IngresoProveedores/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id_IngresoProveedor,Codigo_IngresoProveedor,Id_Proveedor,Id_Usuario,Id_HorarioEntrega,Fecha_Ingreso,Fecha_Creacion,Detalle_Ingreso,Detalle_Producto,No_Paquetes,Elevador,Aprobada")] IngresoProveedor ingresoProveedor)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ingresoProveedor).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Id_HorarioEntrega = new SelectList(db.HorarioEntrega, "Id_HorarioEntrega", "Estado", ingresoProveedor.Id_HorarioEntrega);
            ViewBag.Id_Proveedor = new SelectList(db.Proveedor, "Id_Proveedor", "Nombre", ingresoProveedor.Id_Proveedor);
            ViewBag.Id_Usuario = new SelectList(db.Usuario, "Id_Usuario", "Usuario1", ingresoProveedor.Id_Usuario);
            return View(ingresoProveedor);
        }

        // GET: IngresoProveedores/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            IngresoProveedor ingresoProveedor = db.IngresoProveedor.Find(id);
            if (ingresoProveedor == null)
            {
                return HttpNotFound();
            }
            return View(ingresoProveedor);
        }

        // POST: IngresoProveedores/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            IngresoProveedor ingresoProveedor = db.IngresoProveedor.Find(id);
            db.IngresoProveedor.Remove(ingresoProveedor);
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
