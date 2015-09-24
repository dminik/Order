using System.Collections.Generic;
using System.Runtime.Serialization;
using System.ServiceModel;

namespace Orders.WcfService
{
	// NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
	[ServiceContract]
	public interface IOrderWcfService
	{
		[OperationContract]
		List<OrderItem> GetOrders();

		[OperationContract]
		string Ping(string str);
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
