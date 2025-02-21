using Microsoft.AspNetCore.Mvc;
using Orders.Contracts;
using Orders.Contracts.CreateOrder;

namespace Orders.Services;

public static class CreateOrderEndpoint
{
    public static void UseCreateOrder(this WebApplication app)
    {
        app.MapPost(Constants.OrdersRoute, CreateOrder);
    }

    public static Task<CreateOrderResponse> CreateOrder(ICreateOrderService createOrderService, [FromBody] CreateOrderRequest request)
    {
        return null;
    }
}
