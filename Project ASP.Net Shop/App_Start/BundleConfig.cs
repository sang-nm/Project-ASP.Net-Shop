using System.Web;
using System.Web.Optimization;

namespace Project_ASP.Net_Shop
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

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js",
                      "~/Scripts/layout.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Data/Content/bootstrap.css",
                      "~/Data/Content/site.css",
                      "~/Data/Content/layout.css"));

            bundles.Add(new ScriptBundle("~/Admin/js").Include(
                      "~/Data/vendor/jquery/jquery.min.js",
                      "~/Data/vendor/bootstrap/js/bootstrap.bundle.min.js",
                      "~/Data/vendor/jquery-easing/jquery.easing.min.js",
                      "~/Data/vendor/chart.js/Chart.min.js",
                      "~/Data/vendor/datatables/jquery.dataTables.js",
                      "~/Data/vendor/datatables/dataTables.bootstrap4.js",
                      "~/Data/js/sb-admin.min.js",
                      "~/Data/js/sb-admin-datatables.min.js",
                      "~/Data/js/sb-admin-charts.min.js"));

            bundles.Add(new StyleBundle("~/Admin/css").Include(
                      "~/Data/vendor/bootstrap/css/bootstrap.min.css",
                      "~/Data/vendor/font-awesome/css/font-awesome.min.css",
                      "~/Data/vendor/datatables/dataTables.bootstrap4.css",
                      "~/Data/css/sb-admin.css"));
        }
    }
}
