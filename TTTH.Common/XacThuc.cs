using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TTTH.DataBase;
using TTTH.DataBase.Schema;

namespace TTTH.Common
{
    /// <summary>
    /// Tổng hợp các phương thức hay dùng để xác thực các vấn đền liên quan đến tài khoản.
    /// Author       :   QuyPN - 06/05/2018 - create
    /// </summary>
    /// <remarks>
    /// Package      :   TTTH.Common
    /// Copyright    :   Team Noname
    /// Version      :   1.0.0
    /// </remarks>
    public class XacThuc
    {
        /// <summary>
        /// Kiểm tra quyền truy cập một action trong controller.
        /// Author       :   QuyPN - 06/05/2018 - create
        /// </summary>
        /// <param name="token">
        /// token của user login.
        /// </param>
        /// <param name="controller">
        /// controller cần kiểm tra.
        /// </param>
        /// <param name="action">
        /// action trong controller cần kiểm tra.
        /// </param>
        /// <returns>
        /// Kết quả sau khi kiểm tra.
        /// </returns>
        public static bool CheckAuthentication(string token, string controller, string action)
        {
            try
            {
                return true;
            }
            catch
            {
                return false;
            }
        }
        /// <summary>
        /// Kiểm tra quyền truy cập một chức năng theo mã chức năng.
        /// Author       :   QuyPN - 06/05/2018 - create
        /// </summary>
        /// <param name="token">
        /// token của user login.
        /// </param>
        /// <param name="idFunction">
        /// Mã chức năng cần kiểm tra.
        /// </param>
        /// <returns>
        /// Kết quả sau khi kiểm tra.
        /// </returns>
        public static bool CheckAuthentication(string token, string idFunction)
        {
            try
            {
                return true;
            }
            catch
            {
                return false;
            }
        }
        /// <summary>
        /// Get IdAccount đang login
        /// Author       :   QuyPN - 26/05/2018 - create
        /// </summary>
        /// <returns>
        /// IdAccount nếu tồn tại, trả về 0 nếu không tồn tại
        /// </returns>
        public static int GetIdAccount()
        {
            try
            {
                string token = Common.GetCookie("token");
                DataContext context = new DataContext();
                TokenLogin tokenLogin = context.TokenLogin.FirstOrDefault(x => x.Token == token && x.ThoiGianTonTai >= DateTime.Now && !x.DelFlag);
                if (tokenLogin == null)
                {
                    return 0;
                }
                return tokenLogin.Account.Id;
            }
            catch
            {
                return 0;
            }
        }
        /// <summary>
        /// Get IdUser của Account đang login
        /// Author       :   QuyPN - 26/05/2018 - create
        /// </summary>
        /// <returns>
        /// IdUser nếu tồn tại, trả về 0 nếu không tồn tại
        /// </returns>
        public static int GetIdUser()
        {
            try
            {
                string token = Common.GetCookie("token");
                DataContext context = new DataContext();
                TokenLogin tokenLogin = context.TokenLogin.FirstOrDefault(x => x.Token == token && x.ThoiGianTonTai >= DateTime.Now && !x.DelFlag);
                if (tokenLogin == null)
                {
                    return 0;
                }
                return tokenLogin.Account.IdUser;
            }
            catch
            {
                return 0;
            }
        }
        /// <summary>
        /// Get Account đang login
        /// Author       :   QuyPN - 26/05/2018 - create
        /// </summary>
        /// <returns>
        /// Account nếu tồn tại, trả về null nếu không tồn tại
        /// </returns>
        public static Account GetAccount()
        {
            try
            {
                string token = Common.GetCookie("token");
                DataContext context = new DataContext();
                TokenLogin tokenLogin = context.TokenLogin.FirstOrDefault(x => x.Token == token && x.ThoiGianTonTai >= DateTime.Now && !x.DelFlag);
                if (tokenLogin == null)
                {
                    return null;
                }
                return tokenLogin.Account;
            }
            catch
            {
                return null;
            }
        }
        /// <summary>
        /// Get User đang login
        /// Author       :   QuyPN - 26/05/2018 - create
        /// </summary>
        /// <returns>
        /// User nếu tồn tại, trả về null nếu không tồn tại
        /// </returns>
        public static User GetUser()
        {
            try
            {
                string token = Common.GetCookie("token");
                DataContext context = new DataContext();
                TokenLogin tokenLogin = context.TokenLogin.FirstOrDefault(x => x.Token == token && x.ThoiGianTonTai >= DateTime.Now && !x.DelFlag);
                if (tokenLogin == null)
                {
                    return null;
                }
                return tokenLogin.Account.User;
            }
            catch
            {
                return null;
            }
        }
    }
}