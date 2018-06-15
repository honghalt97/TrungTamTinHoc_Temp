using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TrungTamTinHoc.Areas.Home.Models.Schema
{
    public class HomeData
    {
        public List<Slides> Slides { set; get; }
        public List<NhungDieuDatDuoc> NhungDieuDatDuoc { set; get; }
        public string WhyUs { set; get; }
        public CacKhoaHoc CacKhoaHoc { set; get; }
        public List<GiangVien> DanhSachGiangVien { set; get; }
    }
}