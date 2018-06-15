using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;

namespace TTTH.DataBase.Schema
{
    [Table("CaiDatHeThong")]
    public partial class CaiDatHeThong : TableHaveLang
    {
        [StringLength(200)]
        public string DiaChi { get; set; }

        [StringLength(15)]
        public string SoDienThoai { get; set; }

        [StringLength(255)]
        public string LinkFB { get; set; }

        [StringLength(255)]
        public string LinkGoogle { get; set; }

        [StringLength(255)]
        public string Email { get; set; }

        [StringLength(255)]
        public string Skype { get; set; }

        public double MucBaoHiemXH { get; set; }

        public double ThueTNCN1 { get; set; }

        public double ThueTNCN2 { get; set; }

        public double ThueTNCN3 { get; set; }

        [Column(TypeName = "money")]
        public decimal GioiHanThueTNCN1 { get; set; }

        [Column(TypeName = "money")]
        public decimal GioiHanThueTNCN2 { get; set; }

        [Column(TypeName = "money")]
        public decimal GioiHanThueTNCN3 { get; set; }

        public string About { get; set; }

        public string WhyUs { get; set; }

        public string TomTat { get; set; }

        [StringLength(255)]
        public string Keyword { get; set; }

        [StringLength(255)]
        public string Author { get; set; }

        [StringLength(255)]
        public string Link { get; set; }

        public double KinhDo { get; set; }

        public double ViDo { get; set; }

        [StringLength(500)]
        public string GioiThieuChungKhoaHoc { get; set; }

        public string ChinhSachBaoMat { get; set; }

        public string DieuKhoanSuDung { get; set; }

        public string HuongDanSuDung { get; set; }

        [StringLength(255)]
        public string EmailHeThong { get; set; }

        [StringLength(255)]
        public string MatKhauEmail { get; set; }
    }
}
