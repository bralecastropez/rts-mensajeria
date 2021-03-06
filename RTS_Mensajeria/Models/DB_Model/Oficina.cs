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

    public partial class Oficina : BaseVM
    {
        public int Id_Oficina { get; set; }
        public int Id_Nivel { get; set; }
        public Nullable<int> Id_Empresa { get; set; }

        [Display(Name = "Ocupada")]
        [DefaultValue(0)]
        [Required(ErrorMessage = "Debe seleccionar si está ocupada o no")]
        public Nullable<int> Ocupada { get; set; }

        [StringLength(200)]
        [Display(Name = "Nombre")]
        [Required(ErrorMessage = "Debe ingresar nombre de la oficina")]
        public string Nombre { get; set; }

        [DefaultValue("Activo")]
        [StringLength(8, MinimumLength = 6)]
        public string Estado { get; set; }
    
        public virtual Empresa Empresa { get; set; }
        public virtual Nivel Nivel { get; set; }
    }
}
