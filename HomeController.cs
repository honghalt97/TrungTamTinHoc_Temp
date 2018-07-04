using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TrungTamTinHoc.Areas.Home.Models;
using TrungTamTinHoc.Areas.Home.Models.Schema;
using TTTH.Common;
using TTTH.DataBase;
using TTTH.Validate;
using static TTTH.Common.Enums.ConstantsEnum;
using static TTTH.Common.Enums.MessageEnum;

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

        /// <summary>
        /// Đăng ký theo dõi qua email theo thông tin người dùng đưa lên.
        /// Author       :   HaLTH - 03/06/2018 - create
        /// </summary>
        /// <param name="account">Thông tin tài khoản đăng ký mà người dùng nhập vào</param>
        /// <returns>Chỗi Json chứa kết quả của việc tạo tài khoản</returns>
        /// <remarks>
        /// Method: POST
        /// RouterName: homeCreateAccount
        /// </remarks>
        public JsonResult SubscribeEmail(string Email)
        {
            ResponseInfo response = new ResponseInfo();
            try
            {
                if (ModelState.IsValid)
                {
                    response = new HomeModel().DangKyTheoDoi(Email);
                }
                else
                {
                    response.Code = (int)CodeResponse.NotValidate;
                    response.ListError = ModelState.GetModelErrors();
                }
            }
            catch (Exception e)
            {
                response.Code = (int)CodeResponse.ServerError;
                response.MsgNo = (int)MsgNO.ServerError;
                response.ThongTinBoSung1 = e.Message;
            }
            return Json(response, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// Kiểm tra email đã tồn tại hay chưa.
        /// Author       :   HaLTH - 03/06/2018 - create
        /// </summary>
        /// <returns>Nếu có tồn tại trả về true, ngược lại trả về false</returns>
        /// <remarks>
        /// Method: GET
        /// RouterName: homeSubscribeEmail
        /// </remarks>
        public bool CheckExistEmail(string Email)
        {
            try
            {
                return new HomeModel().CheckExistEmail(Email);
            }
            catch
            {
                return false;
            }
        }
    }
}