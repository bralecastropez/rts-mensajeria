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
    public class TipoUsuariosController : BaseController
    {
        private RTS_MensajeriaEntities db = new RTS_MensajeriaEntities();

        // GET: TipoUsuarios
        public ActionResult Index()
        {
            return View(db.TipoUsuario.ToList());
        }

        // GET: TipoUsuarios/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoUsuario tipoUsuario = db.TipoUsuario.Find(id);
            if (tipoUsuario == null)
            {
                return HttpNotFound();
            }
            return View(tipoUsuario);
        }

        // GET: TipoUsuarios/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TipoUsuarios/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id_TipoUsuario,Nombre,Estado,Detalle")] TipoUsuario tipoUsuario)
        {
            if (ModelState.IsValid)
            {
                db.TipoUsuario.Add(tipoUsuario);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tipoUsuario);
        }

        // GET: TipoUsuarios/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoUsuario tipoUsuario = db.TipoUsuario.Find(id);
            if (tipoUsuario == null)
            {
                return HttpNotFound();
            }
            return View(tipoUsuario);
        }

        // POST: TipoUsuarios/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id_TipoUsuario,Nombre,Estado,Detalle")] TipoUsuario tipoUsuario)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tipoUsuario).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tipoUsuario);
        }

        // GET: TipoUsuarios/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoUsuario tipoUsuario = db.TipoUsuario.Find(id);
            if (tipoUsuario == null)
            {
                return HttpNotFound();
            }
            return View(tipoUsuario);
        }

        // POST: TipoUsuarios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TipoUsuario tipoUsuario = db.TipoUsuario.Find(id);
            tipoUsuario.Estado = "Inactivo";
            db.Entry(tipoUsuario).State = EntityState.Modified;
            db.SaveChanges();
            /*db.TipoUsuario.Remove(tipoUsuario);
            db.SaveChanges();*/
            return RedirectToAction("Index");
        }
        
        // GET: TipoUsuarios/Active/5
        public ActionResult Active(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoUsuario tipoUsuario = db.TipoUsuario.Find(id);
            if (tipoUsuario == null)
            {
                return HttpNotFound();
            }
            return View(tipoUsuario);
        }

        // POST: TipoUsuarios/Active/5
        [HttpPost, ActionName("Active")]
        [ValidateAntiForgeryToken]
        public ActionResult ActiveConfirmed(int id)
        {
            TipoUsuario tipoUsuario = db.TipoUsuario.Find(id);
            tipoUsuario.Estado = "Activo";
            db.Entry(tipoUsuario).State = EntityState.Modified;
            db.SaveChanges();
            /*db.TipoUsuario.Remove(tipoUsuario);
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
