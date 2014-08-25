using System.Web;
using System.Web.Optimization;

namespace OneSolutionV3
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            bundles.Add(new ScriptBundle("~/bundles/site").Include(
                        "~/Scripts/bootstrap.min.js",
                        "~/Scripts/app.config.js",
                        "~/Scripts/demo.min.js",
                        "~/Scripts/app.min.js",
                        "~/Scripts/jarvis.widget.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/notification").Include(
            "~/Scripts/SmartNotification.min.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.min.css",
                      "~/Content/font-awesome.min.css",
                      "~/Content/smartadmin-production.min.css",
                      "~/Content/demo.min.css",
                      "~/Content/smartadmin-skins.min.css",
                      "~/Content/google.font.css"));
        }
    }
}
