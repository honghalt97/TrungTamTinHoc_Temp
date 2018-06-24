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
    public class KhoaHocModel
    {
        DataContext context;
        public KhoaHocModel()
        {
            context = new DataContext();
        }
        public ResponseInfo XuLyKhoaHoc(DataKhoaHoc khoaHoc)
        {
            DbContextTransaction transaction = context.Database.BeginTransaction();
            try
            {
                ResponseInfo result = new ResponseInfo();
                KhoaHoc kh = context.KhoaHoc.FirstOrDefault(x => x.BeautyId == khoaHoc.BeautyId && x.Id != khoaHoc.Id && !x.DelFlag);
                if(kh == null)
                {
                    kh = context.KhoaHoc.FirstOrDefault(x => x.Id == khoaHoc.Id && !x.DelFlag);
                    if (kh == null)
                    {
                        kh = new KhoaHoc();
                        kh.BeautyId = khoaHoc.BeautyId;
                        kh.IdChuyenNganh = 1;
                        kh.SoLuongView = 0;
                        kh.SoLuongDaDangKy = 0;
                        kh.AnhMinhHoa = khoaHoc.AnhMinhHoa;
                        kh.NgayKhaiGiang = khoaHoc.NgayKhaiGiang;
                        kh.ChoPhepDangKy = true;
                        kh.HienThi = true;
                        kh.DoTuoi = khoaHoc.DoTuoi;
                        kh.ThoiGian = khoaHoc.ThoiGian;
                        kh.ThoiGianKetThuc = khoaHoc.ThoiGianKetThuc;
                        kh.LichHoc = khoaHoc.LichHoc;
                        kh.HocPhi = Convert.ToDecimal(khoaHoc.HocPhi.Replace(",", ""));
                        kh.GhiChu = khoaHoc.GhiChu;
                        kh.KhoaHocTrans.Add(new KhoaHocTrans
                        {
                            Lang = "vi",
                            ChiTiet = khoaHoc.ChiTiet,
                            TomTat = khoaHoc.TomTat,
                            TenKhoaHoc = khoaHoc.TenKhoaHoc
                        });
                        kh.KhoaHocTrans.Add(new KhoaHocTrans
                        {
                            Lang = "en",
                            ChiTiet = khoaHoc.ChiTiet,
                            TomTat = khoaHoc.TomTat,
                            TenKhoaHoc = khoaHoc.TenKhoaHoc
                        });
                        context.KhoaHoc.Add(kh);
                        context.SaveChanges();
                    }
                    else
                    {
                        kh.BeautyId = khoaHoc.BeautyId;
                        kh.AnhMinhHoa = khoaHoc.AnhMinhHoa;
                        kh.NgayKhaiGiang = khoaHoc.NgayKhaiGiang;
                        kh.DoTuoi = khoaHoc.DoTuoi;
                        kh.ThoiGian = khoaHoc.ThoiGian;
                        kh.ThoiGianKetThuc = khoaHoc.ThoiGianKetThuc;
                        kh.LichHoc = khoaHoc.LichHoc;
                        kh.HocPhi = Convert.ToDecimal(khoaHoc.HocPhi.Replace(",",""));
                        kh.GhiChu = khoaHoc.GhiChu;
                        KhoaHocTrans khTransVi = kh.KhoaHocTrans.FirstOrDefault(x => x.Lang == "vi");
                        khTransVi.TenKhoaHoc = khoaHoc.TenKhoaHoc;
                        khTransVi.ChiTiet = khoaHoc.ChiTiet;
                        khTransVi.TomTat = khoaHoc.TomTat;
                        KhoaHocTrans khTransEn = kh.KhoaHocTrans.FirstOrDefault(x => x.Lang == "en");
                        khTransEn.TenKhoaHoc = khoaHoc.TenKhoaHoc;
                        khTransEn.ChiTiet = khoaHoc.ChiTiet;
                        khTransEn.TomTat = khoaHoc.TomTat;
                        context.SaveChanges();
                    }
                    result.ThongTinBoSung1 = kh.Id.ToString();
                }
                else
                {
                    result.Code = 202;
                    result.MsgNo = 40;
                }
                transaction.Commit();
                return result;
            }
            catch(Exception e)
            {
                transaction.Rollback();
                throw e;
            }
        }
    }
}