using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TTTH.Common.Enums
{
    public class MessageEnum
    {
        public enum MsgNO
        {
            BatBuocNhap = 1,
            SaiMaxlength = 2,
            SaiMinLength = 3,
            SaiFormatNgayThang = 4,
            EmailSaiFormat = 5,
            SaiFormatSDT = 6,
            SaiNgayBatDauVaKetThuc = 7,
            PhaiLonHon0 = 11,
            SaiFormatMatKhau = 19,
            KhongCoTaiKhoan = 28,
            TaiKhoanBiKhoa = 29,
            ChuaKichHoatTaiKhoan = 30,
            MatKhauKhongDung = 31,
            SaiQuaSoLanChoPhep = 32,
            XacThucKhongHopLe = 33,
            ServerError = 100
        }
    }
}