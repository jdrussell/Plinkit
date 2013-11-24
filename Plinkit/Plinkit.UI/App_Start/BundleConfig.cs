using System.Web.Optimization;

namespace Plinkit.UI
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                        "~/Scripts/bootstrap.*"));
            bundles.Add(new ScriptBundle("~/bundles/popover").Include(
                "~/Scripts/tooltip.js",
                "~/Scripts/popover.js"));
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-1.*"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryui").Include(
                        "~/Scripts/jquery-ui*"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.unobtrusive*",
                        "~/Scripts/jquery.validate*"));

            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new StyleBundle("~/Content/css").Include("~/Content/css/bootstrap.css",
                "~/Content/css/plinkit.css",                                                 
                "~/Content/css/bootstrap-responsive.css",
                "~/Content/css/bic-calendar.css"));
        }
    }
}