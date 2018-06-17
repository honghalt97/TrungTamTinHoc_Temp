using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TrungTamTinHoc.Areas.Home.Models.Schema;
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
    }
}