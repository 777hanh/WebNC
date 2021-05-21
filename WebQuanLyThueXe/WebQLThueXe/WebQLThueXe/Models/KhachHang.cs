using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace WebQLThueXe.Models
{
    public class KhachHang
    {
        public int maKH=1;
        private string tenKhach;
        private string diaChi;
        private string mail;
        private int cmnd;
        private string sdt;
        private string tenNganHang;
        private string stk;
        private string password;
        //private static int stt;
        public KhachHang()
        {
            maKH++;
            diaChi = "";
            mail = "";
            cmnd = 0;
            tenNganHang = "";
            stk = "";

        }
        [Required(ErrorMessage = "It's not empty")]
        [Display(Name = "ften")]
        public string TenKhach { get => tenKhach; set => tenKhach = value; }
       
        public string DiaChi { get => diaChi; set => diaChi = value; }
        public string Mail { get => mail; set => mail = value; }
        public int Cmnd { get => cmnd; set => cmnd = value; }
        [Required(ErrorMessage = "It's not empty")]
        [Display(Name = "fsdt")]
        public string Sdt { get => sdt; set => sdt = value; }
        
        public string TenNganHang { get => tenNganHang; set => tenNganHang = value; }
        public string Stk { get => stk; set => stk = value; }

        [Required(ErrorMessage = "It's not empty")]
        [Display(Name = "password")]
        public string Password { get => password; set => password = value; }

    }
}