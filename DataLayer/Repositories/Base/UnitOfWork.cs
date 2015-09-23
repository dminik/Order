using Orders.DataLayer.Context;

namespace DataLayer.Repository.Repositories.Base
{
	using System;


	/// <summary>
	/// The Entity Framework implementation of IUnitOfWork
	/// </summary>
	public class UnitOfWork : IUnitOfWork
	{
		/// <summary>
		/// The DbContext
		/// </summary>
		private IMainContext _context;

		/// <summary>
		/// Initializes a new instance of the UnitOfWork class.
		/// </summary>
		/// <param name="context">The object context</param>
		public UnitOfWork(IMainContext context)
		{
			this._context = context;
		}

		public IMainContext Context
		{
			get
			{
				return this._context;
			}
			set
			{
				this._context = value;
			}
		}

		/// <summary>
		/// Saves all pending changes
		/// </summary>
		/// <returns>The number of objects in an Added, Modified, or Deleted state</returns>
		public int Save()
		{
			// Save changes with the default options
			return this._context.SaveChanges();
		}

		/// <summary>
		/// Disposes the current object
		/// </summary>
		public void Dispose()
		{
			this.Dispose(true);
			GC.SuppressFinalize(this);
		}

		/// <summary>
		/// Disposes all external resources.
		/// </summary>
		/// <param name="disposing">The dispose indicator.</param>
		private void Dispose(bool disposing)
		{
			if (disposing)
			{
				if (this._context != null)
				{
					this._context.Dispose();
					this._context = null;
				}
			}
		}
	}
}