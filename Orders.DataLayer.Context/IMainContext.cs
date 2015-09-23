using System;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;

namespace Orders.DataLayer.Context
{
	public interface IMainContext : IDisposable
	{
		DbSet<OrderItems> OrderItems { get; set; }

		int SaveChanges();

		IDbSet<TEntity> Set<TEntity>() where TEntity : class;

		DbEntityEntry Entry(object entity);

		void SetModified(object entity);
	}
}
