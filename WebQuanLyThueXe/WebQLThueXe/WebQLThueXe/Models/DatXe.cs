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
    
    public partial class DatXe
    {
        public int MaDatXe { get; set; }
        public Nullable<System.DateTime> Ngay { get; set; }
        public int MaKhach { get; set; }
        public string MaLoaiXe { get; set; }
        public Nullable<int> SoLuong { get; set; }
        public System.DateTime NgayHenLay { get; set; }
        public Nullable<bool> TinhTrang { get; set; }
    
        public virtual KHACH KHACH { get; set; }
        public virtual LoaiXe LoaiXe { get; set; }
    }
}
