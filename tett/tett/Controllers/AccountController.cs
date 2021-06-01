using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using tett.Models;

namespace tett.Controllers
{
    public class AccountController : Controller
    {
        testDBEntities db = new testDBEntities();
        // GET: Account
        public ActionResult Login()
        {
            User acc = new User();
            return View(acc);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(AccountLogin user)
        {
            if (ModelState.IsValid)
            {
                var A = new AccountLogin();
                if(user.ID!=null)
                A.ID = user.ID.Trim();
                if (user.Password != null)
                    A.Password = user.Password.Trim();
                int checkAcc = A.IsValidAccount(A.ID, A.Password);
                var check = db.Users.Where(s=>s.SDT == user.ID.Trim() && s.PasswordUser==user.Password.Trim()).FirstOrDefault();
                if (checkAcc == 0)
                {
                    ViewBag.ErrorInfo = "Sai Thong Tin";
                    ModelState.AddModelError("", "Đăng nhập thất bại");
                }
                else
                {
                    
                    db.Configuration.ValidateOnSaveEnabled=false;
                    Session["avatar"] = "avatar" + check.MaUser+".jpg";
                    Session["AccountID"] = check.MaUser;
                    Session["AccountName"] = check.TenUser;
                    Session["AccountMaQuyen"] = check.MaQuyen;
                    Session["Account"] = check;
                    var account = Session["Account"] as User;
                    ModelState.AddModelError("", "Đăng nhập thành công");


                    if (check.MaQuyen == 2)
                        return RedirectToAction("Index", "Home");
                    else if (check.MaQuyen == 1)
                        return RedirectToAction("RequestList", "NhanVien");
                    else
                        return RedirectToAction("CarList", "Admin");
                }
            }
            return View();
        }
    } }
    
