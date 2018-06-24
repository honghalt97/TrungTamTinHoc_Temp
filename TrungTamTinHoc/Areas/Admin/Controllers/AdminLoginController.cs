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

namespace TrungTamTinHoc.Areas.Admin.Controllers
{
    public class AdminLoginController : Controller
    {
        // GET: Admin/Login
        public ActionResult Index()
        {
            if (Session["login"] != null)
            {
                return RedirectToAction("Index", "Dashboard");
            }
            return View();
        }

        public ActionResult Logout()
        {
            Session["login"] = null;
            return RedirectToAction("Index");
        }

        public JsonResult CheckLogin(Account account)
        {
            ResponseInfo response = new ResponseInfo();
            try
            {
                if (ModelState.IsValid)
                {
                    response = new LoginModel().CheckAccount(account);
                    if(response.Code == 200 && response.MsgNo == 0)
                    {
                        Session["login"] = true;
                    }
                    else
                    {
                        response.Code = 403;
                        response.MsgNo = 27;
                    }
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