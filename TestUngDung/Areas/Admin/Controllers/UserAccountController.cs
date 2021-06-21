using ModelEF;
using ModelEF.DAO;
using ModelEF.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TestUngDung.Areas.Admin.Models;

namespace TestUngDung.Areas.Admin.Controllers
{
    public class UserAccountController : BaseController
    {
        public ActionResult Index(string searchString, int page = 1, int pagesize = 5)
        {
            var userAccount = new UserDao();
            var model = userAccount.ListWhereAll(searchString, page, pagesize);
            ViewBag.searchString = searchString;
            return View(model);
        }
        //public object Encryptor { get; private set; }

        // GET: Admin/UserAccount
        //public ActionResult Index()
        //{
        //    var user = new UserDao();
        //    var model = user.ListAll();
        //    return View(model);
        //}
        //NTDieuYContext dbModel = new NTDieuYContext();

        //public ActionResult Index(string searchUser)
        //{
        //    var User = from s in dbModel.UserAccounts select s;
        //    if (!String.IsNullOrEmpty(searchUser))
        //    {
        //        User = User.Where(s => s.UserName.Contains(searchUser));

        //    }
        //    else
        //    {

        //    }

        //    return View(User.ToList());


        //}
        //[HttpGet]
        //public ActionResult Create()
        //{
        //    return View();
        //}
        //[HttpPost]
        //public ActionResult Create(UserAccount  model)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        var dao = new UserDao();
        //       if(!dao.Find(model))
        //        {
        //            return RedirectToAction("Create", "UserAccount");
        //        }    
        //        var result = dao.Insert(model.UserName, model.Password);

        //        if (string.IsNullOrEmpty(model.UserName))
        //        {
        //            //ModelState.AddModelError("", "đăng nhập thành công");
        //            //Session.Add(Constants.USER_SESSION, model);
        //            return RedirectToAction("Index", "UserAccount");
        //        }
        //        else
        //        {
        //            ModelState.AddModelError("", "tạo người dùng thất bại");
        //        }
        //    }
        //    return View();
        //}

        //        [HttpGet]
        //        public ActionResult Create(string user)
        //        {
        //            return View();
        //        }
        //        [HttpPost]

        //        public ActionResult Create(UserAccount model)
        //        {

        //            if (ModelState.IsValid)
        //            {
        //                var userAccount = new UserAccountDao();
        //                if (userAccount.FindName(model.UserName))
        //                {
        //                    SetAlert("tài khoản Đã Tồn Tại!!!", "warning");
        //                    return RedirectToAction("Create", "UserAccount");
        //                }
        //                string result = userAccount.Insert(model);
        //                if (!string.IsNullOrEmpty(result))
        //                {
        //                    SetAlert("Thêm thành công", "success");
        //                    return RedirectToAction("Index", "UserAccount");
        //                }
        //                else
        //                {
        //                    SetAlert("Thêm  thất bại", "error");
        //                }
        //            }
        //            return View();
        //        }
        //        [HttpGet]
        //        public ActionResult Edit(string id)
        //        {
        //            var userAccount = new UserAccountDao();
        //            var result = userAccount.FindId(id);
        //            if (result != null)
        //                return View(result);
        //            return View();
        //        }
        //        [HttpPost]

        //        public ActionResult Edit(UserAccount model)
        //        {
        //            var userAccount = new UserAccount();
        //            string result = userAccount.Update(model);
        //            if (!string.IsNullOrEmpty(result))
        //            {
        //                SetAlert("Cập nhật  thành công", "success");
        //                return RedirectToAction("Index", "UserAccount");
        //            }
        //            else
        //            {
        //                SetAlert("Cập nhật thất bại", "error");
        //            }
        //            return View();
        //        }
        //    }

        //}
        [HttpGet]
        public ActionResult Create(string user)
        {
            return View();
        }
        [HttpPost]

        public ActionResult Create(UserAccount model)
        {

            if (ModelState.IsValid)
            {
                var userAccount = new UserDao();
                //var dao = new UserDao();
                ////var user = dao.FindId(model.admin_id);
                //var pass = Encryptor.EncryptMD5(model.PassWord);
                //model.PassWord = pass;
                //string result = dao.Insert(model);
                string result = userAccount.Insert(model);
                if (!string.IsNullOrEmpty(result))
                {
                    SetAlert("Thêm tài khoản thành công", "success");
                    return RedirectToAction("Index", "UserAccount");
                }
                else
                {
                    SetAlert("Thêm tài khoản thất bại", "error");
                }
            }
            return View();
        }
        [HttpGet]
        public ActionResult Edit(System.Int32 id)
        {
            var dao = new UserDao();
            var result = dao.FindId(id);
            if (result != null)
                return View(result);
            return View();
        }
        [HttpPost]

        public ActionResult Edit(UserAccount model)
        {
            var user = new UserDao();
            string result = user.Update(model);
            //var dao = new UserDao();
            //var pass = Encryptor.EncryptMD5(model.PassWord);
            //model.PassWord = pass;
            //string result = dao.Update(model);
            if (!string.IsNullOrEmpty(result))
            {
                SetAlert("Cập nhật tài khoản thành công", "success");
                return RedirectToAction("Index", "UserAccount");
            }
            else
            {
                SetAlert("Cập nhật tài khoản thất bại", "error");
            }
            return View();
        }
        //public JsonResult Delete(System.Int32 id)
        //{

        //    var dao = new UserDao();
        //    bool re = dao.Delete(id);
        //    return Json(re, JsonRequestBehavior.AllowGet);
        //}
        [HttpDelete]
        public ActionResult Delete(int id)
        {
            var dao = new UserDao().Delete(id);
            return RedirectToAction("Index");
        }
        //[HttpDelete]
        //public ActionResult Delete(string id)
        //{
        //    var user = new UserDao();
        //    Boolean result = user.Delete(id);
        //    if (result)
        //    {
        //        SetAlert("Đã xóa thành công", "success");
        //        return RedirectToAction("Index", "UserAccount");
        //    }
        //    else
        //    {
        //        SetAlert("Xóa không thành công ", "error");
        //        return RedirectToAction("Index", "UserAccount");
        //    }
        //}
    }
}

