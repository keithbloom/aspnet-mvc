using System.Web.Mvc;
using System.Web.Routing;

namespace MvcExamples
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute("AjaxPartial", "ajax-partial", new {Controller = "AjaxPartial", Action = "Index"});
            routes.MapRoute("AjaxPartialSave", "ajax-partial/save", new { Controller = "AjaxPartial", Action = "Update" });

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}