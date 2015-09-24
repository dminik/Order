using System.ServiceModel;

using Autofac;
using Autofac.Integration.Wcf;

using Orders.Web.Services.ServiceReference;

namespace Orders.Web.Services.IoC
{
	using Module = Autofac.Module;

	public class ServiceAutofaqModule : Module
	{
		protected override void Load(ContainerBuilder builder)
		{
			
			// Register the channel factory for the service. Make it
			// SingleInstance since you don't need a new one each time.
			builder
			  .Register(c => new ChannelFactory<IOrderWcfService>(
				new BasicHttpBinding(),
				new EndpointAddress("http://localhost:81/OrderService.svc")))
			  .SingleInstance();

			// Register the service interface using a lambda that creates
			// a channel from the factory. Include the UseWcfSafeRelease()
			// helper to handle proper disposal.
			builder
			  .Register(c => c.Resolve<ChannelFactory<IOrderWcfService>>().CreateChannel())
			  .As<IOrderWcfService>()
			  .UseWcfSafeRelease();

			// You can also register other dependencies.
			builder.RegisterType<OrderService>().As(typeof(IOrderService));

			//var container = builder.Build();
		}
	}
}