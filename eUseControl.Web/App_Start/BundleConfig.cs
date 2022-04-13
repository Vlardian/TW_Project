using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;

namespace eUseControl.Web
{
    public static class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            //Fonts
            bundles.Add(new StyleBundle("~/bundles/fontawesome/css").Include(
           "~/fonts/font-awesome-4.7.0/css/font-awesome.css", new CssRewriteUrlTransform()));

            bundles.Add(new StyleBundle("~/bundles/material-design/css").Include(
           "~/fonts/iconic/css/material-design-iconic-font.min.css", new CssRewriteUrlTransform()));

            bundles.Add(new StyleBundle("~/bundles/icon-font/css").Include(
           "~/fonts/linearicons-v1.0.0/icon-font.min.css", new CssRewriteUrlTransform()));


            //Vendors css
            bundles.Add(new StyleBundle("~/bundles/main/css").Include(
           "~/Vendors/css/main.css", new CssRewriteUrlTransform()));

            bundles.Add(new StyleBundle("~/bundles/util/css").Include(
           "~/Vendors/css/util.css", new CssRewriteUrlTransform()));


            //Vendors js
            bundles.Add(new ScriptBundle("~/bundles/main/js").Include(
           "~/Vendors/js/main.js"));

            bundles.Add(new ScriptBundle("~/bundles/map-custom/js").Include(
           "~/Vendors/js/map-custom.js"));

            bundles.Add(new ScriptBundle("~/bundles/slick-custom/js").Include(
           "~/Vendors/js/slick-custom.js"));

            bundles.Add(new ScriptBundle("~/bundles/validation/js").Include(
          "~/Scripts/jquery.validate.min.js"));

            //Vendors vendor styles
            bundles.Add(new StyleBundle("~/bundles/animate/css").Include(
           "~/Vendors/vendor/animate/animate.css", new CssRewriteUrlTransform()));

            bundles.Add(new StyleBundle("~/bundles/animsition/css").Include(
           "~/Vendors/vendor/animsition/css/animsition.min.css", new CssRewriteUrlTransform()));

            bundles.Add(new StyleBundle("~/bundles/bootstrap/css").Include(
           "~/Vendors/vendor/bootstrap/css/bootstrap.min.css", new CssRewriteUrlTransform()));

            bundles.Add(new StyleBundle("~/bundles/hamburger/css").Include(
           "~/Vendors/vendor/css-hamburgers/hamburgers.min.css", new CssRewriteUrlTransform()));

            bundles.Add(new StyleBundle("~/bundles/select2/css").Include(
           "~/Vendors/vendor/select2/select2.min.css", new CssRewriteUrlTransform()));

            bundles.Add(new StyleBundle("~/bundles/perfect-scrollbar/css").Include(
           "~/Vendors/vendor/perfect-scrollbar/perfect-scrollbar.css", new CssRewriteUrlTransform()));

            //Vendors vendor scripts
            bundles.Add(new ScriptBundle("~/bundles/animsition/js").Include(
           "~/Vendors/vendor/animsition/js/animsition.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap/js").Include(
           "~/Vendors/vendor/bootstrap/js/bootstrap.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/jquery/js").Include(
           "~/Vendors/vendor/jquery/jquery-3.2.1.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/popper/js").Include(
           "~/Vendors/vendor/bootstrap/js/popper.js"));

            bundles.Add(new ScriptBundle("~/bundles/select2/js").Include(
           "~/Vendors/vendor/select2/select2.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/magnific-popup/js").Include(
           "~/Vendors/vendor/MagnificPopup/jquery.magnific-popup.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/perfect-scrollbar/js").Include(
           "~/Vendors/vendor/perfect-scrollbar/perfect-scrollbar.min.js"));
        }
    }
}