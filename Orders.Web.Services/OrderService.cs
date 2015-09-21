namespace Orders.Web.Services
{
	using System.Collections.Generic;
	using System.Linq;
	using AutoMapper;

	using Orders.Web.Services.Service_References.ServiceReference;
	using OrderItem = Orders.Web.Domain.Models.OrderItem;

	public class OrderService
	{
		private readonly OrderServiceClient _wcfService;


		public OrderService()
		{
			_wcfService = new OrderServiceClient();		    
		}

		public IEnumerable<OrderItem> GetOrders()
		{
			var itemsDto = _wcfService.GetOrders().ToList();
			Mapper.CreateMap<Service_References.ServiceReference.OrderItem, OrderItem>();			
			var items = Mapper.Map<List<Service_References.ServiceReference.OrderItem>, IEnumerable<OrderItem>>(itemsDto);

			return items;
		}
	}
}
