using Microsoft.EntityFrameworkCore;
using Orders.Domain;

namespace Orders.Infrastructure.Persistance;

public class OrdersDbContext : DbContext
{
    public DbSet<Order> Orders { get; set; }
}
