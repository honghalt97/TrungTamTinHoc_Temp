using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;

namespace TrungTamTinHoc.App_Start.Bundle
{
    public class HomeBundle
    {
        public static BundleCollection RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/public/js/login").Include(
                "~/public/js/common/md5.js",
                "~/public/js/home/login/index.js",
                "~/public/js/home/login/socialLogin.js"
            ));
            return bundles;
        }
    }
}