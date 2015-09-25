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
				url: "{lang}/{controller}/{action}",
				defaults: new { controller = "Home", action = "Index" },
				constraints: new { lang = @"ru|en" }
			);

			routes.MapRoute(
				name: "Default",
				url: "{controller}/{action}",
				defaults: new { controller = "Home", action = "Index", lang = "ru" }
			);
        }
    }
}