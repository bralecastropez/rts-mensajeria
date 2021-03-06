//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace RTS_Mensajeria.Models.DB_Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class Modulo : BaseVM
    {
        public int Id_Modulo { get; set; }

        [Display(Name = "Tipo de usuario")]
        [Required(ErrorMessage = "Debe seleccionar el tipo de usuario")]
        public int Id_TipoUsuario { get; set; }

        [Display(Name = "Nombre del módulo")]
        [Required(ErrorMessage = "Debe ingresar el nombre del módulo")]
        public string Nombre { get; set; }

        [Display(Name = "Enlace")]
        [Required(ErrorMessage = "Debe ingresar el enlace")]
        public string Enlace { get; set; }

        [Display(Name = "Detalles extra")]
        public string Extra { get; set; }
    
        public virtual TipoUsuario TipoUsuario { get; set; }
    }
}
