using Autofac;

using DataLayer.Repository.IoC;

namespace Orders.WcfService.IoC
{	
	public static class AutofacContainerBuilder
	{
		/// <summary>
		/// Configures and builds Autofac IOC container.
		/// </summary>
		/// <returns></returns>
		public static IContainer BuildContainer()
		{
			var builder = new ContainerBuilder();

			builder.RegisterModule(new RepositoryModule());

			//builder.RegisterType(typeof(Service1)).As(typeof(IOrderWcfService)).SingleInstance();
			builder.RegisterType<Orders.WcfService.Service1>().AsSelf();;

			// register types
			//builder.RegisterType<EuropeanCarProvider>().As<ICarProvider>();
			//builder.RegisterType<CarProviderService>().As<ICarProviderService>();

			// build container
			return builder.Build();
		}
	}
}
