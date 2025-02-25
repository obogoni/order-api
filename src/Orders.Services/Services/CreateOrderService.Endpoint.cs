using CSharpFunctionalExtensions;
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

    public static async Task<CreateOrderResponse> CreateOrder([FromBody] CreateOrderRequest request, ICreateOrderService createOrderService, CancellationToken cancellationToken)
    {
        var result = await createOrderService.CreateOrder(request, cancellationToken);
       
        

        .Bind(() => { return Result.Success(); });
    }
}
