using System.Web;
using System.Web.Optimization;

namespace RTS_Mensajeria
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Content/resources/js/jquery-3.2.1.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Utilice la versión de desarrollo de Modernizr para desarrollar y obtener información. De este modo, estará
            // ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Content/resources/js/bootstrap.min.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new StyleBundle("~/bundles/cssmaterial").Include(
                "~/Content/resources/css/mdb.min.css",
                "~/Content/resources/css/style.css"));

            bundles.Add(new StyleBundle("~/bundles/fontawesome").Include("~/Content/resources/font/font-awesome/all.min.css"));

            bundles.Add(new StyleBundle("~/bundles/datatables").Include(
                "~/Content/resources/js/addons/datatables.min.js",
                "~/Content/resources/js/addons/datatables-select.min.js"));

            bundles.Add(new StyleBundle("~/bundles/popper").Include("~/Content/resources/js/popper.min.js"));
            bundles.Add(new StyleBundle("~/bundles/jsmaterial").Include("~/Content/resources/js/mdb.min.js"));

            bundles.Add(new StyleBundle("~/bundles/compiledjs").Include("~/Content/resources/js/compiled.min.js")); 
            bundles.Add(new StyleBundle("~/bundles/compiledcss").Include("~/Content/resources/css/compiled.min.css"));
        }
    }
}
