using Orders.Web.Services.OrderServiceReference;

namespace Orders.Web.Services
{
	using System.Collections.Generic;
	using System.Linq;
	
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
			return itemsDto.ToModelList();
		}

		public string Ping(string str)
		{
			return _wcfService.Ping(str);
		}

		public Domain.Models.OrderItem GetByKey(int id)
		{
			var dto = _wcfService.GetByKey(id);
			return dto.ToModel();
		}

		public Domain.Models.OrderItem Add(Domain.Models.OrderItem item)
		{
			var dto = _wcfService.Add(item.ToDto());
			return dto.ToModel();
		}

		public void Delete(int id)
		{
			_wcfService.Delete(id);	
		}

		public void Update(Domain.Models.OrderItem item)
		{
			_wcfService.Update(item.ToDto());
		}
	}
}
