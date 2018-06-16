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
    /// Xử lý các hoạt động tương tác với cơ sở dữ liệu trên trang home.
    /// Author       :   QuyPN - 11/06/2018 - create
    /// </summary>
    /// <remarks>
    /// Package      :   Home.Models
    /// Copyright    :   Team Noname
    /// Version      :   1.0.0
    /// </remarks>
    public class HomeModel
    {
        DataContext context;
        public HomeModel()
        {
            context = new DataContext();
        }

        /// <summary>
        /// Lấy danh sách slide được phép hiển thị từ DB theo ngôn ngữ.
        /// Author       :   QuyPN - 10/06/2018 - create
        /// </summary>
        /// <returns>Danh sách slide có trong DB</returns>
        public List<Slides> LoadSlide()
        {
            try
            {
                string lang = Common.GetLang();
                return context.Slide.Where(x => x.Lang == lang
                    && x.HienThi && !x.DelFlag).Select(x => new Slides
                    {
                        TieuDe = x.TieuDe,
                        ChiTiet = x.ChiTiet,
                        LinkAnh = x.LinkAnh,
                        Link = x.Link
                    }).ToList();
            }
            catch(Exception e)
            {
                throw e;
            }
        }

        /// <summary>
        /// Lấy danh sách những điều đạt được được phép hiển thị từ DB theo ngôn ngữ.
        /// Author       :   QuyPN - 15/06/2018 - create
        /// </summary>
        /// <returns>Danh sách những điều đạt được có trong DB</returns>
        public List<NhungDieuDatDuoc> LoadNhungDieuDatDuoc()
        {
            try
            {
                string lang = Common.GetLang();
                return context.NhungDieuDatDuoc.Where(x => x.Lang == lang
                    && x.IsShow && !x.DelFlag).Select(x => new NhungDieuDatDuoc
                    {
                        TieuDe = x.Title,
                        NoiDung = x.Content,
                        Icon = x.Icon,
                    }).ToList();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        /// <summary>
        /// Lấy văn bản hiển thị cho vùng "why us" trên trang home.
        /// Author       :   QuyPN - 10/06/2018 - create
        /// </summary>
        /// <returns>Văn bản "Why us" có trong DB</returns>
        public string LoadWhyUs()
        {
            try
            {
                string lang = Common.GetLang();
                return context.CaiDatHeThong.FirstOrDefault(x => x.Lang == lang  && x.Id == (int)OtherEnum.IdSetting
                    && !x.DelFlag).WhyUs;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        /// <summary>
        /// Lấy danh sách khóa học được phép hiển thị từ DB theo ngôn ngữ.
        /// Author       :   QuyPN - 15/06/2018 - create
        /// </summary>
        /// <returns>Danh sách khóa học có trong DB</returns>
        public CacKhoaHoc LoadKhoaHoc()
        {
            try
            {
                string lang = Common.GetLang();
                CacKhoaHoc cacKhoaHoc = new CacKhoaHoc();
                cacKhoaHoc.GioiThieuChung = context.CaiDatHeThong.FirstOrDefault(x => x.Lang == lang && x.Id == (int)OtherEnum.IdSetting
                    && !x.DelFlag).GioiThieuChungKhoaHoc;
                cacKhoaHoc.DanhSachKhoaHoc = context.KhoaHoc.Include("KhoaHocTrans")
                    .Where(x => x.HienThi && !x.DelFlag).Select(x => new KhoaHoc
                    {
                        BeautyId = x.BeautyId,
                        TenKhoaHoc = x.KhoaHocTrans.FirstOrDefault(y => y.Lang == lang).TenKhoaHoc,
                        TomTat = x.KhoaHocTrans.FirstOrDefault(y => y.Lang == lang).TomTat,
                        AnhMinhHoa = x.AnhMinhHoa,
                        NgayKhaiGiang = x.NgayKhaiGiang,
                        SoLuongView = x.SoLuongView,
                        SoLuongComment = x.CommentKhoaHoc.Count,
                        SoLuongDanhGia = x.DanhGiaKhoaHoc.Count,
                        DiemDanhGia = x.DanhGiaKhoaHoc.Sum(y => y.DiemDanhGia),
                        ChoPhepDangKy = x.ChoPhepDangKy
                    }).OrderBy(x => x.NgayKhaiGiang).Take(3).ToList();
                return cacKhoaHoc;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        /// <summary>
        /// Lấy danh sách giảng viên được phép hiển thị từ DB theo ngôn ngữ.
        /// Author       :   QuyPN - 10/06/2018 - create
        /// </summary>
        /// <returns>Danh sách giảng viên có trong DB</returns>
        public List<GiangVien> LoadGiangVien()
        {
            try
            {
                string lang = Common.GetLang();
                return context.GroupOfAccount.Where(x => x.IdGroup == (int)GroupAccount.Teacher && !x.DelFlag)
                    .Select(x => new GiangVien
                    {
                        IdUser = x.Account.IdUser,
                        Ho = x.Account.User.Ho,
                        Ten = x.Account.User.Ten,
                        Avatar = x.Account.User.Avatar,
                        MoTaBanThan = x.Account.User.ThongTinBoSung
                            .ThongTinBoSungTrans.FirstOrDefault(y => y.Lang == lang && !y.DelFlag).MoTaBanThan,
                        HienThi = x.Account.User.ThongTinBoSung.HienThi
                    }).Where(x => x.HienThi).ToList();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        /// <summary>
        /// Lấy văn bản hiển thị cho trang about.
        /// Author       :   QuyPN - 10/06/2018 - create
        /// </summary>
        /// </returns>Văn bản cho trang about có trong DB</returns>
        public string LoadAbout()
        {
            try
            {
                string lang = Common.GetLang();
                return context.CaiDatHeThong.FirstOrDefault(x => x.Lang == lang && x.Id == (int)OtherEnum.IdSetting
                    && !x.DelFlag).About;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}