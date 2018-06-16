using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TTTH.Common;
using TTTH.DataBase;
using static TTTH.Common.Enums.ConstantsEnum;

namespace TrungTamTinHoc.Areas.Home.Models
{
    /// <summary>
    /// Xử lý dữ liệu cho các trang liên quan đến việc sử dụng website.
    /// Author       :   QuyPN - 16/06/2018 - create
    /// </summary>
    /// <remarks>
    /// Package      :   Home.Models
    /// Copyright    :   Team Noname
    /// Version      :   1.0.0
    /// </remarks>
    public class GuideLineModel
    {
        DataContext context;
        public GuideLineModel()
        {
            context = new DataContext();
        }

        /// <summary>
        /// Lấy văn bản hiển thị cho trang hướng dẫn sử dụng.
        /// Author       :   QuyPN - 16/06/2018 - create
        /// </summary>
        /// </returns>văn bản cho trang hướng dẫn sử dụng có trong DB</returns>
        public string LoadGuideLine()
        {
            try
            {
                string lang = Common.GetLang();
                return context.CaiDatHeThong.FirstOrDefault(x => x.Lang == lang && x.Id == (int)OtherEnum.IdSetting
                    && !x.DelFlag).HuongDanSuDung;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        /// <summary>
        /// Lấy văn bản hiển thị cho trang chính sách bảo mật.
        /// Author       :   QuyPN - 16/06/2018 - create
        /// </summary>
        /// </returns>Văn bản cho trang chính sách bảo mật có trong DB</returns>
        public string LoadPrivacyPolicy()
        {
            try
            {
                string lang = Common.GetLang();
                return context.CaiDatHeThong.FirstOrDefault(x => x.Lang == lang && x.Id == (int)OtherEnum.IdSetting
                    && !x.DelFlag).ChinhSachBaoMat;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        /// <summary>
        /// Lấy văn bản hiển thị cho trang điều khoản sử dụng.
        /// Author       :   QuyPN - 16/06/2018 - create
        /// </summary>
        /// </returns>Văn bản cho trang điều khoản sử dụng có trong DB</returns>
        public string LoadTermsConditions()
        {
            try
            {
                string lang = Common.GetLang();
                return context.CaiDatHeThong.FirstOrDefault(x => x.Lang == lang && x.Id == (int)OtherEnum.IdSetting
                    && !x.DelFlag).DieuKhoanSuDung;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}