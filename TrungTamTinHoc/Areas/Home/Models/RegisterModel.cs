using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TrungTamTinHoc.Areas.Home.Models.Schema;
using TblCauHinh = TTTH.DataBase.Schema.CauHinh;
using TblUser = TTTH.DataBase.Schema.User;
using TblGroupOfAccount = TTTH.DataBase.Schema.GroupOfAccount;
using TblAccount = TTTH.DataBase.Schema.Account;
using TTTH.DataBase;
using TTTH.Validate;
using static TTTH.Common.Enums.ConstantsEnum;
using TTTH.Common;

namespace TrungTamTinHoc.Areas.Home.Models
{
    public class RegisterModel
    {
        private DataContext context;
        public RegisterModel()
        {
            context = new DataContext();
        }
        public ResponseInfo TaoAccount(NewAccount newAccount)
        {
            try
            {
                ResponseInfo result = new ResponseInfo();
                TblCauHinh cauHinh = context.CauHinh.FirstOrDefault(x => x.Id == (int)OtherEnum.IdCauHinh);
                TblUser user = new TblUser
                {
                    Ho = newAccount.Ho,
                    Ten = newAccount.Ten,
                    Avatar = "http://2.bp.blogspot.com/-Fl8NZJZFq6w/U02LSHQ7iII/AAAAAAAAAHg/zpzikQfynpM/s1600/WAPHAYVL.MOBI-CONDAU+(11).gif",
                    GioiTinh = newAccount.GioiTinh,
                    NgaySinh = newAccount.NgaySinh,
                    SoDienThoai = "",
                    CMND = "",
                    DiaChi = ""
                };
                TblAccount account = new TblAccount
                {
                    Username = newAccount.Username,
                    Password = BaoMat.GetMD5(newAccount.Password),
                    Email = newAccount.Email,
                    TokenActive = Common.GetToken(0),
                    IsActived = false,
                    SoLanDangNhapSai = 0,
                    KhoaTaiKhoanDen = DateTime.Now
                };
                account.GroupOfAccount.Add(new TblGroupOfAccount
                {
                    IdGroup = (int)GroupAccount.User
                });
                user.Account.Add(account);
                context.User.Add(user);
                context.SaveChanges();
                return result;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}