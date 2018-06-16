using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TrungTamTinHoc.Areas.Home.Models;

namespace TrungTamTinHoc.Areas.Home.Controllers
{
    /// <summary>
    /// Điều hướng cho các trang liên quán đến việc sử dụng hệ thống.
    /// Author       :   QuyPN - 16/06/2018 - create
    /// </summary>
    /// <remarks>
    /// Package      :   Home
    /// Copyright    :   Team Noname
    /// Version      :   1.0.0
    /// </remarks>
    public class GuideLineController : Controller
    {
        /// <summary>
        /// Điều hướng đến trang hướng dẫn sử dụng
        /// Author       :   QuyPN - 16/06/2018 - create
        /// </summary>
        /// <returns>Trang view hướng dẫn sử dụng hoặc trang lỗi nếu có lỗi phát sinh</returns>
        /// <remarks>
        /// Method: GET
        /// RouterName: GuideLine
        /// </remarks>
        public ActionResult GuideLine()
        {
            ViewBag.text = new GuideLineModel().LoadGuideLine();
            return View("GuideLine");
        }

        /// <summary>
        /// Điều hướng đến trang chính sách bảo mật
        /// Author       :   QuyPN - 16/06/2018 - create
        /// </summary>
        /// <returns>Trang view chính sách bảo mật hoặc trang lỗi nếu có lỗi phát sinh</returns>
        /// <remarks>
        /// Method: GET
        /// RouterName: PrivacyPolicy
        /// </remarks>
        public ActionResult PrivacyPolicy()
        {
            ViewBag.text = new GuideLineModel().LoadPrivacyPolicy();
            return View("PrivacyPolicy");
        }

        /// <summary>
        /// Điều hướng đến trang đều khoản sử dụng
        /// Author       :   QuyPN - 16/06/2018 - create
        /// </summary>
        /// <returns>Trang view điều khoản sử dụng hoặc trang lỗi nếu có lỗi phát sinh</returns>
        /// <remarks>
        /// Method: GET
        /// RouterName: TermsConditions
        /// </remarks>
        public ActionResult TermsConditions()
        {
            ViewBag.text = new GuideLineModel().LoadTermsConditions();
            return View("TermsConditions");
        }
    }
}