using System;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;

namespace Orders.DataLayer.Context
{
	public abstract class Entity<TKey> : IEntity<TKey>
	{
		[Key]
		public virtual TKey Id { get; set; }
	}
}
