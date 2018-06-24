using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TrungTamTinHoc.Areas.Admin.Models;
using TrungTamTinHoc.Areas.Admin.Models.Schema;
using TTTH.Common;
using TTTH.DataBase;
using TTTH.DataBase.Schema;
using static TTTH.Common.Enums.ConstantsEnum;
using static TTTH.Common.Enums.MessageEnum;

namespace TrungTamTinHoc.Areas.Admin.Controllers
{
    public class QuanLyKhoaHocController : Controller
    {
        // GET: Admin/QuanLyKhoaHoc
        public ActionResult Index()
        {
            if (Session["login"] == null)
            {
                return RedirectToAction("Index", "AdminLogin");
            }
            DataContext context = new DataContext();
            List<KhoaHoc> khoaHoc = context.KhoaHoc.Where(x => !x.DelFlag).ToList();
            return View(khoaHoc);
        }

        public ActionResult KhoaHoc(int? id)
        {
            if (Session["login"] == null)
            {
                return RedirectToAction("Index", "AdminLogin");
            }
            KhoaHoc khoaHoc = null;
            if(id != null)
            {
                DataContext context = new DataContext();
                khoaHoc = context.KhoaHoc.FirstOrDefault(x => x.Id == id && !x.DelFlag);
            }
            return View(khoaHoc);
        }
        [ValidateInput(false)]
        public JsonResult XuLyKhoaHoc(DataKhoaHoc data)
        {
            ResponseInfo response = new ResponseInfo();
            try
            {
                response = new KhoaHocModel().XuLyKhoaHoc(data);
            }
            catch (Exception e)
            {
                response.Code = (int)CodeResponse.ServerError;
                response.MsgNo = (int)MsgNO.ServerError;
                response.ThongTinBoSung1 = e.Message;
            }
            return Json(response, JsonRequestBehavior.AllowGet);
        }
        public JsonResult UpdateShow(int id, bool show)
        {
            ResponseInfo response = new ResponseInfo();
            try
            {
                DataContext context = new DataContext();
                KhoaHoc khoaHoc = context.KhoaHoc.FirstOrDefault(x => x.Id == id && !x.DelFlag);
                if(khoaHoc != null)
                {
                    khoaHoc.HienThi = show;
                    context.SaveChanges();
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
        public JsonResult DeleteKhoaHoc(int id)
        {
            ResponseInfo response = new ResponseInfo();
            try
            {
                DataContext context = new DataContext();
                KhoaHoc khoaHoc = context.KhoaHoc.FirstOrDefault(x => x.Id == id && !x.DelFlag);
                if (khoaHoc != null)
                {
                    khoaHoc.DelFlag = true;
                    context.SaveChanges();
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