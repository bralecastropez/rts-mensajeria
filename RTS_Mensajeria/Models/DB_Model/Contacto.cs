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
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;

    public partial class Contacto : BaseVM
    {
        public int Id_Contacto { get; set; }
        public int Id_Empresa { get; set; }

        [Display(Name = "Nombre completo")]
        [StringLength(100, MinimumLength = 5)]
        [Required(ErrorMessage = "Debe ingresar el nombre del contacto")]
        public string Nombre { get; set; }

        [StringLength(20, MinimumLength = 13)]
        [Display(Name = "No. DPI/CUI")]
        [Required(ErrorMessage = "Debe ingresar el documento de identificación del contacto")]
        public string CUI { get; set; }

        /*[RegularExpression(@"^[a-zA-Z0-9.!#$%&'*+/=?^_`{|}~-]+@[a-zA-Z0-9-]+(?:\.[a-zA-Z0-9-]+)*$",
            ErrorMessage = "El formato del correo es inválido.")]*/
        [EmailAddress]
        [StringLength(100)]
        [Display(Name = "Correo electrónico")]
        public string Correo { get; set; }

        [StringLength(1)]
        [Required(ErrorMessage = "Debe seleccionar si se notificará al contacto")]
        public Nullable<int> Notificar { get; set; }

        [DefaultValue("Activo")]
        [StringLength(8, MinimumLength = 6)]
        public string Estado { get; set; }
    
        public virtual Empresa Empresa { get; set; }
    }
}
