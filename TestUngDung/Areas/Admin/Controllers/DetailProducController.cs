using ModelEF.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TestUngDung.Areas.Admin.Controllers
{
    public class DetailProducController : Controller
    {
        // GET: Admin/detailProduct
        public ActionResult Index(string id)
        {
            var product_detail = new DetailProductDao();
            var model = product_detail.ListWhereAll(id);
            return View(model);
        }
    }
}