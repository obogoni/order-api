using Ardalis.GuardClauses;
using CSharpFunctionalExtensions;
using Orders.Contracts.CreateOrder;
using Orders.Domain;
using Orders.Shared;

namespace Orders.Services;

public class CreateOrderService(IDateTimeService dateTimeService, IRepository<Order> repository) : ICreateOrderService
{
    public async Task<Result<Order>> CreateOrder(CreateOrderRequest request, CancellationToken cancellationToken)
    {
        Guard.Against.Null(request);

        var order = Order.Create(dateTimeService.Now);

        await repository.AddAsync(order);

        await repository.SaveChangesAsync();

        return Result.Success(order);
    }
}
