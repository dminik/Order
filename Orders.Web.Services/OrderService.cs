using Orders.Web.Services.ServiceReference;

namespace Orders.Web.Services
{
	using System.Collections.Generic;
	using System.Linq;
	using AutoMapper;
	
	using OrderItem = Orders.Web.Domain.Models.OrderItem;

	public class OrderService : IOrderService
	{
		private readonly IOrderWcfService _wcfService;


		public OrderService(IOrderWcfService wcfService)
		{
			_wcfService = wcfService;

		}

		public IEnumerable<OrderItem> GetOrders()
		{
			var itemsDto = _wcfService.GetOrders().ToList();

			Mapper.CreateMap<ServiceReference.OrderItem, OrderItem>();			
			var items = Mapper.Map<List<ServiceReference.OrderItem>, IEnumerable<OrderItem>>(itemsDto);

			return items;
		}
	}
}
