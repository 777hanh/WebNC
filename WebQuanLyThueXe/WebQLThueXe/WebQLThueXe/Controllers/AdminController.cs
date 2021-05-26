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


    }
}