using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
namespace TTTH.DataBase.Schema
{
    [Table("DangKyTemp")]
    public class DangKyTemp : TableHaveIdInt
    {
        [Required]
        [StringLength(50)]
        public string HoTenBe { set; get; }

        [Column(TypeName = "date")]
        public DateTime NgaySinh { set; get; }

        [Required]
        [StringLength(50)]
        public string HoTenBan { set; get; }

        [Required]
        [StringLength(50)]
        public string NgheNghiep { set; get; }

        [Required]
        [StringLength(15)]
        public string DienThoai { set; get; }

        [Required]
        [StringLength(255)]
        public string Email { set; get; }

        [Required]
        [StringLength(255)]
        public string DiaChi { set; get; }

        public int TrangThai { set; get; }

        public int IdKhoaHoc { set; get; }

        [StringLength(200)]
        public string GhiChu { set; get; }

        public virtual KhoaHoc KhoaHoc { set; get; }
    }
}