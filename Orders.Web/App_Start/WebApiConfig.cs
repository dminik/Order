namespace Orders.Web
{
	using System.Web.Http;

	public static class WebApiConfig
	{
		public static void Register(HttpConfiguration config)
		{
			config.Routes.MapHttpRoute(
				name: "DefaultApi2",
				routeTemplate: "api/Order",
				defaults: new { controller = "Order", action = "GetOrders"}
			);

			config.Routes.MapHttpRoute(
				name: "DefaultApi3",
				routeTemplate: "api/Order/{id}",
				defaults: new { controller = "Order", id = RouteParameter.Optional }
			);

			config.EnableSystemDiagnosticsTracing();
		}
	}
}
