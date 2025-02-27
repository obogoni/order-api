using Ardalis.GuardClauses;
using Orders.Contracts.CreateOrder;
using Orders.Domain;
using Orders.Shared;

namespace Orders.Services;

public class CreateOrderService(IDateTimeService dateTimeService, IRepository<Order> repository) : ICreateOrderService
{
    public async Task<Order> CreateOrder(CreateOrderRequest request, CancellationToken cancellationToken)
    {
        Guard.Against.Null(request);

        var order = Order.Create(dateTimeService.Now);

        await repository.AddAsync(order);

        return order;
    }
}
