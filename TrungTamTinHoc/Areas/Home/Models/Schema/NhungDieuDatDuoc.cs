using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TrungTamTinHoc.Areas.Home.Models.Schema
{
    /// <summary>
    /// Class chứa các thuộc tính cần thiết lấy từ DB cho việc hiển thị những điều đạt được trên trang chủ
    /// Author       :   QuyPN - 15/06/2018 - create
    /// </summary>
    /// <remarks>
    /// Package      :   Home.Models
    /// Copyright    :   Team Noname
    /// Version      :   1.0.0
    /// </remarks>
    public class NhungDieuDatDuoc
    {
        public string TieuDe { set; get; }
        public string NoiDung { set; get; }
        public string Icon { set; get; }
    }
}