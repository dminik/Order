using Orders.DataLayer.Context;

namespace DataLayer.Repository.Repositories.Base
{
	using System;
	using System.Collections.Generic;


	public interface IGenericRepository<T, in TKeyType> : IDisposable
		where T : Entity<TKeyType>
	{
		IEnumerable<T> GetAll();
		

		T GetByKey(TKeyType key);

		T Add(T entity);

		T Delete(T entity);

		void Delete(TKeyType id);

		void Edit(T entity);

		void Save();
	}
}