using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using tett.Models;

namespace tett.Controllers
{
    public class HomeController : Controller
    {
        testDBEntities db = new testDBEntities();
        public ActionResult Index()
        {
            var cars = db.Xes;
            return View(cars);
        }

        public ActionResult Logout()
        {
            Session.Clear();
            return RedirectToAction("Login", "Account");
        }

    }
}