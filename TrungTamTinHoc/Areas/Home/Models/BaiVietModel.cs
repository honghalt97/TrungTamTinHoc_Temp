using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TrungTamTinHoc.Areas.Home.Models.Schema;
using TTTH.Common;
using TTTH.DataBase;
using static TTTH.Common.Enums.ConstantsEnum;

namespace TrungTamTinHoc.Areas.Home.Models
{
    /// <summary>
    /// Class chứa các phương thức liên quan đến Bài viết
    /// Author       :   HaLTH - 24/06/2018 - create
    /// </summary>
    /// <remarks>
    /// Package      :   Home.Models
    /// Copyright    :   Team Noname
    /// Version      :   1.0.0
    /// </remarks>
    public class BaiVietModel
    {
        DataContext context;
        public BaiVietModel()
        {
            context = new DataContext();
        }

        /// <summary>
        /// Lấy danh sách tin tức được phép hiển thị từ DB theo ngôn ngữ.
        /// Author       :   HaLTH - 24/06/2018 - create
        /// </summary>
        /// <returns>Danh sách tin tức có trong DB</returns>
        public CacBaiViet LoadBaiViet()
        {
            try
            {
                string lang = Common.GetLang();
                CacBaiViet cacBaiViet = new CacBaiViet();
                cacBaiViet.DanhSachBaiViet = context.TinTuc.Include("TinTucTrans")
                    .Where(x => x.HienThi && !x.DelFlag).Select(x => new TinTuc
                    {
                        BeautyId = x.BeautyId,
                        TieuDe = x.TinTucTrans.FirstOrDefault(y => y.Lang == lang).TieuDe,
                        TomTat = x.TinTucTrans.FirstOrDefault(y => y.Lang == lang).TomTat,
                        AnhMinhHoa = x.AnhMinhHoa,
                        SoLuongView = x.SoLuongView,
                        SoLuongComment = x.CommentTinTuc.Count,
                        SoLuongDanhGia = x.DanhGiaTinTuc.Count,
                        DiemDanhGia = x.DanhGiaTinTuc.Count != 0 ? x.DanhGiaTinTuc.Sum(y => y.DiemDanhGIa) : 0,
                        HienThi = x.HienThi
                    }).ToList();
                return cacBaiViet;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}