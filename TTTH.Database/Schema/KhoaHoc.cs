using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;

namespace TTTH.DataBase.Schema
{
    [Table("KhoaHoc")]
    public partial class KhoaHoc : TableHaveIdInt
    {
        public KhoaHoc()
        {
            CommentKhoaHoc = new HashSet<CommentKhoaHoc>();
            DanhGiaKhoaHoc = new HashSet<DanhGiaKhoaHoc>();
            KhoaHocTrans = new HashSet<KhoaHocTrans>();
            LopHoc = new HashSet<LopHoc>();
            DangKyTemps = new HashSet<DangKyTemp>();
        }
        
        [Required]
        [StringLength(255)]
        public string BeautyId { get; set; }

        public int IdChuyenNganh { get; set; }

        public int SoLuongView { get; set; }

        public int SoLuongDaDangKy { get; set; }

        [Required]
        [StringLength(255)]
        public string AnhMinhHoa { get; set; }

        [Column(TypeName = "date")]
        public DateTime? NgayKhaiGiang { get; set; }

        public bool ChoPhepDangKy { set; get; }

        public bool HienThi { set; get; }

        [Required]
        [StringLength(100)]
        public string DoTuoi { set; get; }

        [Required]
        [StringLength(100)]
        public string ThoiGian { set; get; }

        [Column(TypeName = "date")]
        public DateTime? ThoiGianKetThuc { set; get; }

        [Required]
        [StringLength(100)]
        public string LichHoc { set; get; }

        [Required]
        [Column(TypeName = "money")]
        public decimal HocPhi { set; get; }

        [StringLength(200)]
        public string GhiChu { set; get; }

        public virtual ICollection<CommentKhoaHoc> CommentKhoaHoc { get; set; }

        public virtual ChuyenNganh ChuyenNganh { get; set; }
        
        public virtual ICollection<DanhGiaKhoaHoc> DanhGiaKhoaHoc { get; set; }
        
        public virtual ICollection<KhoaHocTrans> KhoaHocTrans { get; set; }
        
        public virtual ICollection<LopHoc> LopHoc { get; set; }

        public virtual ICollection<DangKyTemp> DangKyTemps { get; set; }
    }
}
