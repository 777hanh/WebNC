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


        
        
    }
}