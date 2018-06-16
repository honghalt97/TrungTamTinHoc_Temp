using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TrungTamTinHoc.Areas.Home.Models.Schema
{
    /// <summary>
    /// Class chứa danh sách các khóa học và thông tin giới thiệu chung khóa học.
    /// Author       :   QuyPN - 16/06/2018 - create
    /// </summary>
    /// <remarks>
    /// Package      :   Home.Models
    /// Copyright    :   Team Noname
    /// Version      :   1.0.0
    /// </remarks>
    public class CacKhoaHoc
    {
        public string GioiThieuChung { set; get; }
        public List<KhoaHoc> DanhSachKhoaHoc { set; get; }
    }
    /// <summary>
    /// Class chứa các thuộc tính của 1 kháo học lấy từ DB cho việc hiển thị danh sách các khóa học trên trang chủ.
    /// Author       :   QuyPN - 15/06/2018 - create
    /// </summary>
    /// <remarks>
    /// Package      :   Home.Models
    /// Copyright    :   Team Noname
    /// Version      :   1.0.0
    /// </remarks>
    public class KhoaHoc
    {
        public string BeautyId { set; get; }
        public string TenKhoaHoc { set; get; }
        public string TomTat { set; get; }
        public string AnhMinhHoa { set; get; }
        public DateTime? NgayKhaiGiang { set; get; }
        public int SoLuongView { set; get; }
        public int SoLuongComment { set; get; }
        public int SoLuongDanhGia { set; get; }
        public int DiemDanhGia { set; get; }
        public bool ChoPhepDangKy { set; get; }
    }
}