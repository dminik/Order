using System.Reflection;
using Autofac;
using DataLayer.Repository.IoC;

namespace Orders.WcfService.IoC
{
	using Module = Autofac.Module;

	public class ServiceModule : Module
	{
		protected override void Load(ContainerBuilder builder)
		{
			builder.RegisterModule(new RepositoryModule());

			builder.RegisterAssemblyTypes(Assembly.Load("Orders.WcfService"))
				.Where(t => t.Name.EndsWith("Service"))
				.AsImplementedInterfaces()
				.InstancePerLifetimeScope();

			// builder.RegisterType(typeof(CacheServiceInMemory)).As(typeof(ICacheService)).SingleInstance();
			//builder.RegisterType(typeof(CacheServiceRedis)).As(typeof(ICacheService)).SingleInstance();
		}
	}
}
