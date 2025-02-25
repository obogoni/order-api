using Ardalis.Specification;

namespace Orders;

public interface IRepository<T> : IRepositoryBase<T> where T : class, IAggregateRoot
{

}
