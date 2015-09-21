namespace Orders.Web.Models
{
	using System.Data.Entity;

	using Orders.Web.Domain.Models;

	public class OrderItemContext : DbContext
	{
		public OrderItemContext()
			: base("name=DefaultConnection")
		{
		}

		public DbSet<OrderItem> OrderItems { get; set; }
	}
}