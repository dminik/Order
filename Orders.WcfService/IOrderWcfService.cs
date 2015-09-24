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
		NotSet = -1,
		New = 1,
		InProgress = 2,
		Done = 3
	}
}
