using System.Collections.Generic;
using System.Linq;
using DataLayer.Repository.Repositories;

namespace Orders.WcfService
{
	public class Service1 : IOrderWcfService		
	{
		private readonly IOrderRepository _orderRepository;

		public Service1(IOrderRepository orderRepository)
		{
			_orderRepository = orderRepository;			
		}
		
		public List<OrderItem> GetOrders()
		{
			var orderEntities = _orderRepository.GetAll().ToList();
			return orderEntities.ToItemList();			
		}

		public OrderItem GetByKey(int id)
		{
			var entity = _orderRepository.GetByKey(id);
			return entity.ToItem();
		}

		public OrderItem Add(OrderItem item)
		{						
			var entity = _orderRepository.Add(item.ToEntity());			
			return entity.ToItem();
		}

		public void Delete(int id)
		{
			_orderRepository.Delete(id);			
		}

		public void Update(OrderItem item)
		{			
			_orderRepository.Edit(item.ToEntity());
		}

		public string Ping(string str)
		{
			return str;
		}
	}
}
