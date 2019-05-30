using RTS_Mensajeria.Models.DB_Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RTS_Mensajeria.Models
{
    public class BaseVM
    {

        private RTS_MensajeriaEntities db = new RTS_MensajeriaEntities();
        public Usuario usuario { get; set; }

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