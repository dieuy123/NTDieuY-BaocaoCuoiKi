using ModelEF;
using ModelEF.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TestUngDung.Areas.Admin.Models;

namespace TestUngDung.Areas.Admin.Controllers
{
    public class LoginController : Controller
    {
        // GET: Admin/Login
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(loginModel login)
        {

            if (ModelState.IsValid)
            {
                var dao = new UserDao();
                var result = dao.login(login.UserName, login.Password);

                if (result == 1)
                {
                    //ModelState.AddModelError("", "đăng nhập thành công");
                    Session.Add(Constants.USER_SESSION, login);
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("", "đăng nhập thất bại");
                }
            }
            return View("Index");
        }
    }
}

    
