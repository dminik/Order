using Orders.DataLayer.Context;

namespace DataLayer.Repository
{	
	using DataLayer.Repository.Repositories;
	using DataLayer.Repository.Repositories.Base;

	public class DataRepositories : UnitOfWork, IDataRepositories
	{		
		private OrderRepository _orderRepository;

		public DataRepositories(IMainContext context)
			: base(context)
		{
			this.Context = context;
		}
		
		public OrderRepository Orders
		{
			get
			{
				return this._orderRepository ?? (this._orderRepository = new OrderRepository(this.Context));
			}
		}		
	}
}