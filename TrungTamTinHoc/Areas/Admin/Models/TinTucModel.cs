using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using TrungTamTinHoc.Areas.Admin.Models.Schema;
using TTTH.Common;
using TTTH.DataBase;
using TTTH.DataBase.Schema;

namespace TrungTamTinHoc.Areas.Admin.Models
{
    public class TinTucModel
    {
        DataContext context;
        public TinTucModel()
        {
            context = new DataContext();
        }
        public ResponseInfo XuLyTinTuc(DataTinTuc tinTuc)
        {
            DbContextTransaction transaction = context.Database.BeginTransaction();
            try
            {
                ResponseInfo result = new ResponseInfo();
                TinTuc tt = context.TinTuc.FirstOrDefault(x => x.BeautyId == tinTuc.BeautyId && x.Id != tinTuc.Id && !x.DelFlag);
                if (tt == null)
                {
                    tt = context.TinTuc.FirstOrDefault(x => x.Id == tinTuc.Id && !x.DelFlag);
                    if (tt == null)
                    {
                        tt = new TinTuc();
                        tt.BeautyId = tinTuc.BeautyId;
                        tt.SoLuongView = 0;
                        tt.HienThi = true;
                        tt.AnhMinhHoa = tinTuc.AnhMinhHoa;
                        tt.TinTucTrans.Add(new TinTucTrans
                        {
                            Lang = "vi",
                            TieuDe = tinTuc.TieuDe,
                            TomTat = tinTuc.TomTat,
                            NoiDung = tinTuc.NoiDung
                        });
                        tt.TinTucTrans.Add(new TinTucTrans
                        {
                            Lang = "en",
                            TieuDe = tinTuc.TieuDe,
                            TomTat = tinTuc.TomTat,
                            NoiDung = tinTuc.NoiDung
                        });
                        context.TinTuc.Add(tt);
                        context.SaveChanges();
                    }
                    else
                    {
                        tt.BeautyId = tinTuc.BeautyId;
                        tt.AnhMinhHoa = tinTuc.AnhMinhHoa;
                        TinTucTrans ttTransVi = tt.TinTucTrans.FirstOrDefault(x => x.Lang == "vi");
                        ttTransVi.TieuDe = tinTuc.TieuDe;
                        ttTransVi.NoiDung = tinTuc.NoiDung;
                        ttTransVi.TomTat = tinTuc.TomTat;
                        TinTucTrans ttTransEn = tt.TinTucTrans.FirstOrDefault(x => x.Lang == "en");
                        ttTransEn.TieuDe = tinTuc.TieuDe;
                        ttTransEn.NoiDung = tinTuc.NoiDung;
                        ttTransEn.TomTat = tinTuc.TomTat;
                        context.SaveChanges();
                    }
                    result.ThongTinBoSung1 = tt.Id.ToString();
                }
                else
                {
                    result.Code = 202;
                    result.MsgNo = 40;
                }
                transaction.Commit();
                return result;
            }
            catch (Exception e)
            {
                transaction.Rollback();
                throw e;
            }
        }
    }
}