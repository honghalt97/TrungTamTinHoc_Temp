using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TrungTamTinHoc.Areas.Home.Models;
using TrungTamTinHoc.Areas.Home.Models.Schema;

namespace TrungTamTinHoc.Areas.Home.Controllers
{
    public class BaiVietController : Controller
    {
        /// <summary>
        /// Các điều hướng dành cho các trang liên quan đến Trang Bài viết
        /// Author       :   HaLTH - 24/06/2018 - create
        /// </summary>
        /// <remarks>
        /// Package      :   Home
        /// Copyright    :   Team Noname
        /// Version      :   1.0.0
        /// </remarks>
        public ActionResult ChiTietBaiViet(string BeautyId)
        {
            try
            {
                HomeData data = new HomeData();
                BaiVietModel model = new BaiVietModel();
                data.CacBaiViet = model.LoadBaiViet();

            return View("BaiViet");
            }
            catch (Exception e)
            {
                return RedirectToAction("Error", "Error", new { area = "error", error = e.Message });
            }
        }

    }
}