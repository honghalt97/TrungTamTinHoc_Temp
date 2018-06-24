using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TrungTamTinHoc.Areas.Home.Models.Schema
{
    /// <summary>
    /// Class chứa danh sách các tin tức và thông tin giới thiệu chung tin tức.
    /// Author       :   HaLTH - 24/06/2018 - create
    /// </summary>
    /// <remarks>
    /// Package      :   Home.Models
    /// Copyright    :   Team Noname
    /// Version      :   1.0.0
    /// </remarks>
    public class CacBaiViet
    {
        public List<TinTuc> DanhSachBaiViet { set; get; }
    }
    /// <summary>
    /// Class chứa các thuộc tính của 1 tin tức lấy từ DB cho việc hiển thị danh sách các tin tức trên trang bài viết.
    /// Author       :   HaLTH - 24/06/2018 - create
    /// </summary>
    /// <remarks>
    /// Package      :   Home.Models
    /// Copyright    :   Team Noname
    /// Version      :   1.0.0
    /// </remarks>
    public class TinTuc
    {
        public string BeautyId { set; get; }
        public string TieuDe { set; get; }
        public string TomTat { set; get; }
        public string AnhMinhHoa { set; get; }
        public int SoLuongView { set; get; }
        public int SoLuongComment { set; get; }
        public int SoLuongDanhGia { set; get; }
        public int DiemDanhGia { set; get; }
        public bool HienThi { set; get; }
    }
}