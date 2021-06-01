using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebQLThueXe.Models;
using System.Threading;
using System.Threading.Tasks;

namespace WebQLThueXe.Controllers
{
    public class DangNhapController : Controller
        
    {
        testDBEntities db = new testDBEntities();
        // GET: DangNhap

        [AllowAnonymous]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async  Task<ActionResult> DangNhapAccount(Account _acc)
        {
            
            if (ModelState.IsValidField("IdA"))
            {

                var check = db.Accounts.Where(s => s.IdA == _acc.IdA && s.PassA == _acc.PassA).FirstOrDefault();
                if (check == null)
                {
                    ViewBag.ErrorInfo = "Sai Thong Tin";
                    return View("Index");
                }
                else
                {
                    Session["Account"] = _acc;
                    Session["AccountName"] = _acc.TenUser;
                    db.Configuration.ValidateOnSaveEnabled = false;
                    Session["IdA"] = _acc.IdA;
                    Session["PassA"] = _acc.PassA;
                    Session["MaQuyen"] = _acc.MaQuyen;
                    if (_acc.MaQuyen == 2)
                        return RedirectToAction("Index", "TrangChu");
                    else if (_acc.MaQuyen == 1)
                        return RedirectToAction("Index", "NhanVien");
                    else
                        return RedirectToAction("Index","Admin");
                }
            }
            else
            {
                return View("Index");
            }
        }
        
    }
}