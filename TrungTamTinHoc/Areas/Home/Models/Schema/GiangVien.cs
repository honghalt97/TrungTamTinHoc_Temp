using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TrungTamTinHoc.Areas.Home.Models.Schema
{
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