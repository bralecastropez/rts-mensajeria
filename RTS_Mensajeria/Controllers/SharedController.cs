using RTS_Mensajeria.Models.DB_Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RTS_Mensajeria.Controllers
{
    public class SharedController : BaseController
    {

        private RTS_MensajeriaEntities db = new RTS_MensajeriaEntities();
        // GET: Shared
        public ActionResult _Layout()
        {
            ViewBag.Valor1 = "Val1";
            ViewBag.Valor2 = "Val2";
            return View();
        }
    }
}