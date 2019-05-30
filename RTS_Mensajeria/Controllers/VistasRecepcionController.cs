using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RTS_Mensajeria.Controllers
{
    public class VistasRecepcionController : Controller
    {
        // GET: VistasRecepcion
        public ActionResult AdministrarProveedores()
        {
            return View();
        }
        public ActionResult AdministrarIngresoProveedor()
        {
            return View();
        }
        public ActionResult AdministrarSalidaProveedor()
        {
            return View();
        }

        public ActionResult SolicitudesIngreso()
        {
            return View();
        }

        public ActionResult RechazarSolicitud()
        {
            return View();
        }

        public ActionResult AceptarSolicitud()
        {
            return View();
        }

        public ActionResult IngresoProveedor()
        {
            return View();
        }

        public ActionResult RutaEntrega()
        {
            return View();
        }

        public ActionResult PaquetesEntregados()
        {
            return View();
        }

        public ActionResult VisitasProveedorAutorizadas()
        {
            return View();
        }
        
        public ActionResult VisitasProveedor()
        {
            return View();
        }
    }
}