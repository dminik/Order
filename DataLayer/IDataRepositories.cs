namespace DataLayer.Repository
{
	using DataLayer.Repository.Repositories;
	using DataLayer.Repository.Repositories.Base;

	public interface IDataRepositories : IUnitOfWork
	{		
		OrderRepository Orders { get; }
	}
}