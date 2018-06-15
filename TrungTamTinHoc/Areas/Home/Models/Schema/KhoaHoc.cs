using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TrungTamTinHoc.Areas.Home.Models.Schema
{
    public class CacKhoaHoc
    {
        public string GioiThieuChung { set; get; }
        public List<KhoaHoc> DanhSachKhoaHoc { set; get; }
    }
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