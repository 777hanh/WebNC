using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using System.Net;
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

        //Thêm tài khoản
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
                var check_ID = db.Accounts.Where(s => s.IdA == account.IdA.Trim()).FirstOrDefault();
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

        //Xoá tài khoản
        public ActionResult DeleteAd(string id)
        {
            return View(db.Accounts.Where(acc => acc.IdA == id.Trim()).FirstOrDefault());
        }

        // POST: AccTest/Delete/5
        [HttpPost, ActionName("DeleteAd")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteCAd(string id, Account _acc)
        {
            try
            {
                _acc = db.Accounts.Where(s => s.IdA == id.Trim()).FirstOrDefault();
                db.Accounts.Remove(_acc);
                db.SaveChanges();
                return RedirectToAction("Index", "Admin");
            }
            catch
            {
                return Content("Không thể xoá!");
            }
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }


        //Sửa tài khoản
        public ActionResult EditAd([Bind(Include = "PassA,MaQuyen,TenUser")] string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Account account = db.Accounts.Find(id.Trim());
            if (account == null)
            {
                return HttpNotFound();
            }
            ViewBag.MaQuyen = new SelectList(db.PhanQuyens, "MaQuyen", "TenQuyen", account.MaQuyen);
            return View(db.Accounts.Where(acc => acc.IdA == id.Trim()).FirstOrDefault());
        }
        [HttpPost]
        public async Task<ActionResult> EditAd(string id, Account account)
        {
            SetViewBagPhanQuyen(); ViewBag.MaQuyen = new SelectList(db.PhanQuyens, "MaQuyen", "TenQuyen", account.MaQuyen);
            if (ModelState.IsValid)
            {
                db.Entry(account).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View();

        }



        //Tạo List ViewBag
        public void SetViewBagPhanQuyen()
        {
            List<PhanQuyen> _phanQuyens = db.PhanQuyens.ToList();
            ViewBag._phanQuyen = new SelectList(_phanQuyens, "MaQuyen");
        }
    }
}