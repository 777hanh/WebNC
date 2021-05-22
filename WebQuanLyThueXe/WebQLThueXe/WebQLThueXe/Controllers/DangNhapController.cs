using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebQLThueXe.Models;

namespace WebQLThueXe.Controllers
{
    public class DangNhapController : Controller
        
    {
        testDBEntities db = new testDBEntities();
        // GET: DangNhap
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult DangNhapAccount(Account _acc)
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
                    db.Configuration.ValidateOnSaveEnabled = false;
                    Session["IdA"] = _acc.IdA;
                    Session["PassA"] = _acc.PassA;
                    Session["MaQuyen"] = _acc.MaQuyen;
                    return RedirectToAction("../TrangChu");
                }
            }
            else
            {
                return View("Index");
            }
        }
        
    }
}