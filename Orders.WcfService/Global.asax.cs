using System;
using Autofac.Integration.Wcf;
using Orders.WcfService.IoC;

namespace Orders.WcfService
{
	public class Global : System.Web.HttpApplication
	{
		protected void Application_Start(object sender, EventArgs e)
		{
			var container = AutofacContainerBuilder.BuildContainer();
			AutofacHostFactory.Container = container;
		}
	}
}