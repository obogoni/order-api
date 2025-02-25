using Ardalis.Specification.EntityFrameworkCore;

namespace Orders.Infrastructure.Persistance;


public class Repository<T> : RepositoryBase<T>, IRepository<T> where T : class, IAggregateRoot
{
    public Repository(OrdersDbContext dbContext) : base(dbContext)
    {
    }
}
