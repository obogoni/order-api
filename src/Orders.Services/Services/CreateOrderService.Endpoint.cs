using Microsoft.AspNetCore.Mvc;
using Orders.Contracts;
using Orders.Contracts.CreateOrder;
using IResult = Microsoft.AspNetCore.Http.IResult;

namespace Orders.Services;

public static class CreateOrderEndpoint
{
    public static void UseCreateOrder(this WebApplication app)
    {
        app.MapPost(Constants.OrdersRoute, CreateOrder);
    }

    public static async Task<IResult> CreateOrder([FromBody] CreateOrderRequest request, ICreateOrderService createOrderService, CancellationToken cancellationToken)
    {
        var order = await createOrderService.CreateOrder(request, cancellationToken);

        var response = new CreateOrderResponse
        {
            Id = order.Id,
            CreatedAt = order.CreatedAt
        };

        return Results.Ok(order);
    }
}
