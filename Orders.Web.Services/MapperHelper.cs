using System.Collections.Generic;

using AutoMapper;

using Orders.Web.Domain.Models;

namespace Orders.Web.Services
{
	public static class MapperHelper
	{
		public static OrderServiceReference.OrderItem ToDto(this OrderItem model)
		{
			if (model == null) return null;
			Mapper.CreateMap<OrderItem, OrderServiceReference.OrderItem>();
			return Mapper.Map<OrderItem, OrderServiceReference.OrderItem>(model);
		}

		public static OrderItem ToModel(this OrderServiceReference.OrderItem dto)
		{
			if (dto == null) return null;
			Mapper.CreateMap<OrderServiceReference.OrderItem, OrderItem>();
			return Mapper.Map<OrderServiceReference.OrderItem, OrderItem>(dto);
		}

		public static List<OrderItem> ToModelList(this List<OrderServiceReference.OrderItem> dtoList)
		{
			if (dtoList == null) return null;
			Mapper.CreateMap<OrderServiceReference.OrderItem, OrderItem>();
			return Mapper.Map<List<OrderServiceReference.OrderItem>, List<OrderItem>>(dtoList);
		}
	}
}
