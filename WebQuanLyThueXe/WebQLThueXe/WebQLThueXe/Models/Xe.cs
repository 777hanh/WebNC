//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebQLThueXe.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Xe
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Xe()
        {
            this.XeRas = new HashSet<XeRa>();
            this.XeVaos = new HashSet<XeVao>();
        }
    
        public string MaXe { get; set; }
        public string MaLoaiXe { get; set; }
        public Nullable<int> BienSo { get; set; }
        public string TenXe { get; set; }
        public string MoTa { get; set; }
        public Nullable<bool> TinhTrang { get; set; }
    
        public virtual LoaiXe LoaiXe { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<XeRa> XeRas { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<XeVao> XeVaos { get; set; }
    }
}
