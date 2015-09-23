
using Autofac;

namespace Orders.DataLayer.Context
{
	public class EFModule : Module
	{
		protected override void Load(ContainerBuilder builder)
		{			
			builder.RegisterType(typeof(OrdersEntities)).As(typeof(IMainContext)).InstancePerLifetimeScope();
		}
	}
}
