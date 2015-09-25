
namespace Orders.DataLayer.Context
{
	public interface IEntity<T>
	{
		T Id { get; set; }
	}
}
