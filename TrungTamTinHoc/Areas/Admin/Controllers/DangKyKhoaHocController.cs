using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TTTH.Common;
using TTTH.DataBase;
using TTTH.DataBase.Schema;
using static TTTH.Common.Enums.ConstantsEnum;
using static TTTH.Common.Enums.MessageEnum;

namespace TrungTamTinHoc.Areas.Admin.Controllers
{
    public class DangKyKhoaHocController : Controller
    {
        // GET: Admin/DangKyKhoaHoc
        public ActionResult Index()
        {
            if (Session["login"] == null)
            {
                return RedirectToAction("Index", "AdminLogin");
            }
            DataContext context = new DataContext();
            List<DangKyTemp> dangKy = context.DangKyTemp.Where(x => !x.DelFlag).OrderBy(x => x.TrangThai).ToList();
            return View(dangKy);
        }
        public JsonResult UpdateGhiChu(int id, string ghiChu)
        {
            ResponseInfo response = new ResponseInfo();
            try
            {
                DataContext context = new DataContext();
                DangKyTemp dangKy = context.DangKyTemp.FirstOrDefault(x => x.Id == id && !x.DelFlag);
                if (dangKy != null)
                {
                    dangKy.GhiChu = ghiChu;
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
        public JsonResult UpdateTrangThai(int id, int trangThai)
        {
            ResponseInfo response = new ResponseInfo();
            try
            {
                DataContext context = new DataContext();
                DangKyTemp dangKy = context.DangKyTemp.FirstOrDefault(x => x.Id == id && !x.DelFlag);
                if (dangKy != null)
                {
                    dangKy.TrangThai = trangThai;
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
        public JsonResult DeleteDangKy(int id)
        {
            ResponseInfo response = new ResponseInfo();
            try
            {
                DataContext context = new DataContext();
                DangKyTemp dangKy = context.DangKyTemp.FirstOrDefault(x => x.Id == id && !x.DelFlag);
                if (dangKy != null)
                {
                    dangKy.DelFlag = true;
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