using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TrungTamTinHoc.Areas.Home.Models.Schema
{
    /// <summary>
    /// Class chứa các thông tin của gaios viên lấy từ DB cho việc hiển thị các giáo viên trên trang chủ.
    /// Author       :   QuyPN - 16/06/2018 - create
    /// </summary>
    /// <remarks>
    /// Package      :   Home.Models
    /// Copyright    :   Team Noname
    /// Version      :   1.0.0
    /// </remarks>
    public class GiangVien
    {
        public int IdUser { set; get; }
        public string Ho { set; get; }
        public string Ten { set; get; }
        public string Avatar { set; get; }
        public string MoTaBanThan { set; get; }
        public bool HienThi { set; get; }
    }
}