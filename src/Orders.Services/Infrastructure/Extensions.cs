using Microsoft.EntityFrameworkCore;
using Orders.Infrastructure.Persistance;
using Orders.Shared;

namespace Orders.Infrastructure;

public static class Extensions
{
    public static void AddInfrastructureServices(this WebApplicationBuilder builder)
    {
        var connectionString = builder.Configuration.GetConnectionString("DefaultConnection")!;

        builder.Services.AddSingleton<IDateTimeService, DateTimeService>();
        builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
        builder.Services.AddDbContext<OrdersDbContext>(options => options.UseMySQL(connectionString));
    }
}
