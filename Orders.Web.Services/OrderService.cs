using Orders.Web.Services.OrderServiceReference;

namespace Orders.Web.Services
{
	using System.Collections.Generic;
	using System.Linq;
	using AutoMapper;
	
	public class OrderService : IOrderService
	{
		private readonly IOrderWcfService _wcfService;


		public OrderService(IOrderWcfService wcfService)
		{
			_wcfService = wcfService;
		}

		public IEnumerable<Domain.Models.OrderItem> GetOrders()
		{
			var itemsDto = _wcfService.GetOrders().ToList();

			Mapper.CreateMap<OrderItem, Domain.Models.OrderItem>();			
			var items = Mapper.Map<List<OrderItem>, IEnumerable<Domain.Models.OrderItem>>(itemsDto);

			return items;
		}

		public string Ping(string str)
		{
			return _wcfService.Ping(str);
		}
	}
}
