using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using WebQLThueXe.Models;

namespace WebQLThueXe.Controllers
{
    public class AdminController : Controller
    {
        testDBEntities db = new testDBEntities();
        //GET: Admin
        public ActionResult Index()
        {
            var accs = db.Accounts;
            return View(accs);
        }
        public ActionResult ListCar()
        {
            var car = db.Xes;
            return View(car);
        }
        public ActionResult ListStaff()
        {
            var staff = db.NhanViens;
            return View(staff);
        }
        public ActionResult ListCategory()
        {
            var cate = db.LoaiXes;
            return View(cate);
        }
        public ActionResult ListCateNV()
        {
            var cateNV = db.LoaiNhanViens;
            return View(cateNV);
        }

        public ActionResult CreateAccountAd()
        {
            ViewBag.MaQuyen = new SelectList(db.PhanQuyens, "MaQuyen", "TenQuyen");
            return View();
        }

        [HttpPost]
        public ActionResult CreateAccountAd([Bind(Include = "IdA,PassA,ConfirmPassA,MaQuyen,TenUser")] Account account)
        {
            SetViewBagPhanQuyen();
            ViewBag.MaQuyen = new SelectList(db.PhanQuyens, "MaQuyen", "TenQuyen", account.MaQuyen);
            if (ModelState.IsValid)
            {
                var check_ID = db.Accounts.Where(s => s.IdA == account.IdA).FirstOrDefault();
                if (check_ID == null)
                {
                    db.Configuration.ValidateOnSaveEnabled = false;
                    db.Accounts.Add(account);
                    db.SaveChanges();
                    return RedirectToAction("Index", "Admin");
                }
                else
                {
                    ViewBag.ErrorDangKy = "ID này đã tồn tại";
                    return View(account);
                }
              
            }

            
            return View(account);
        }



        public void SetViewBagPhanQuyen()
        {
            List<PhanQuyen> _phanQuyens = db.PhanQuyens.ToList();
            ViewBag._phanQuyen = new SelectList(_phanQuyens, "MaQuyen");
        }
    }
}