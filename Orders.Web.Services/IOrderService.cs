﻿namespace Orders.Web.Services
{
	using System.Collections.Generic;	
	using OrderItem = Orders.Web.Domain.Models.OrderItem;

	public interface IOrderService
	{
		IEnumerable<OrderItem> GetOrders();
		string Ping(string str);

		OrderItem GetByKey(int id);
		
		OrderItem Add(OrderItem item);
		
		void Delete(int id);
		
		void Update(OrderItem item);
	}
}
