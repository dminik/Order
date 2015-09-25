using Autofac;

using DataLayer.Repository.IoC;

namespace Orders.WcfService.IoC
{	
	public static class AutofacContainerBuilder
	{
		public static IContainer BuildContainer()
		{
			var builder = new ContainerBuilder();

			builder.RegisterModule(new RepositoryModule());

			builder.RegisterType<Service1>();
			
			return builder.Build();
		}
	}
}
