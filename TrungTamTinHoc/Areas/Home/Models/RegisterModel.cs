using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TrungTamTinHoc.Areas.Home.Models.Schema;
using TblCauHinh = TTTH.DataBase.Schema.CauHinh;
using TblUser = TTTH.DataBase.Schema.User;
using TblGroupOfAccount = TTTH.DataBase.Schema.GroupOfAccount;
using TblAccount = TTTH.DataBase.Schema.Account;
using TblBieuMau = TTTH.DataBase.Schema.BieuMau;
using TTTH.DataBase;
using TTTH.Validate;
using static TTTH.Common.Enums.ConstantsEnum;
using TTTH.Common;
using System.Data.Entity;
using static TTTH.Common.Enums.MessageEnum;

namespace TrungTamTinHoc.Areas.Home.Models
{
    /// <summary>
    /// Class chứa các phương thức liên quan đến việc đăng ký tài khoản
    /// Author       :   QuyPN - 20/05/2018 - create
    /// </summary>
    /// <remarks>
    /// Package      :   Home.Models
    /// Copyright    :   Team Noname
    /// Version      :   1.0.0
    /// </remarks>
    public class RegisterModel
    {
        private DataContext context;
        public RegisterModel()
        {
            context = new DataContext();
        }
        /// <summary>
        /// Tạo tài khoản cho người dùng dựa vào thông tin đã cung cấp, sau đó gửi mail kích hoạt tài khoản.
        /// Author       :   QuyPN - 20/05/2018 - create
        /// </summary>
        /// <param name="newAccount">Thông tin tạo tài khoản của người dùng</param>
        /// <returns>Thông tin về việc tạo tài khoản thành công hay thất bại</returns>
        public ResponseInfo TaoAccount(NewAccount newAccount)
        {
            DbContextTransaction transaction = context.Database.BeginTransaction();
            try
            {
                ResponseInfo result = new ResponseInfo();
                TblCauHinh cauHinh = Common.LayCauHinh();
                // Kiểm tra xem username đã tồn tại hay chưa
                TblAccount account = context.Account.FirstOrDefault(x => x.Username == newAccount.Username && !x.DelFlag);
                if(account == null)
                {
                    // Kiểm tra xem email đã tồn tại hay chưa
                    account = context.Account.FirstOrDefault(x => x.Email == newAccount.Email && !x.DelFlag);
                    if(account == null)
                    {
                        // Tạo user mới
                        TblUser user = new TblUser
                        {
                            Ho = newAccount.Ho,
                            Ten = newAccount.Ten,
                            Avatar = Common.defaultAvata,
                            GioiTinh = newAccount.GioiTinh,
                            NgaySinh = newAccount.NgaySinh,
                            SoDienThoai = "",
                            CMND = "",
                            DiaChi = ""
                        };
                        // Tạo tài khoản đăng nhập cho user
                        account = new TblAccount
                        {
                            Username = newAccount.Username,
                            Password = BaoMat.GetMD5(newAccount.Password),
                            Email = newAccount.Email,
                            TokenActive = Common.GetToken(newAccount.Username),
                            IsActived = false,
                            IsActiveEmail = false,
                            TimeOfToken = DateTime.Now.AddHours(cauHinh.ThoiGianTonTaiToken),
                            SoLanDangNhapSai = 0,
                            KhoaTaiKhoanDen = DateTime.Now
                        };
                        // Cho tài khoản thuộc vào 1 group
                        account.GroupOfAccount.Add(new TblGroupOfAccount
                        {
                            IdGroup = (int)GroupAccount.User
                        });
                        user.Account.Add(account);
                        context.User.Add(user);
                        // Lưu vào CSDL
                        context.SaveChanges();
                        // Tiến hành gửi mail
                        SendEmail(account);
                        result.ThongTinBoSung1 = BaoMat.Base64Encode(account.TokenActive);
                    }
                    else
                    {
                        result.Code = 202;
                        result.MsgNo = 37;
                    }
                }
                else
                {
                    result.Code = 202;
                    result.MsgNo = 36;
                }
                transaction.Commit();
                return result;
            }
            catch (Exception e)
            {
                transaction.Rollback();
                throw e;
            }
        }

