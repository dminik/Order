using Orders.DataLayer.Context;

namespace DataLayer.Repository.Repositories
{	
	using DataLayer.Repository.Repositories.Base;

	public interface IOrderRepository : IGenericRepository<OrderItems, int>
	{
		OrderItems GetByPromoCode(string promoCode);			
	}
}