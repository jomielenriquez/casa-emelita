using System.Web;
using System.Web.Optimization;

namespace casa_emelita
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new Bundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css"));

            // CASA AMELITA
            bundles.Add(new StyleBundle("~/Content/casa").Include(
                      "~/Content/Casa/bootstrap.min.css",
                      "~/Content/Casa/owl.carousel.min.css",
                      "~/Content/Casa/magnific-popup.css",
                      "~/Content/Casa/font-awesome.min.css",
                      "~/Content/Casa/themify-icons.css",
                      "~/Content/Casa/nice-select.css",
                      "~/Content/Casa/flaticon.css",
                      "~/Content/Casa/animate.css",
                      "~/Content/Casa/slicknav.css",
                      "~/Scripts/casa/datatables/datatables.min.css",
                      "~/Content/Casa/style.css"
                      ));
            bundles.Add(new ScriptBundle("~/scipt/casa").Include(
                      "~/Scripts/casa/vendor/modernizr-3.5.0.min.js",
                      "~/Scripts/casa/vendor/jquery-1.12.4.min.js",
                      "~/Scripts/casa/popper.min.js",
                      "~/Scripts/casa/bootstrap.min.js",
                      "~/Scripts/casa/isotope.pkgd.min.js",
                      "~/Scripts/casa/ajax-form.js",
                      "~/Scripts/casa/waypoints.min.js",
                      "~/Scripts/casa/jquery.counterup.min.js",
                      "~/Scripts/casa/imagesloaded.pkgd.min.js",
                      "~/Scripts/casa/scrollIt.js",
                      "~/Scripts/casa/jquery.scrollUp.min.js",
                      "~/Scripts/casa/wow.min.js",
                      "~/Scripts/casa/nice-select.min.js",
                      "~/Scripts/casa/jquery.slicknav.min.js",
                      "~/Scripts/casa/jquery.magnific-popup.min.js",
                      "~/Scripts/casa/plugins.js",
                      "~/Scripts/casa/sweetalert2.all.min.js",
                      "~/Scripts/casa/owl.carousel.min.js",
                      "~/Scripts/casa/contact.js",
                      "~/Scripts/casa/jquery.ajaxchimp.min.js",
                      "~/Scripts/casa/jquery.form.js",
                      "~/Scripts/casa/jquery.validate.min.js",
                      "~/Scripts/casa/mail-script.js",
                      "~/Scripts/casa/main.js",
                      "~/Scripts/casa/datatables/jquery.dataTables.min.js",
                      "~/Scripts/casa/datatables/datatables.min.js"
                      ));
            bundles.Add(new ScriptBundle("~/script/casa-footer").Include(
                        "~/Scripts/casa/vendor/modernizr-3.5.0.min.js",
                        "~/Scripts/casa/vendor/jquery-1.12.4.min.js",
                        "~/Scripts/casa/popper.min.js",
                        "~/Scripts/casa/bootstrap.min.js",
                        "~/Scripts/casa/isotope.pkgd.min.js",
                        "~/Scripts/casa/ajax-form.js",
                        "~/Scripts/casa/waypoints.min.js",
                        "~/Scripts/casa/jquery.counterup.min.js",
                        "~/Scripts/casa/imagesloaded.pkgd.min.js",
                        "~/Scripts/casa/scrollIt.js",
                        "~/Scripts/casa/jquery.scrollUp.min.js",
                        "~/Scripts/casa/wow.min.js",
                        "~/Scripts/casa/nice-select.min.js",
                        "~/Scripts/casa/jquery.slicknav.min.js",
                        "~/Scripts/casa/jquery.magnific-popup.min.js",
                        "~/Scripts/casa/plugins.js",
                        "~/Scripts/casa/contact.js",
                        "~/Scripts/casa/jquery.ajaxchimp.min.js",
                        "~/Scripts/casa/jquery.form.js",
                        "~/Scripts/casa/jquery.validate.min.js",
                        "~/Scripts/casa/mail-script.js",
                        "~/Scripts/casa/main.js"
                        ));
        }
    }
}
