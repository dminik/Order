namespace Orders.Web
{
    using System.Web.Mvc;
    using System.Web.Routing;

    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
			routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

			routes.MapRoute(
				name: "lang",
				url: "{lang}/Home/{action}",
				defaults: new { controller = "Home", action = "Index2" },
				constraints: new { lang = @"ru|en" }
			);

			routes.MapRoute(
				name: "Default",
				url: "Home/Index2/",
				defaults: new { controller = "Home", action = "Index2", lang = "ru" }
			);
        }
    }
}