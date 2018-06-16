using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TrungTamTinHoc.Areas.Home.Models;
using TrungTamTinHoc.Areas.Home.Models.Schema;
using TTTH.DataBase;

namespace TrungTamTinHoc.Areas.Home.Controllers
{
    /// <summary>
    /// Các điều hướng dành cho các trang liên quan đến trang chủ
    /// Author       :   QuyPN - 10/06/2018 - create
    /// </summary>
    /// <remarks>
    /// Package      :   Home
    /// Copyright    :   Team Noname
    /// Version      :   1.0.0
    /// </remarks>
    public class HomeController : Controller
    {
        /// <summary>
        /// Lấy dữ liệu từ model và điều hướng về trang home.
        /// Author       :   QuyPN - 10/06/2018 - create
        /// </summary>
        /// <returns>Trả lại trang view home, nếu có lỗi thì trả về trang error</returns>
        /// <remarks>
        /// Method: GET
        /// RouterName: Home
        /// </remarks>
        public ActionResult Index()
        {
            try
            {
                HomeData data = new HomeData();
                HomeModel model = new HomeModel();
                data.Slides = model.LoadSlide();
                data.NhungDieuDatDuoc = model.LoadNhungDieuDatDuoc();
                data.WhyUs = model.LoadWhyUs();
                data.CacKhoaHoc = model.LoadKhoaHoc();
                data.DanhSachGiangVien = model.LoadGiangVien();
                return View("Home", data);
            }
            catch (Exception e)
            {
                return RedirectToAction("Error", "Error", new { area = "error", error = e.Message });
            }
        }
        /// <summary>
        /// Lấy dữ liệu từ model và điều hướng về trang about us.
        /// Author       :   QuyPN - 16/06/2018 - create
        /// </summary>
        /// <returns>Trả lại trang view about, nếu có lỗi thì trả về trang error</returns>
        /// <remarks>
        /// Method: GET
        /// RouterName: About
        /// </remarks>
        public ActionResult About()
        {
            ViewBag.text = new HomeModel().LoadAbout();
            return View("About");
        }
        public ActionResult Contact()
        {
            return View();
        }
    }
}