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
    public class IngresosController : BaseController
    {
        private RTS_MensajeriaEntities db = new RTS_MensajeriaEntities();

        // GET: Ingresos
        public ActionResult Index()
        {
            var ingreso = db.Ingreso.Include(i => i.Empresa).Include(i => i.Proveedor).Include(i => i.Usuario);
            return View(ingreso.ToList());
        }

        // GET: Ingresos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ingreso ingreso = db.Ingreso.Find(id);
            if (ingreso == null)
            {
                return HttpNotFound();
            }
            return View(ingreso);
        }

        // GET: Ingresos/Create
        public ActionResult Create()
        {
            ViewBag.Id_Empresa = new SelectList(db.Empresa, "Id_Empresa", "Nombre");
            ViewBag.Id_Proveedor = new SelectList(db.Proveedor, "Id_Proveedor", "Nombre");
            ViewBag.Id_Usuario = new SelectList(db.Usuario, "Id_Usuario", "Usuario1");
            return View();
        }

        // POST: Ingresos/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id_Ingreso,Codigo_Ingreso,Id_Empresa,Id_Proveedor,Id_Usuario,No_Paquetes,Nombre_Mensajero,CUI_Mensajero,Detalle_Ingreso,Fecha_Ingreso")] Ingreso ingreso)
        {
            if (ModelState.IsValid)
            {
                db.Ingreso.Add(ingreso);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Id_Empresa = new SelectList(db.Empresa, "Id_Empresa", "Nombre", ingreso.Id_Empresa);
            ViewBag.Id_Proveedor = new SelectList(db.Proveedor, "Id_Proveedor", "Nombre", ingreso.Id_Proveedor);
            ViewBag.Id_Usuario = new SelectList(db.Usuario, "Id_Usuario", "Usuario1", ingreso.Id_Usuario);
            return View(ingreso);
        }

        // GET: Ingresos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ingreso ingreso = db.Ingreso.Find(id);
            if (ingreso == null)
            {
                return HttpNotFound();
            }
            ViewBag.Id_Empresa = new SelectList(db.Empresa, "Id_Empresa", "Nombre", ingreso.Id_Empresa);
            ViewBag.Id_Proveedor = new SelectList(db.Proveedor, "Id_Proveedor", "Nombre", ingreso.Id_Proveedor);
            ViewBag.Id_Usuario = new SelectList(db.Usuario, "Id_Usuario", "Usuario1", ingreso.Id_Usuario);
            return View(ingreso);
        }

        // POST: Ingresos/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id_Ingreso,Codigo_Ingreso,Id_Empresa,Id_Proveedor,Id_Usuario,No_Paquetes,Nombre_Mensajero,CUI_Mensajero,Detalle_Ingreso,Fecha_Ingreso")] Ingreso ingreso)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ingreso).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Id_Empresa = new SelectList(db.Empresa, "Id_Empresa", "Nombre", ingreso.Id_Empresa);
            ViewBag.Id_Proveedor = new SelectList(db.Proveedor, "Id_Proveedor", "Nombre", ingreso.Id_Proveedor);
            ViewBag.Id_Usuario = new SelectList(db.Usuario, "Id_Usuario", "Usuario1", ingreso.Id_Usuario);
            return View(ingreso);
        }

        // GET: Ingresos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ingreso ingreso = db.Ingreso.Find(id);
            if (ingreso == null)
            {
                return HttpNotFound();
            }
            return View(ingreso);
        }

        // POST: Ingresos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Ingreso ingreso = db.Ingreso.Find(id);
            db.Ingreso.Remove(ingreso);
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
