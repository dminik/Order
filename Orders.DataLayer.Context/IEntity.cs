using System;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;

namespace Orders.DataLayer.Context
{
	public interface IEntity<T>
	{
		T Id { get; set; }
	}
}
