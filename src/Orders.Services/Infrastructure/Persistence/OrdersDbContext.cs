using Microsoft.EntityFrameworkCore;
using Orders.Domain;
using Orders.Infrastructure.Persistance.Configuration;

namespace Orders.Infrastructure.Persistance;

public class OrdersDbContext : DbContext
{
    public DbSet<Order> Orders { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {

        modelBuilder.HasDefaultSchema("Orders");
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(OrdersDbContext).Assembly);

        base.OnModelCreating(modelBuilder);
    }
}
