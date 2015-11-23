using System.Web;
using System.Web.Optimization;

namespace PrototipeSIL
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Content/bower_components/jquery/jquery.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Content/bower_components/bootstrap/dist/js/bootstrap.min.js",
                      "~/Content/js/jquery.cookie.js",
                      "~/Content/bower_components/moment/min/moment.min.js",
                      "~/Content/bower_components/fullcalendar/dist/fullcalendar.min.js",
                      "~/Content/js/jquery.dataTables.min.js",
                      "~/Content/bower_components/chosen/chosen.jquery.min.js",
                      "~/Content/bower_components/colorbox/jquery.colorbox-min.js",
                      "~/Content/js/jquery.noty.js",
                      "~/Content/bower_components/responsive-tables/responsive-tables.js",
                      "~/Content/bower_components/bootstrap-tour/build/js/bootstrap-tour.min.js",
                      "~/Content/js/jquery.raty.min.js",
                      "~/Content/js/jquery.iphone.toggle.js",
                      "~/Content/js/jquery.autogrow-textarea.js",
                      "~/Content/js/jquery.uploadify-3.1.min.js",
                      "~/Content/js/jquery.history.js",
                      "~/Content/js/charisma.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/css/bootstrap-cerulean.min.css",
                      "~/Content/css/charisma-app.css",
                      "~/Content/bower_components/fullcalendar/dist/fullcalendar.css",
                      "~/Content/bower_components/fullcalendar/dist/fullcalendar.print.css",
                      "~/Content/bower_components/chosen/chosen.min.css",
                      "~/Content/bower_components/colorbox/example3/colorbox.css",
                      "~/Content/bower_components/responsive-tables/responsive-tables.css",
                      "~/Content/bower_components/bootstrap-tour/build/css/bootstrap-tour.min.css",
                      "~/Content/css/jquery.noty.css",
                      "~/Content/css/noty_theme_default.css",
                      "~/Content/css/elfinder.min.css",
                      "~/Content/css/elfinder.theme.css",
                      "~/Content/css/jquery.iphone.toggle.css",
                      "~/Content/css/uploadify.css",
                      "~/Content/css/animate.min.css"));
        }
    }
}
