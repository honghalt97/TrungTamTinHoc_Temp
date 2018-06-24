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
    public class QuanLyTinTucController : Controller
    {
        // GET: Admin/QuanLyTinTuc
        public ActionResult Index()
        {
            if (Session["login"] == null)
            {
                return RedirectToAction("Index", "AdminLogin");
            }
            DataContext context = new DataContext();
            List<TinTuc> tinTuc = context.TinTuc.Where(x => !x.DelFlag).ToList();
            return View(tinTuc);
        }
        public ActionResult TinTuc(int? id)
        {
            if (Session["login"] == null)
            {
                return RedirectToAction("Index", "AdminLogin");
            }
            TinTuc tinTuc = null;
            if (id != null)
            {
                DataContext context = new DataContext();
                tinTuc = context.TinTuc.FirstOrDefault(x => x.Id == id && !x.DelFlag);
            }
            return View(tinTuc);
        }
        [ValidateInput(false)]
        public JsonResult XuLyTinTuc(DataTinTuc data)
        {
            ResponseInfo response = new ResponseInfo();
            try
            {
                response = new TinTucModel().XuLyTinTuc(data);
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
                TinTuc tinTuc = context.TinTuc.FirstOrDefault(x => x.Id == id && !x.DelFlag);
                if (tinTuc != null)
                {
                    tinTuc.HienThi = show;
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
        public JsonResult DeleteTinTuc(int id)
        {
            ResponseInfo response = new ResponseInfo();
            try
            {
                DataContext context = new DataContext();
                TinTuc tinTuc = context.TinTuc.FirstOrDefault(x => x.Id == id && !x.DelFlag);
                if (tinTuc != null)
                {
                    tinTuc.DelFlag = true;
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