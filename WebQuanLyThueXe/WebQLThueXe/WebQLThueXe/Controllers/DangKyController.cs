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
        testDBEntities db = new testDBEntities();
        public ActionResult Index()
        {

            return View();
        }

        [HttpPost]
        public ActionResult Index(Account _acc)
        {
            if (ModelState.IsValid)
            {
                var check_ID = db.Accounts.Where(s => s.IdA == _acc.IdA).FirstOrDefault();
                if (check_ID == null)
                {
                    db.Configuration.ValidateOnSaveEnabled = false;
                    _acc.MaQuyen = 2;
                    db.Accounts.Add(_acc);
                    db.SaveChanges();
                    return RedirectToAction("Index","TrangChu");
                }
                else
                {
                    ViewBag.ErrorDangKy = "ID này đã tồn tại";
                    return View();
                }
            }
            return View();
        }
    }
}
