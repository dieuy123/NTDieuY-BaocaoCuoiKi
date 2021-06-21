using ModelEF.DAO;
using ModelEF.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TestUngDung.Areas.Admin.Controllers
{
    public class ProductController : BaseController
    {
        // GET: Admin/Product
        NguyenThiDieuYContext db = new NguyenThiDieuYContext();
         public ActionResult Index(string searchString, int page = 1, int pagesize = 5)
        {
            var product = new ProductDao();
            var model = product.ListWhereAll(searchString, page, pagesize);
            //var product = new ProductDao();
            //var model = product.ListWhereAll(searchString);
            ViewBag.searchString = searchString;
            return View(model);
        }
        [HttpGet]
        public ActionResult Create()
        {
            setViewBag();
            return View();
        }
        public void setViewBag(int? selectedmasp = null)
        {
            var dao = new CategoryDao();
            ViewBag.IDCategory = new SelectList(dao.ListAll(), "maloai", "tenloai", selectedmasp);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Product sp, HttpPostedFileBase Image)
        {
            if (Image != null && Image.ContentLength > 0)
            {

                string _FileName = Path.GetFileName(Image.FileName);
                string _path = Path.Combine(Server.MapPath("~/Upload/sanpham/" + _FileName));
                Image.SaveAs(_path);

                sp.Image = _FileName;

            }

            if (ModelState.IsValid)
            {
                db.Products.Add(sp);
                db.SaveChanges();
                SetAlert("Thêm Sản Phẩm Thành Công", "success");
                return RedirectToAction("Index");
            }
            return View();
        }

        //if (ModelState.IsValid)
        //{
        //    var product = new ProductDao();

        //    string result = product.Insert(sp);
        //    if (!string.IsNullOrEmpty(result))
        //    {
        //        SetAlert("Thêm tài khoản thành công", "success");
        //        return RedirectToAction("Index", "Product");
        //    }
        //    else
        //    {
        //        SetAlert("Thêm tài khoản thất bại", "error");
        //    }
        //}
        //return View();
    
        //[HttpGet]
        //public ActionResult Edit(System.Int32 id)
        //{
        //    var product = new ProductDao();
        //    var result = product.FindId(id);
        //    setViewBag(result.sp);
        //    if (result != null)
        //        return View(result);
        //    return View();
        //}
        [HttpGet]
        public ActionResult Edit(System.Int32 id)
        {
            var product = new ProductDao();
            var result = product.FindId(id);
            if (result != null)
                return View(result);
            return View();
        }

        //private void setViewBag(string masp)
        //{
        //    throw new NotImplementedException();
        //}

        [HttpPost]
        [ValidateAntiForgeryToken]
        //public ActionResult Edit(Product sp, HttpPostedFileBase Image)
        //{
        //    Product unv = db.Products.FirstOrDefault(x => x.masp == sp.masp);

        //    if (unv != null)
        //{
        //    unv.maloai = sp.maloai;
        //    unv.tensp = sp.tensp;
        //    unv.dongia = sp.dongia;
        //    unv.soluong = sp.soluong;
        //    unv.Image = sp.Image;
        //    unv.trangthai = sp.trangthai;
        //    unv.mota = sp.mota;
        //    unv.mausac = sp.mausac;


        //    if (Image != null && Image.ContentLength > 0)
        //    {
        //        string id = sp.masp;

        //        string _FileName = "";
        //        _FileName = Path.GetFileName(Image.FileName);
        //        string _path = Path.Combine(Server.MapPath("~/Upload/sanpham/" + _FileName));
        //        Image.SaveAs(_path);
        //        unv.Image = _FileName;
        //    }
        //}

        //    if (ModelState.IsValid)
        //    {
        //        db.SaveChanges();
        //        SetAlert("Cập Nhật Sản Phẩm Thành Công", "success");
        //        return RedirectToAction("Index", "Product");
        //    }
        //    //setViewBag(sp.masp);
        //    return View();
        public ActionResult Edit(Category model)
        { 
        var category = new CategoryDao();
        string result = category.Update(model);
            if (!string.IsNullOrEmpty(result))
            {
                SetAlert("Cập nhật danh mục thành công", "success");
                return RedirectToAction("Index", "Category");
    }
            else
            {
                SetAlert("Cập nhật danh mục thất bại", "error");
}
return View();
        }
        //public JsonResult Delete(System.Int32 id)
        //{

        //    var category = new CategoryDao();
        //    bool re = category.Delete(id);
        //    return Json(re, JsonRequestBehavior.AllowGet);
        //}
        [HttpDelete]
        public ActionResult Delete(string id)
        {
            var product = new ProductDao();
            Boolean result = product.Delete(id);
            if (result)
            {
                SetAlert("Đã xóa thành công", "success");
                return RedirectToAction("Index", "Product");
            }
            else
            {
                SetAlert("Xóa không thành công ", "error");
                return RedirectToAction("Index", "Product");
            }
        }
    }
}