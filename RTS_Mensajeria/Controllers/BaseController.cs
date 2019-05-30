using RTS_Mensajeria.Models;
using RTS_Mensajeria.Models.DB_Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RTS_Mensajeria.Controllers
{
    public class BaseController : Controller
    {
        private RTS_MensajeriaEntities db = new RTS_MensajeriaEntities();

        protected override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            if (filterContext.Result is ViewResultBase)//Gets ViewResult and PartialViewResult
            {
                object viewModel = ((ViewResultBase)filterContext.Result).Model;

                if (viewModel != null && viewModel is BaseVM)
                {
                    BaseVM baseVM = viewModel as BaseVM;

                    var userId = User.Identity;
                    var user = obtenerUsuario(userId.Name);
                    var usuario = obtenerUsuario(userId.Name);
                    var model = new Models.BaseVM
                    {
                        usuario = obtenerUsuario(userId.Name)
                    };
                }
            }

            base.OnActionExecuted(filterContext);//this is important!
        }

        [NonAction]
        public Usuario obtenerUsuario(String userId)
        {
            var usuario = new Usuario();
            usuario = db.Usuario
                    .Where(m => m.Correo == userId)
                    .Select(m => m)
                    .SingleOrDefault();
            return usuario;
        }
    }
}