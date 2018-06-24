using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace TrungTamTinHoc
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Home",
                url: "",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional },
                namespaces: new string[] { "MvcNangCao.Areas.Home.Controllers" }
            ).DataTokens.Add("area", "home");

            routes.MapRoute(
                name: "About",
                url: "about",
                defaults: new { controller = "Home", action = "About", id = UrlParameter.Optional },
                namespaces: new string[] { "MvcNangCao.Areas.Home.Controllers" }
            ).DataTokens.Add("area", "home");

            routes.MapRoute(
                name: "Contact",
                url: "contact",
                defaults: new { controller = "Home", action = "Contact", id = UrlParameter.Optional },
                namespaces: new string[] { "MvcNangCao.Areas.Home.Controllers" }
            ).DataTokens.Add("area", "home");

            routes.MapRoute(
                name: "UserLogin",
                url: "login",
                defaults: new { controller = "Login", action = "Index", id = UrlParameter.Optional },
                namespaces: new string[] { "MvcNangCao.Areas.Home.Controllers" }
            ).DataTokens.Add("area", "home");

            routes.MapRoute(
                name: "GuideLine",
                url: "guide-line",
                defaults: new { controller = "GuideLine", action = "GuideLine", id = UrlParameter.Optional },
                namespaces: new string[] { "MvcNangCao.Areas.Home.Controllers" }
            ).DataTokens.Add("area", "home");

            routes.MapRoute(
                name: "TermsConditions",
                url: "terms-conditions",
                defaults: new { controller = "GuideLine", action = "TermsConditions", id = UrlParameter.Optional },
                namespaces: new string[] { "MvcNangCao.Areas.Home.Controllers" }
            ).DataTokens.Add("area", "home");

            routes.MapRoute(
                name: "PrivacyPolicy",
                url: "privacy-policy",
                defaults: new { controller = "GuideLine", action = "PrivacyPolicy", id = UrlParameter.Optional },
                namespaces: new string[] { "MvcNangCao.Areas.Home.Controllers" }
            ).DataTokens.Add("area", "home");

            routes.MapRoute(
                name: "DangKyTaiKhoan",
                url: "dang-ky-tai-khoan",
                defaults: new { controller = "RegisterAccount", action = "Register", id = UrlParameter.Optional },
                namespaces: new string[] { "MvcNangCao.Areas.Home.Controllers" }
            ).DataTokens.Add("area", "home");

            routes.MapRoute(
                name: "TaoTaiKhoanThanhCong",
                url: "dang-ky-thanh-cong",
                defaults: new { controller = "RegisterAccount", action = "CreateAccountSuccess", id = UrlParameter.Optional },
                namespaces: new string[] { "MvcNangCao.Areas.Home.Controllers" }
            ).DataTokens.Add("area", "home");

            routes.MapRoute(
                name: "KichHoatTaiKhoan",
                url: "kich-hoat-tai-khoan",
                defaults: new { controller = "RegisterAccount", action = "AciveAccount", id = UrlParameter.Optional },
                namespaces: new string[] { "MvcNangCao.Areas.Home.Controllers" }
            ).DataTokens.Add("area", "home");

            routes.MapRoute(
                name: "BaiViet",
                url: "danh-sach-bai-viet/{id}",
                defaults: new { controller = "BaiViet", action = "ChiTietBaiViet", id = UrlParameter.Optional },
                namespaces: new string[] { "MvcNangCao.Areas.Home.Controllers" }
            ).DataTokens.Add("area", "home");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
