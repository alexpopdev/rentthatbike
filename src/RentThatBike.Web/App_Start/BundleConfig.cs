using System;
using System.Configuration;
using System.Web;
using System.Web.Optimization;

namespace RentThatBike.Web
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/browser-support").Include(
                        "~/scripts/modernizr-{version}.js",
                        "~/scripts/respond.js"));

            bundles.Add(new ScriptBundle("~/bundles/basejs").Include(
                        "~/scripts/jquery-{version}.js",
                        "~/scripts/moment.js"));

          
            bundles.Add(new ScriptBundle("~/bundles/angular").Include(
                      "~/scripts/angular.js",
                      "~/scripts/tmhDynamicLocale.js",
                      "~/scripts/angular-route.js",
                      "~/scripts/angular-resource.js",
                      "~/scripts/ui-bootstrap-{version}.js",
                      "~/scripts/spin.js",
                      "~/scripts/angular-spinner.js"));
            
            bundles.Add(new ScriptBundle("~/bundles/app").Include(
                      "~/scripts/app/app.js",
                      //"~/scripts/app/filters/*.js",
                      //"~/scripts/app/directives/*.js",
                      "~/scripts/app/services/*.js",
                      "~/scripts/app/controllers/*.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/content/bootstrap.css",
                      "~/content/app/app.css"));

            BundleTable.EnableOptimizations = Convert.ToBoolean(ConfigurationManager.AppSettings.Get("BundleTable.EnableOptimizations"));
            
        }
    }
}
