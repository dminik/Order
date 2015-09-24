using System.Collections.Generic;
using System.Linq;
using AutoMapper;
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

			Mapper.CreateMap<DataLayer.Context.OrderItems, OrderItem>();
			var orderItems = Mapper.Map<List<DataLayer.Context.OrderItems>, IEnumerable<OrderItem>>(orderEntities).ToList();

			return orderItems;
		}

		public string Ping(string str)
		{
			return str;
		}
	}
}
