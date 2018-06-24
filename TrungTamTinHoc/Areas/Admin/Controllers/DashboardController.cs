using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TrungTamTinHoc.Controllers;

namespace TrungTamTinHoc.Areas.Admin.Controllers
{
    public class DashboardController : Controller
    {
        // GET: Admin/Dashboard
        public ActionResult Index()
        {
            if (Session["login"] == null)
            {
                return RedirectToAction("Index", "AdminLogin");
            }
            return View();
        }
    }
}