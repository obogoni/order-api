namespace Orders.Services;

public static class Extensions
{
    public static void AddServices(this IServiceCollection services)
    {
        services.AddScoped<ICreateOrderService, CreateOrderService>();
    }

    public static void UseOrders(this WebApplication app)
    {
        app.UseCreateOrder();
    }
}
