using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using DataLayer.Repository.Repositories;

namespace Orders.WcfService
{	
	public class Service1 : IOrderService
	{
		private readonly IOrderRepository _orderRepository;

		public Service1()
		{
			_orderRepository = new OrderRepository();
		}
		
		public List<OrderItem> GetOrders()
		{
			var orderEntities =_orderRepository.GetAll().ToList();

			Mapper.CreateMap<DataLayer.Context.OrderItems, OrderItem>();
			var orderItems = Mapper.Map<List<DataLayer.Context.OrderItems>, IEnumerable<OrderItem>>(orderEntities).ToList();

			return orderItems;
		}
	}
}
