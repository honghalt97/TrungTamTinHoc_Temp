using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TrungTamTinHoc.Areas.Home.Models;
using TrungTamTinHoc.Areas.Home.Models.Schema;
using TTTH.Validate;
using TTTH.Common;
using TblTokenLogin = TTTH.DataBase.Schema.TokenLogin;
using static TTTH.Common.Enums.ConstantsEnum;
using static TTTH.Common.Enums.MessageEnum;

namespace TrungTamTinHoc.Areas.Home.Controllers
{
    /// <summary>
    /// Class chứa các điều hướng liên quan đến login
    /// Author       :   QuyPN - 28/05/2018 - create
    /// </summary>
    /// <remarks>
    /// Package      :   Home
    /// Copyright    :   Team Noname
    /// Version      :   1.0.0
    /// </remarks>
    public class LoginController : Controller
    {
        /// <summary>
        /// Điều hướng đến trang login.
        /// Author       :   QuyPN - 28/05/2018 - create
        /// </summary>
        /// <returns>Trang view login, nếu có lỗi sẽ rả về trang error</returns>
        /// <remarks>
        /// Method: GET
        /// RouterName: UserLogin
        /// </remarks>
        public ActionResult Index()
        {
            try
            {
                int idAccount = XacThuc.GetIdAccount();
                if (idAccount != 0)
                {
                    return RedirectToAction("Index", "Home", new { area = "home" });
                }
                return View();
            }
            catch (Exception e)
            {
                return RedirectToAction("Error", "Error", new { area = "error", error = e.Message });
            }
        }
        /// <summary>
        /// Xác thực thông tin người dùng gửi lên.
        /// Author: QuyPN - 028/05/2018 - create
        /// </summary>
        /// <param name="account">Đối tượng chưa thông tin tài khaonr của người dùng</param>
        /// <returns>Chỗi Json chứa kết quả kiểm tra</returns>
        /// <remarks>
        /// Method: POST
        /// RouterName: homeCheckLogin
        /// </remarks>
        public JsonResult CheckLogin(Account account)
        {
            ResponseInfo response = new ResponseInfo();
            try
            {
                if (ModelState.IsValid)
                {
                    response = new LoginModel().CheckAccount(account);
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
        /// Xác thực tài khoản thông qua việc login bằng các tài khoản FB hoặc GG.
        /// Author       :   QuyPN - 30/05/2018 - create
        /// </summary>
        /// <param name="accessToken">Thông tin cá nhân lấy được từ FB hoặc GG</param>
        /// <param name="type">type = 1: thông tin từ FB; type = 2: thông tin từ GG</param>
        /// <returns>Chỗi Json chứa kết quả kiểm tra</returns>
        /// <remarks>
        /// Method: GET
        /// RouterName: homeCheckSocialLogin
        /// </remarks>
        public JsonResult LoginBySocialAccount(string accessToken, int type = (int)OtherEnum.TaiKhoanFB)
        {
            ResponseInfo response = new ResponseInfo();
            try
            {
                LoginModel model = new LoginModel();
                TblTokenLogin token = model.CheckSocialAccount(type == (int)OtherEnum.TaiKhoanFB
                    ? model.LayThongTinFB(accessToken)
                    : model.LayThongTinGG(accessToken), type);
                if (token != null)
                {
                    response.ThongTinBoSung1 = BaoMat.Base64Encode(token.Token);
                }
                else
                {
                    response.Code = (int)CodeResponse.NotAccess;
                    response.MsgNo = (int)MsgNO.XacThucKhongHopLe;
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
        /// Điều hướng việc logout khỏi hệ thống.
        /// Author       :   QuyPN - 28/05/2018 - create
        /// </summary>
        /// <returns>Trở về lại trang login, trả về trang error nếu có lỗi</returns>
        /// <remarks>
        /// Method: GET
        /// RouterName: homeLogout
        /// </remarks>
        public ActionResult Logout(string token)
        {
            try
            {
                new LoginModel().RemoveToken(token);
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                return RedirectToAction("Error", "Error", new { area = "error", error = e.Message });
            }
        }
    }
}