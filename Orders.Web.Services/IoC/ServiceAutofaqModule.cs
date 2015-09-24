using System.ServiceModel;

using Autofac;
using Autofac.Integration.Wcf;

using Orders.Web.Services.OrderServiceReference;


namespace Orders.Web.Services.IoC
{
	using Module = Autofac.Module;

	public class ServiceAutofaqModule : Module
	{
		protected override void Load(ContainerBuilder builder)
		{			
			builder
			  .Register(c => new ChannelFactory<IOrderWcfService>(
				new BasicHttpBinding(),
				new EndpointAddress("http://localhost:81/OrderService.svc"))) // todo вынести в конфиг
			  .SingleInstance();

			builder
			  .Register(c => c.Resolve<ChannelFactory<IOrderWcfService>>().CreateChannel())
			  .As<IOrderWcfService>()
			  .UseWcfSafeRelease();
			
			builder.RegisterType<OrderService>().As(typeof(IOrderService));
		}
	}
}