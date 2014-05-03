using System.Web;
using System.Web.Optimization;

namespace RentThatBike.Web
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/basejs").Include(
                        "~/Scripts/jquery-{version}.js",
                        "~/Scripts/moment.js"));

          
            bundles.Add(new ScriptBundle("~/bundles/angular").Include(
                      "~/Scripts/angular.js",
                      "~/Scripts/angular-route.js",
                      "~/Scripts/angular-resource.js",
                      "~/Scripts/ui-bootstrap-{version}.js"));
            
            bundles.Add(new ScriptBundle("~/bundles/app").Include(
                      "~/Scripts/app/app.js",
                      //"~/Scripts/app/filters/*.js",
                      //"~/Scripts/app/directives/*.js",
                      "~/Scripts/app/services/*.js",
                      "~/Scripts/app/controllers/*.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/app/app.css"));

            BundleTable.EnableOptimizations = false;
            
        }
    }
}
