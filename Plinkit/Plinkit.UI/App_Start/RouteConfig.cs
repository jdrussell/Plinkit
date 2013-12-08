using System.Web.Http;
using System.Web.Mvc;
using System.Web.Routing;

namespace Plinkit.UI
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );            

            routes.MapRoute(
                "SeoLinks",
                "daily-dot-net-links/{category}",
                defaults: new { controller = "Home", action = "Links", date = "", category = "" }
            );

            routes.MapRoute(
                "Links",
                "daily-dot-net-links/{date}/{category}",
                defaults: new { controller = "Home", action = "Links", date = "", category = "" }
            );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );            
        }
    }
}