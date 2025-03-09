using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;

namespace NextGenPC.App_Start
{
	public class BundleConfig
	{
		public static void RegisterBundles(BundleCollection bundles)
		{
            // Bundle pentru CSS
            bundles.Add(new StyleBundle("~/bundles/css").Include(
                "~/Scripts/plugins/pace/pace-theme-flash.css",
                "~/Scripts/plugins/bootstrap/css/bootstrap.min.css",
                "~/Content/fonts/font-awesome/css/font-awesome.css",
                "~/Content/css/animate.min.css",
                "~/Scripts/plugins/perfect-scrollbar/perfect-scrollbar.css",
                "~/Scripts/plugins/morris-chart/css/morris.css",
                "~/Scripts/plugins/jquery-ui/smoothness/jquery-ui.min.css",
                "~/Content/css/style.css",
                "~/Content/css/responsive.css"
            ));

            // Bundle pentru JS
            bundles.Add(new ScriptBundle("~/bundles/js").Include(
                "~/Scripts/js/jquery-3.2.1.min.js",
                "~/Scripts/js/popper.min.js",
                "~/Scripts/js/jquery.easing.min.js",
                "~/Scripts/plugins/bootstrap/js/bootstrap.min.js",
                "~/Scripts/plugins/pace/pace.min.js",
                "~/Scripts/plugins/perfect-scrollbar/perfect-scrollbar.min.js",
                "~/Scripts/plugins/viewport/viewportchecker.js",
                "~/Scripts/plugins/jquery-ui/smoothness/jquery-ui.min.js",
                "~/Scripts/plugins/sparkline-chart/jquery.sparkline.min.js",
                "~/Scripts/js/chart-sparkline.js",
                "~/Scripts/plugins/easypiechart/jquery.easypiechart.min.js",
                "~/Scripts/plugins/morris-chart/js/raphael-min.js",
                "~/Scripts/plugins/morris-chart/js/morris.min.js",
                "~/Scripts/js/eco-dashboard.js",
                "~/Scripts/js/scripts.js"
            ));

            // Activează minificarea în afara modului debug
            BundleTable.EnableOptimizations = true;
        }
	}
}