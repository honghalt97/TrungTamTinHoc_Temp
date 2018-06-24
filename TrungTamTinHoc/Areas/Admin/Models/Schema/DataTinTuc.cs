using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TrungTamTinHoc.Areas.Admin.Models.Schema
{
    public class DataTinTuc
    {
        public int Id { set; get; }
        public string TieuDe { set; get; }
        public string BeautyId { set; get; }
        public string TomTat { set; get; }
        public string NoiDung { set; get; }
        public string AnhMinhHoa { set; get; }
    }
}