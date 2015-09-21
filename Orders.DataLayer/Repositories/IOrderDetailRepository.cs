namespace DataLayer.Repository.Repositories
{
	using System.Collections.Generic;

	using DataLayer.Model.Entities;
	using DataLayer.Repository.Repositories.Base;

	public interface IOrderDetailRepository : IGenericRepository<OrderDetail, int>
	{
		OrderDetail GetByBookId(string promoCode, int bookId);
		OrderDetail Add(int orderId, int bookId);	
		void Delete(int orderId, int bookId);
		int GetRestAmount(int bookId);
		IEnumerable<OrderDetail> GetByPromoCode(string promoCode);
	}
}