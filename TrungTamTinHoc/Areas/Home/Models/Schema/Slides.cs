using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TrungTamTinHoc.Areas.Home.Models.Schema
{
    /// <summary>
    /// Class chứa các thuộc tính càn thiết lấy từ DB cho việc hiển thị các slide trên trang chủ
    /// Author       :   QuyPN - 16/06/2018 - create
    /// </summary>
    /// <remarks>
    /// Package      :   Home.Models
    /// Copyright    :   Team Noname
    /// Version      :   1.0.0
    /// </remarks>
    public class Slides
    {
        public string LinkAnh { get; set; }
        public string TieuDe { get; set; }
        public string ChiTiet { get; set; }
        public string Link { get; set; }
    }
}