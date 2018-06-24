using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using TTTH.DataBase;
using TTTH.DataBase.Schema;
using static TTTH.Common.Enums.ConstantsEnum;

namespace TTTH.Common
{
    /// <summary>
    /// Chứa các function sẽ sử dụng chung và nhiều lần trong dự án.
    /// Author       :   QuyPN - 06/05/2018 - create
    /// </summary>
    /// <remarks>
    /// Package      :   TTTH.Common
    /// Copyright    :   Team Noname
    /// Version      :   1.0.0
    /// </remarks>
    public class Common
    {
        public static string defaultAvata = "http://2.bp.blogspot.com/-Fl8NZJZFq6w/U02LSHQ7iII/AAAAAAAAAHg/zpzikQfynpM/s1600/WAPHAYVL.MOBI-CONDAU+(11).gif";
        public static string domain = @"https://localhost:44371/";
        /// <summary>
        /// Sinh chuỗi token ngẫu nhiên theo id account đăng nhập, độ dài mặc định 40 ký tự.
        /// Author       :   QuyPN - 06/05/2018 - create
        /// </summary>
        /// <param name="id">
        /// id của account đăng nhập.
        /// </param>
        /// <param name="length">
        /// Dộ dài của token, mặc định 40 ký tự
        /// </param>
        /// <returns>
        /// Chuỗi token.
        /// </returns>
        public static string GetToken(int id, int length = 80)
        {
            string token = "";
            Random ran = new Random();
            string tmp = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789_-";
            for (int i = 0; i < length; i++)
            {
                token += tmp.Substring(ran.Next(0, 63), 1);
            }
            token += id;
            return token;
        }
        /// <summary>
        /// Sinh chuỗi token ngẫu nhiên theo id account đăng nhập, độ dài mặc định 40 ký tự.
        /// Author       :   QuyPN - 06/05/2018 - create
        /// </summary>
        /// <param name="str">
        /// Chuỗi không trùng nhau sẽ cộng thêm vào token.
        /// </param>
        /// <param name="length">
        /// Dộ dài của token, mặc định 40 ký tự
        /// </param>
        /// <returns>
        /// Chuỗi token.
        /// </returns>
        public static string GetToken(string str, int length = 80)
        {
            string token = "";
            Random ran = new Random();
            string tmp = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789_-";
            for (int i = 0; i < length; i++)
            {
                token += tmp.Substring(ran.Next(0, 63), 1);
            }
            token += str;
            return token;
        }
        /// <summary>
        /// Chuyển từ tiếng việt có dấu thành tiếng việt không dấu.
        /// Author       :   QuyPN - 06/05/2018 - create
        /// </summary>
        /// <param name="s">
        /// Chuỗi tiếng việt cần chuyển.
        /// </param>
        /// <returns>
        /// Kết quả sau khi chuyển.
        /// </returns>
        public static string ConvertToUnSign(string s)
        {
            Regex regex = new Regex("\\p{IsCombiningDiacriticalMarks}+");
            string temp = s.Normalize(NormalizationForm.FormD);
            return regex.Replace(temp, String.Empty).Replace('\u0111', 'd').Replace('\u0110', 'D');
        }
        /// <summary>
        /// Lấy dữ liệu từ cookies theo khóa, nếu không có dữ liệu thì trả về theo dữ liệu mặc định truyền vào hoặc rỗng
        /// Author          : QuyPN - 27/05/2018 - create
        /// </summary>
        /// <param name="key">Khóa cần lấy dữ liệu trong cookie</param>
        /// <param name="returnDefault">Kết quả trả về mặc định nếu không có dữ lieeujt rong cookie, mặc định là chuỗi rỗng</param>
        /// <returns>Giá trị lưu trữ trong cookie</returns>
        public static string GetCookie(string key, string returnDefault = "")
        {
            try
            {
                var httpCookie = HttpContext.Current.Request.Cookies[key];
                if (httpCookie == null)
                {
                    return returnDefault;
                }
                return BaoMat.Base64Decode(HttpUtility.UrlDecode(httpCookie.Value));
            }
            catch
            {
                return returnDefault;
            }
        }
        /// <summary>
        /// Lấy lại mã ngôn ngữ được lưu ỏ cookies của client.
        /// Author       :   QuyPN - 28/05/2018 - create
        /// </summary>
        /// <returns>Mã ngôn ngữ lấy được</returns>
        public static string GetLang()
        {
            try
            {
                string lang = Common.GetCookie("lang", "vi");
                DataContext context = new DataContext();
                Language language = context.Language.FirstOrDefault(x => x.Id == lang && !x.DelFlag);
                if(language == null)
                {
                    return "vi";
                }
                return language.Id;
            }
            catch
            {
                return "vi";
            }
        }
        /// <summary>
        /// Lấy dữ liệu các cấu hình liên quan đến development
        /// Author       :   QuyPN - 10/06/2018 - create
        /// </summary>
        /// <returns>Cấu hình đã lưu của hệ thống</returns>
        public static CauHinh LayCauHinh()
        {
            try
            {
                DataContext context = new DataContext();
                CauHinh cauHinh = context.CauHinh.FirstOrDefault(x => x.Id == (int)OtherEnum.IdCauHinh);
                if(cauHinh != null)
                {
                    return cauHinh;
                }
                return new CauHinh();
            }
            catch
            {
                return new CauHinh();
            }
        }
        /// <summary>
        /// Lấy dữ liệu cài đặt các thông tin chung của hệ thống
        /// Author       :   QuyPN - 10/06/2018 - create
        /// </summary>
        /// <returns>Cài đặt đã lưu của hệ thống</returns>
        public static CaiDatHeThong LayCaiDat()
        {
            try
            {
                DataContext context = new DataContext();
                string lang = Common.GetLang();
                CaiDatHeThong caiDat = context.CaiDatHeThong.FirstOrDefault(x => x.Id == (int)OtherEnum.IdSetting && x.Lang == lang && x.Id == (int)OtherEnum.IdSetting);
                if (caiDat != null)
                {
                    return caiDat;
                }
                return new CaiDatHeThong();
            }
            catch
            {
                return new CaiDatHeThong();
            }
        }

        public static int SoLuongDangKy()
        {
            try
            {
                DataContext context = new DataContext();
                return context.DangKyTemp.Count(x => x.TrangThai == 1 && !x.DelFlag);
            }
            catch
            {
                return 0;
            }
        }
    }
}