//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace VentasK.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class PRODUCTOS
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PRODUCTOS()
        {
            this.DATOS = new HashSet<DATOS>();
        }
    
        public string PROVEEDOR { get; set; }
        public string PRODUC { get; set; }
        public Nullable<int> PRECIO { get; set; }
        public string CATEGORIA { get; set; }
        public Nullable<int> PRECIO_MIN { get; set; }
        public Nullable<int> PRECIO_MAX { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DATOS> DATOS { get; set; }
    }
}
