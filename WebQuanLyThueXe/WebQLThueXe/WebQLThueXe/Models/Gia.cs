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
    
    public partial class Gia
    {
        public string MaGia { get; set; }
        public string MaLoaiXe { get; set; }
        public Nullable<float> GiaXe { get; set; }
    
        public virtual LoaiXe LoaiXe { get; set; }
    }
}
