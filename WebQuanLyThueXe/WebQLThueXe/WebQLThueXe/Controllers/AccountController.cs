using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebQLThueXe.Models;

namespace WebQLThueXe.Controllers
{
    public class AccountController : Controller
    {
        testDBEntities db = new testDBEntities();
        // GET: Account
        public ActionResult Profile()
        {
            if (Session["Account"] == null)
                return RedirectToAction("Index", "DangNhap");
            Account acc = Session["Account"] as Account;
            Account account = db.Accounts.SingleOrDefault(s => s.IdA == acc.IdA);
            return View(account);
        }
        
        [HttpPost]
        public ActionResult Profile(FormCollection form)
        {
            if (ModelState.IsValid)
            {
                db.Configuration.ValidateOnSaveEnabled = false;
                Account acc = Session["Account"] as Account;
                Account account = db.Accounts.SingleOrDefault(s => s.IdA == acc.IdA);

                db.Entry(account).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }
            return RedirectToAction("Profile");
        }

        public ActionResult Logout()
        {
            Session.Clear();
            return RedirectToAction("Index", "DangNhap");
        }
        
    }
}