using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RTS_Mensajeria.Controllers
{
    public class HomeController : BaseController
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "ERP Mensajeria, en desarrollo.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Brandon Alexander";

            return View();
        }
    }
}