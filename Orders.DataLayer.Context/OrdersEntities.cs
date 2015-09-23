using System.Data.Entity;

namespace Orders.DataLayer.Context
{
	public partial class OrdersEntities : IMainContext
	{
		IDbSet<TEntity> IMainContext.Set<TEntity>()
		{
			return this.Set<TEntity>();
		}

		public void SetModified(object entity)
		{
			this.Entry(entity).State = EntityState.Modified;
		}
	}
}
