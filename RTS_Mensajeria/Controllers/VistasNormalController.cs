using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RTS_Mensajeria.Controllers
{
    public class VistasNormalController : Controller
    {
        // GET: VistasNormal
        public ActionResult AdministrarContactos()
        {
            return View();
        }
        public ActionResult ReactivarContactos()
        {
            return View();
        }

        public ActionResult SolicitudIngresos()
        {
            return View();
        }

        public ActionResult CrearIngreso()
        {
            return View();
        }

        public ActionResult VerSolicitudes()
        {
            return View();
        }

        public ActionResult PaquetesEntregados()
        {
            return View();
        }

        public ActionResult VisitasAutorizadas()
        {
            return View();
        }

        public ActionResult DetalleRechazo()
        {
            return View();
        }
    }
}