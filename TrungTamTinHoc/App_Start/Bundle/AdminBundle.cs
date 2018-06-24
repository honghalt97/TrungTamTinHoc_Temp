using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;

namespace TrungTamTinHoc.App_Start.Bundle
{
    public class AdminBundle
    {
        public static BundleCollection RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/public/js/admin/dashboard").Include(
                "~/public/js/admin/dashboard/index.js"
            ));

            bundles.Add(new ScriptBundle("~/public/js/adminLogin").Include(
                "~/public/js/common/md5.js",
                "~/public/js/admin/login/index.js"
            ));

            bundles.Add(new ScriptBundle("~/public/js/khoaHoc").Include(
                "~/public/assets/moment/moment.js",
                "~/public/assets/bootstrap-datetimepicker/src/js/bootstrap-datetimepicker.js",
                "~/public/assets/ckeditor4.9.2/ckeditor.js",
                "~/public/js/admin/khoahoc/index.js"
            ));
            bundles.Add(new StyleBundle("~/public/css/khoaHoc").Include(
                "~/public/assets/bootstrap-datetimepicker/build/css/bootstrap-datetimepicker.css",
                "~/public/css/admin/khoahoc/index.css"
            ));

            bundles.Add(new ScriptBundle("~/public/js/danhSachKhoaHoc").Include(
                "~/public/assets/switchery/dist/switchery.js",
                "~/public/assets/datatables.net/js/jquery.dataTables.js",
                "~/public/assets/datatables.net-bs/js/dataTables.bootstrap.js",
                "~/public/assets/datatables.net-responsive/js/dataTables.responsive.js",
                "~/public/assets/datatables.net-scroller/js/dataTables.scroller.js",
                "~/public/js/admin/khoahoc/danhsach.js"
            ));
            bundles.Add(new StyleBundle("~/public/css/danhSachKhoaHoc").Include(
                "~/public/assets/switchery/dist/switchery.css",
                "~/public/assets/datatables.net-bs/css/dataTables.bootstrap.css"
            ));

            bundles.Add(new ScriptBundle("~/public/js/tinTuc").Include(
                "~/public/assets/moment/moment.js",
                "~/public/assets/bootstrap-datetimepicker/src/js/bootstrap-datetimepicker.js",
                "~/public/assets/ckeditor4.9.2/ckeditor.js",
                "~/public/js/admin/tintuc/index.js"
            ));
            bundles.Add(new StyleBundle("~/public/css/tinTuc").Include(
                "~/public/assets/bootstrap-datetimepicker/build/css/bootstrap-datetimepicker.css",
                "~/public/css/admin/tintuc/index.css"
            ));

            bundles.Add(new ScriptBundle("~/public/js/danhSachTinTuc").Include(
                "~/public/assets/switchery/dist/switchery.js",
                "~/public/assets/datatables.net/js/jquery.dataTables.js",
                "~/public/assets/datatables.net-bs/js/dataTables.bootstrap.js",
                "~/public/assets/datatables.net-responsive/js/dataTables.responsive.js",
                "~/public/assets/datatables.net-scroller/js/dataTables.scroller.js",
                "~/public/js/admin/tintuc/danhsach.js"
            ));
            bundles.Add(new StyleBundle("~/public/css/danhSachTinTuc").Include(
                "~/public/assets/switchery/dist/switchery.css",
                "~/public/assets/datatables.net-bs/css/dataTables.bootstrap.css"
            ));

            bundles.Add(new ScriptBundle("~/public/js/danhSachDangKy").Include(
                "~/public/assets/datatables.net/js/jquery.dataTables.js",
                "~/public/assets/datatables.net-bs/js/dataTables.bootstrap.js",
                "~/public/assets/datatables.net-responsive/js/dataTables.responsive.js",
                "~/public/assets/datatables.net-scroller/js/dataTables.scroller.js",
                "~/public/js/admin/dangkykhoahoc/danhsach.js"
            ));
            bundles.Add(new StyleBundle("~/public/css/danhSachDangKy").Include(
                "~/public/assets/datatables.net-bs/css/dataTables.bootstrap.css"
            ));

            bundles.Add(new ScriptBundle("~/public/js/album").Include(
                "~/public/assets/datatables.net/js/jquery.dataTables.js",
                "~/public/assets/datatables.net-bs/js/dataTables.bootstrap.js",
                "~/public/assets/datatables.net-responsive/js/dataTables.responsive.js",
                "~/public/assets/datatables.net-scroller/js/dataTables.scroller.js",
               "~/public/js/admin/album/index.js"
           ));
            bundles.Add(new StyleBundle("~/public/css/album").Include(
                "~/public/assets/datatables.net-bs/css/dataTables.bootstrap.css"
            ));
            return bundles;
        }
    }
}