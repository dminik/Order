using System.Collections.Generic;
using System.Runtime.Serialization;
using System.ServiceModel;

using AutoMapper;

namespace Orders.WcfService
{	
	[ServiceContract]
	public interface IOrderWcfService
	{
		[OperationContract]
		string Ping(string str);

		[OperationContract]
		List<OrderItem> GetOrders();		

		[OperationContract]
		OrderItem GetByKey(int id);

		[OperationContract]
		OrderItem Add(OrderItem item);

		[OperationContract]
		void Delete(int id);

		[OperationContract]
		void Update(OrderItem item);		
	}
	
	[DataContract]
	public class OrderItem
	{
		[DataMember]
		public int Id { get; set; }

		[DataMember]
		public string Text { get; set; }

		[DataMember]
		public OrderStatus Status { get; set; }

		[DataMember]
		public string Email { get; set; }

		public DataLayer.Context.OrderItems ToEntity(OrderItem item)
		{
			Mapper.CreateMap<OrderItem, DataLayer.Context.OrderItems>();
			return Mapper.Map<OrderItem, DataLayer.Context.OrderItems>(item);
		}

		public OrderItem FromEntity(DataLayer.Context.OrderItems entity)
		{
			Mapper.CreateMap<DataLayer.Context.OrderItems, OrderItem>();
			return Mapper.Map<DataLayer.Context.OrderItems, OrderItem>(entity);
		}
	}

	[DataContract]
	public enum OrderStatus
	{
		[EnumMember]
		NotSet = -1,
		[EnumMember]
		New = 1,
		[EnumMember]
		InProgress = 2,
		[EnumMember]
		Done = 3
	}
}
