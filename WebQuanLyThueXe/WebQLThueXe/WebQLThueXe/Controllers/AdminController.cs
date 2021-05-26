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



    }
}