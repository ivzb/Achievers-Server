using Achiever.Common;
using System.Web;
using System.Web.Optimization;

namespace Achiever.Web
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/site")
                .Include("~/Scripts/custom/notificationModule.js")
                .Include("~/Scripts/custom/plugins.js")
                .Include("~/Scripts/custom/mine-menu.js")
                .Include("~/Scripts/site.js"));

            bundles.Add(new ScriptBundle("~/bundles/jquery")
                .Include("~/Scripts/jquery-{version}.js")
                .Include("~/Scripts/jquery.slimscroll.min.js")
                .Include("~/Scripts/noty/jquery.noty.packaged.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval")
                .Include("~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr")
                .Include("~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap")
                .Include("~/Scripts/bootstrap.js")
                .Include("~/Scripts/respond.js"));

            bundles.Add(new ScriptBundle("~/bundles/spcontext")
                .Include("~/Scripts/spcontext.js"));
            bundles.Add(new ScriptBundle("~/bundles/flot")

                .Include("~/Scripts/flot/excanvas.min.js")
                .Include("~/Scripts/flot/jquery.flot.js")
                .Include("~/Scripts/flot/jquery.flot.pie.js")
                .Include("~/Scripts/flot/jquery.flot.resize.js")
                .Include("~/Scripts/flot/jquery.flot.time.js")
                .Include("~/Scripts/flot/jquery.flot.tooltip.min.js")
                .Include("~/Scripts/flot/jquery.dataTables.min.js")
                .Include("~/Scripts/flot/dataTables.bootstrap.min.js")
                .Include("~/Scripts/flot/datatables-helper.js"));

            bundles.Add(new ScriptBundle("~/bundles/mvpready")
                .Include("~/Scripts/mvpready/mvpready-core.js")
                .Include("~/Scripts/mvpready/mvpready-helpers.js")
                .Include("~/Scripts/mvpready/mvpready-admin.js"));

            bundles.Add(new StyleBundle("~/Content/css")
                .Include("~/Content/bootstrap.min.css")
                .Include("~/Content/Site.css")
                .Include("~/Content/OpenSans.css")
                .Include("~/Content/font-awesome.min.css")
                .Include("~/Content/dataTables.bootstrap.css")
                .Include("~/Content/mvpready-admin.css"));
        }
    }
}