        /// <summary>
        /// Hàm gửi mail kích hoạt tài khoản theo email đã đăng ký
        /// Author       :   QuyPN - 20/05/2018 - create
        /// </summary>
        /// <param name="account">Tài khoản ddowwcj lưu trong DB</param>
        public void SendEmail(TblAccount account)
        {
            try
            {
                string lang = Common.GetLang();
                TblBieuMau bieuMau = context.BieuMau.FirstOrDefault(x => x.Id == (int)TemplateEnum.ActiveAccount && x.Lang == lang && !x.DelFlag);
                if (bieuMau != null)
                {
                    bieuMau.NoiDung = bieuMau.NoiDung.Replace("#linkActive", Common.domain + @"kich-hoat-tai-khoan?token="
                        + BaoMat.Base64Encode(account.TokenActive)
                        + "&&username=" + account.Username);
                    EmailService.Send(account.Email, bieuMau.TenBieuMau, bieuMau.NoiDung);
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        /// <summary>
        /// Kiểm tra email hoặc username đã tồn tại hay chưa.
        /// Author       :   QuyPN - 20/05/2018 - create
        /// </summary>
        /// <param name="value">giá trị của email hoặc username cần kiểm tra</param>
        /// <param name="type">type = 1: kiểm tra usernme; type = 2: kiểm tra email</param>
        /// <returns>Nếu có tồn tại trả về true, ngược lại trả về false</returns>
        public bool CheckExistAccount(string value, string type)
        {
            try
            {
                TblAccount acount = context.Account.FirstOrDefault(x => ((type == "1" && x.Username == value)
                    || (type == "2" && x.Email == value)) && !x.DelFlag);
                if(acount != null)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch(Exception e)
            {
                throw e;
            }
        }

        /// <summary>
        /// Kích hoạt tài khoản theo link đã gửi trong mail.
        /// Author       :   QuyPN - 20/05/2018 - create
        /// </summary>
        /// <param name="token">Token đang mã hóa Base64 được gửi đi trong mail</param>
        /// <param name="username">Tên đăng nhập mà user đăng ký được gửi kèm trong mail</param>
        /// <returns>Thông tin của việc kích hoạt tài khoản</returns>
        public ResponseInfo ActiveAccount(string token, string username)
        {
            DbContextTransaction transaction = context.Database.BeginTransaction();
            try
            {
                ResponseInfo result = new ResponseInfo();
                token = BaoMat.Base64Decode(token);
                TblAccount account = context.Account.FirstOrDefault(x => x.Username == username && x.TokenActive == token && !x.DelFlag);
                if(account == null)
                {
                    result.Code = 202;
                }
                else
                {
                    if(account.TimeOfToken.Value < DateTime.Now)
                    {
                        result.Code = 203;
                    }
                    else
                    {
                        account.IsActived = true;
                        account.IsActiveEmail = true;
                        account.TokenActive = "";
                        account.TimeOfToken = null;
                        context.SaveChanges();
                    }
                }
                transaction.Commit();
                return result;
            }
            catch (Exception e)
            {
                transaction.Rollback();
                throw e;
            }
        }

        /// <summary>
        /// Lấy Id Tài khoản cần active theo tokenAcitve.
        /// Author       :   QuyPN - 20/05/2018 - create
        /// </summary>
        /// <returns>Id của tài khoản lấy được, nếu lấy không có sẽ trả về 0</returns>
        public int GetIdAccountActive()
        {
            try
            {
                string tokenAccount = Common.GetCookie("tokenAccount");
                if (tokenAccount == "")
                {
                    return 0;
                }
                TblAccount account = context.Account.FirstOrDefault(x => x.TokenActive == tokenAccount && !x.DelFlag);
                if(account == null)
                {
                    return 0;
                }
                return account.Id;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        /// <summary>
        /// Sinh lại token và gửi lại Email theo id của tài khoản cần kích hoạt.
        /// Author       :   QuyPN - 20/05/2018 - create
        /// </summary>
        /// <param name="idAccount">Id của tài khoản cần gửi mail</param>
        /// <returns>Thông tin về việc gửi mail</returns>
        public ResponseInfo SendEmailById(int idAccount)
        {
            DbContextTransaction transaction = context.Database.BeginTransaction();
            try
            {
                ResponseInfo result = new ResponseInfo();
                TblAccount account = context.Account.FirstOrDefault(x => x.Id == idAccount && !x.DelFlag);
                if(account == null)
                {
                    result.Code = 202;
                    result.MsgNo = (int)MsgNO.EmailKhongTonTai;
                }
                else
                {
                    TblCauHinh cauHinh = Common.LayCauHinh();
                    account.TokenActive = Common.GetToken(account.Id);
                    account.TimeOfToken = DateTime.Now.AddHours(cauHinh.ThoiGianTonTaiToken);
                    context.SaveChanges();
                    SendEmail(account);
                    result.MsgNo = (int)MsgNO.DaGuiMailKichHoat;
                    result.ThongTinBoSung1 = BaoMat.Base64Encode(account.TokenActive);
                }
                transaction.Commit();
                return result;
            }
            catch (Exception e)
            {
                transaction.Rollback();
                throw e;
            }
        }

        /// <summary>
        /// Sinh lại token và gửi lại Email theo email của người dùng nhập vàot.
        /// Author       :   QuyPN - 20/05/2018 - create
        /// </summary>
        /// <param name="Email">Email đã đăng ký do người dùng nhập vào</param>
        /// <returns>Thông tin về việc gửi mail</returns>
        public ResponseInfo SendEmail(string Email)
        {
            DbContextTransaction transaction = context.Database.BeginTransaction();
            try
            {
                ResponseInfo result = new ResponseInfo();
                TblAccount account = context.Account.FirstOrDefault(x => x.Email == Email && !x.DelFlag);
                if (account == null)
                {
                    result.Code = 202;
                    result.MsgNo = (int)MsgNO.EmailKhongTonTai;
                }
                else
                {
                    TblCauHinh cauHinh = Common.LayCauHinh();
                    account.TokenActive = Common.GetToken(account.Id);
                    account.TimeOfToken = DateTime.Now.AddHours(cauHinh.ThoiGianTonTaiToken);
                    context.SaveChanges();
                    SendEmail(account);
                    result.MsgNo = (int)MsgNO.DaGuiMailKichHoat;
                    result.ThongTinBoSung1 = BaoMat.Base64Encode(account.TokenActive);
                }
                transaction.Commit();
                return result;
            }
            catch (Exception e)
            {
                transaction.Rollback();
                throw e;
            }
        }
    }
}