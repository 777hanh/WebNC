using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebQLThueXe.Models
{
    public class ListCar
    {
        testDBEntities db = new testDBEntities();

        public string MaXe { get; set; }
        public string TenLoaiXe { get; set; }
        public Nullable<int> SoCho { get; set; }
        public Nullable<int> BienSo { get; set; }
        public string TenXe { get; set; }
        public string MoTa { get; set; }
        public Nullable<float> GiaLoaiXe { get; set; }
        public Nullable<bool> TinhTrang { get; set; }
        public string HinhAnh { get; set; }

        public void GanGT(Xe x)
        {
            var loai = db.LoaiXes.Where(i => i.MaLoaiXe == x.MaLoaiXe).FirstOrDefault();
            this.MaXe = x.MaXe;
            this.TenLoaiXe = loai.TenLoaiXe;
            this.SoCho = loai.SoCho;
            this.BienSo = x.BienSo;
            this.TenXe = x.TenXe;
            this.MoTa = x.MoTa;
            this.GiaLoaiXe = x.GiaLoaiXe;
            this.TinhTrang=x.TinhTrang;
        }
    }
}