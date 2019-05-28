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
    
    public partial class IngresoProveedor
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public IngresoProveedor()
        {
            this.DetalleIngresoProveedor = new HashSet<DetalleIngresoProveedor>();
            this.RutaEntrega = new HashSet<RutaEntrega>();
        }
    
        public int Id_IngresoProveedor { get; set; }
        public string Codigo_IngresoProveedor { get; set; }
        public int Id_Proveedor { get; set; }
        public int Id_HorarioEntrega { get; set; }
        public Nullable<System.DateTime> Fecha_Ingreso { get; set; }
        public Nullable<System.DateTime> Fecha_Creacion { get; set; }
        public string Detalle_Ingreso { get; set; }
        public string Detalle_Producto { get; set; }
        public Nullable<int> No_Paquetes { get; set; }
        public string Elevador { get; set; }
        public string Aprobada { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DetalleIngresoProveedor> DetalleIngresoProveedor { get; set; }
        public virtual HorarioEntrega HorarioEntrega { get; set; }
        public virtual Proveedor Proveedor { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RutaEntrega> RutaEntrega { get; set; }
    }
}
