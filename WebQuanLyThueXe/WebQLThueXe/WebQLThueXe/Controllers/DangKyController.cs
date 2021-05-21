using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebQLThueXe.Models;
namespace WebQLThueXe.Controllers
{
    public class DangKyController : Controller
    {
        // GET: DangKy
        public ActionResult Index()
        {
            
            return View();
        }

        [HttpPost]
        public ActionResult Index(KhachHang kh)
        {
            if (ModelState.IsValid)
            {     
            testDBEntities db = new testDBEntities();

            //thong tin bang KHACH
            KHACH kh1 = new KHACH();
            kh1.MaKhach = kh.maKH;
            kh1.TenKhach = kh.TenKhach;
            kh1.CMND = kh.Cmnd;
            kh1.Mail = kh.Mail;
            kh1.SDT = kh.Sdt;
            db.KHACHes.Add(kh1);
            
            //thong tin bang Account
            Account acc1 = new Account();
            acc1.IdA = kh.Sdt;
            acc1.PassA = kh.Password;
            acc1.MaQuyen = 3;
            db.Accounts.Add(acc1);

            db.SaveChanges();
            return RedirectToAction("TrangChu");
            }
            else 
            {
                
            }
            return View("Index");
        }
    }
}