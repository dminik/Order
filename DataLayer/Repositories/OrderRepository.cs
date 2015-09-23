using Orders.DataLayer.Context;

namespace DataLayer.Repository.Repositories
{
	using System.Linq;
	using DataLayer.Repository.Repositories.Base;

	public class OrderRepository : GenericRepository<OrderItems, int>, IOrderRepository
	{
		public OrderRepository(IMainContext context)
			: base(context)
		{
		}

		public OrderItems GetByPromoCode(string promoCode)
		{
			return FindBy(x => x.Text == promoCode).SingleOrDefault();
		}		
	}
}