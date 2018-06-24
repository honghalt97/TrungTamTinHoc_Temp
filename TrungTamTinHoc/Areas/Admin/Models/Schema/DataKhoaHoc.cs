using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TrungTamTinHoc.Areas.Admin.Models.Schema
{
    public class DataKhoaHoc
    {
        public int Id { set; get; }
        public string TenKhoaHoc { set; get; }
        public string BeautyId { set; get; }
        public string TomTat { set; get; }
        public string DoTuoi { set; get; }
        public string ThoiGian { set; get; }
        public DateTime? NgayKhaiGiang { set; get; }
        public DateTime? ThoiGianKetThuc { set; get; }
        public string LichHoc { set; get; }
        public string HocPhi { set; get; }
        public string ChiTiet { set; get; }
        public string AnhMinhHoa { set; get; }
        public string GhiChu { set; get; }
    }
}