using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RTS_Mensajeria.Controllers
{
    public class VistasAdminController : Controller
    {
        // GET: VistasAdmin
        public ActionResult IngresoProveedores()
        {
            return View();
        }

        public ActionResult AprobarSolicitud()
        {
            return View();
        }

        public ActionResult RechazarSolicitud()
        {
            return View();
        }

        public ActionResult EntregasAnticipadas()
        {
            return View();
        }

        public ActionResult EntregasNormales()
        {
            return View();
        }

        public ActionResult VerEntrega()
        {
            return View();
        }
    }
}