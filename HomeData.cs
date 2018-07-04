using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TrungTamTinHoc.Areas.Home.Models.Schema
{
    /// <summary>
    /// Class chứa tất cả các dữ liệu cần thiết cho trang chủ.
    /// Author       :   QuyPN - 10/06/2018 - create
    /// </summary>
    /// <remarks>
    /// Package      :   Home.Models
    /// Copyright    :   Team Noname
    /// Version      :   1.0.0
    /// </remarks>
    public class HomeData
    {
        public List<Slides> Slides { set; get; }
        public List<NhungDieuDatDuoc> NhungDieuDatDuoc { set; get; }
        public string WhyUs { set; get; }
        public CacKhoaHoc CacKhoaHoc { set; get; }
        public List<GiangVien> DanhSachGiangVien { set; get; }

        [Required(ErrorMessage = "1")]
        [MaxLength(255, ErrorMessage = "2")]
        [EmailAddress(ErrorMessage = "5")]
        public string Email { set; get; }
    }
}