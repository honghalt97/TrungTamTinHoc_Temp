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
using DataAlbum = TrungTamTinHoc.Areas.Admin.Models.Schema.Album;

namespace TrungTamTinHoc.Areas.Admin.Controllers
{
    public class AlumController : Controller
    {
        // GET: Admin/Alum
        public ActionResult Index()
        {
            if (Session["login"] == null)
            {
                return RedirectToAction("Index", "AdminLogin");
            }
            DataContext context = new DataContext();
            List<Album> album = context.Album.Where(x => !x.DelFlag).ToList();
            return View(album);
        }
        public JsonResult ThemAnh(DataAlbum data)
        {
            ResponseInfo response = new ResponseInfo();
            try
            {
                DataContext context = new DataContext();
                context.Album.Add(new Album
                {
                    Link = data.Link,
                    Note = data.Note
                });
                context.SaveChanges();
            }
            catch (Exception e)
            {
                response.Code = (int)CodeResponse.ServerError;
                response.MsgNo = (int)MsgNO.ServerError;
                response.ThongTinBoSung1 = e.Message;
            }
            return Json(response, JsonRequestBehavior.AllowGet);
        }
        public JsonResult UpdateLink(int id, string link)
        {
            ResponseInfo response = new ResponseInfo();
            try
            {
                DataContext context = new DataContext();
                Album album = context.Album.FirstOrDefault(x => x.Id == id && !x.DelFlag);
                if (album != null)
                {
                    album.Link = link;
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
        public JsonResult UpdateCaption(int id, string note)
        {
            ResponseInfo response = new ResponseInfo();
            try
            {
                DataContext context = new DataContext();
                Album album = context.Album.FirstOrDefault(x => x.Id == id && !x.DelFlag);
                if (album != null)
                {
                    album.Note = note;
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
        public JsonResult DeleteAlbum(int id)
        {
            ResponseInfo response = new ResponseInfo();
            try
            {
                DataContext context = new DataContext();
                Album album = context.Album.FirstOrDefault(x => x.Id == id && !x.DelFlag);
                if (album != null)
                {
                    album.DelFlag = true;
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