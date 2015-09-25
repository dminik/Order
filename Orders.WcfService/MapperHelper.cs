using System.Collections.Generic;

using AutoMapper;

namespace Orders.WcfService
{
	public static class MapperHelper
	{
		public static DataLayer.Context.OrderItems ToEntity(this OrderItem item)
		{
			if (item == null) return null;
			Mapper.CreateMap<OrderItem, DataLayer.Context.OrderItems>();
			return Mapper.Map<OrderItem, DataLayer.Context.OrderItems>(item);
		}

		public static OrderItem ToItem(this DataLayer.Context.OrderItems entity)
		{
			if (entity == null) return null;
			Mapper.CreateMap<DataLayer.Context.OrderItems, OrderItem>();
			return Mapper.Map<DataLayer.Context.OrderItems, OrderItem>(entity);
		}

		public static List<OrderItem> ToItemList(this List<DataLayer.Context.OrderItems> entityList)
		{
			if (entityList == null) return null;
			Mapper.CreateMap<DataLayer.Context.OrderItems, OrderItem>();
			return Mapper.Map<List<DataLayer.Context.OrderItems>, List<OrderItem>>(entityList);
		}
	}
}
