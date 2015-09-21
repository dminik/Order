namespace Orders.Web.Domain.Models
{
	public class OrderItem
	{
		public int Id { get; set; }
		
		public string Text { get; set; }

		public OrderStatus Status { get; set; }

		public string Email { get; set; }        
	}
}