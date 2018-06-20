using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TrungTamTinHoc.Areas.Home.Models;
using TrungTamTinHoc.Areas.Home.Models.Schema;
using TTTH.Common;
using TTTH.Validate;
using static TTTH.Common.Enums.ConstantsEnum;
using static TTTH.Common.Enums.MessageEnum;

namespace TrungTamTinHoc.Areas.Home.Controllers
{
    /// <summary>
    /// Controller điều hướng cho các xử lý của việc đăng ký tài khoản.
    /// Author       :   QuyPN - 16/06/2018 - create
    /// </summary>
    /// <remarks>
    /// Package      :   Home.Models
    /// Copyright    :   Team Noname
    /// Version      :   1.0.0
    /// </remarks>
    public class RegisterAccountController : Controller
    {
        /// <summary>
        /// Điều hướng đến trang view nhập thông tin để thêm tài khoản.
        /// Author       :   QuyPN - 16/06/2018 - create
        /// </summary>
        /// <returns>Trả về trang view đăng ký tài khoản</returns>
        /// <remarks>
        /// Method: GET
        /// RouterName: DangKyTaiKhoan
        /// </remarks>
        public ActionResult Register()
        {
            return View();
        }
        /// <summary>
        /// Tạo tài khoản theo thông tin người dùng đưa lên.
        /// Author       :   QuyPN - 17/06/2018 - create
        /// </summary>
        /// <param name="account">Thông tin tài khoản đăng ký mà người dùng nhập vào</param>
        /// <returns>Chỗi Json chứa kết quả của việc tạo tài khoản</returns>
        /// <remarks>
        /// Method: POST
        /// RouterName: homeCreateAccount
        /// </remarks>
        public JsonResult CreateAccount(NewAccount account)
        {
            ResponseInfo response = new ResponseInfo();
            try
            {
                if (ModelState.IsValid)
                {
                    response = new RegisterModel().TaoAccount(account);
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
        /// Kiểm tra email hoặc username đã tồn tại hay chưa.
        /// Author       :   QuyPN - 20/05/2018 - create
        /// </summary>
        /// <param name="value">giá trị của email hoặc username cần kiểm tra</param>
        /// <param name="type">type = 1: kiểm tra usernme; type = 2: kiểm tra email</param>
        /// <returns>Nếu có tồn tại trả về true, ngược lại trả về false</returns>
        /// <remarks>
        /// Method: GET
        /// RouterName: homeCreateAccount
        /// </remarks>
        public bool CheckExistAccount(string value, string type)
        {
            try
            {
                return new RegisterModel().CheckExistAccount(value, type);
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// Đi đến trang tạo tài khoản thành công, nếu có lỗi thì đi đến trang hiển thị lỗi.
        /// Author       :   QuyPN - 20/05/2018 - create
        /// </summary>
        /// <returns>Trả về trang thông báo tạo tài khoản thành công hoặc trang lỗi</returns>
        /// <remarks>
        /// Method: GET
        /// RouterName: TaoTaiKhoanThanhCong
        /// </remarks>
        public ActionResult CreateAccountSuccess()
        {
            try
            {
                int idAccount = new RegisterModel().GetIdAccountActive();
                if(idAccount == 0)
                {
                    return RedirectToAction("Index", "Home");
                }
                ViewBag.idAccount = idAccount;
                return View("DangKyThanhCong");
            }
            catch(Exception e)
            {
                return RedirectToAction("Error", "Error", new { area = "error", error = e.Message });
            }
        }

        /// <summary>
        /// Kích hoạt tài khoản và đưa về trang view thông báo.
        /// Author       :   QuyPN - 20/05/2018 - create
        /// </summary>
        /// <param name="token">Token đang mã hóa Base64 được gửi đi trong mail</param>
        /// <param name="username">Tên đăng nhập mà user đăng ký được gửi kèm trong mail</param>
        /// <returns>Trả về trang thông báo kích hoạt tài khoản thành công hoặc trang lỗi</returns>
        /// <remarks>
        /// Method: GET
        /// RouterName: KichHoatTaiKhoan
        /// </remarks>
        public ActionResult AciveAccount(string token, string username)
        {
            try
            {
                string tokenCookies = Common.GetCookie("tokenAccount");
                if (tokenCookies == "" || tokenCookies != BaoMat.Base64Decode(token))
                {
                    return RedirectToAction("Index", "Home");
                }
                ResponseInfo response = new RegisterModel().ActiveAccount(token, username);
                return View("ActiveAccount", response);
            }
            catch (Exception e)
            {
                return RedirectToAction("Error", "Error", new { area = "error", error = e.Message });
            }
        }

        /// <summary>
        /// Sinh lại token và gửi lại Email theo id của tài khoản cần kích hoạt.
        /// Author       :   QuyPN - 20/05/2018 - create
        /// </summary>
        /// <param name="idAccount">Id của tài khoản cần gửi mail</param>
        /// <returns>Thông tin về việc gửi mail</returns>
        /// <remarks>
        /// Method: GET
        /// RouterName: homeSendEmailById
        /// </remarks>
        public JsonResult SendEmailById(int idAccount)
        {
            ResponseInfo response = new ResponseInfo();
            try
            {
                response = new RegisterModel().SendEmailById(idAccount);
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
        /// Sinh lại token và gửi lại Email theo email của người dùng nhập vàot.
        /// Author       :   QuyPN - 20/05/2018 - create
        /// </summary>
        /// <param name="Email">Email đã đăng ký do người dùng nhập vào</param>
        /// <returns>Thông tin về việc gửi mail</returns>
        /// <remarks>
        /// Method: GET
        /// RouterName: homeSendEmail
        /// </remarks>
        public JsonResult SendEmail(string email)
        {
            ResponseInfo response = new ResponseInfo();
            try
            {
                response = new RegisterModel().SendEmail(email);
            }
            catch (Exception e)
            {
                response.Code = (int)CodeResponse.ServerError;
                response.MsgNo = (int)MsgNO.ServerError;
                response.ThongTinBoSung1 = e.Message;
            }
            return Json(response, JsonRequestBehavior.AllowGet);
        }
    }
}