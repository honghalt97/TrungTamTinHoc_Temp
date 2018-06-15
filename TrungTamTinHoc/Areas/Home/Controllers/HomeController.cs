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
    public class HomeController : Controller
    {
        // GET: Home/Home
        public ActionResult Index()
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
        public ActionResult About()
        {
            return View();
        }
        public ActionResult Contact()
        {
            return View();
        }
    }
}