using System.Reflection;
using System.Web.Http;
using System.Web.Mvc;

using Autofac;
using Autofac.Integration.Mvc;
using Autofac.Integration.WebApi;

using Orders.Web.Services.IoC;

namespace Orders.Web.IoC
{
	public class IoCConfig
	{
		public static void Register()
		{			
			var builder = new ContainerBuilder();

			builder.RegisterControllers(typeof(MvcApplication).Assembly).PropertiesAutowired();
			builder.RegisterApiControllers(Assembly.GetExecutingAssembly());

			builder.RegisterModule(new ServiceAutofaqModule());

			var container = builder.Build();
			GlobalConfiguration.Configuration.DependencyResolver = new AutofacWebApiDependencyResolver(container);

			DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
		}
	}
}