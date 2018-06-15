using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using TTTH.DataBase;

namespace TTTH.DataBase.Schema
{
    [Table("CauHinh")]
    public class CauHinh : TableHaveIdInt
    {
        [Required]
        public int SoLanChoPhepDangNhapSai { get; set; }
        [Required]
        public int ThoiGianKhoa { get; set; }
        [Required]
        public int ThoiGianTonTaiToken { get; set; }
        [Required]
        [StringLength(20)]
        public string FbAppId { set; get; }
        [Required]
        [StringLength(80)]
        public string GgClientId { set; get; }
    }
}