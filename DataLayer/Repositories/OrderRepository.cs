using Orders.DataLayer.Context;

namespace DataLayer.Repository.Repositories
{
	using DataLayer.Repository.Repositories.Base;

	public class OrderRepository : GenericRepository<OrderItems, int>, IOrderRepository
	{
		public OrderRepository(IMainContext context)
			: base(context)
		{
		}
	}
}