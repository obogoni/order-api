using CSharpFunctionalExtensions;
using Orders.Contracts.CreateOrder;
using Orders.Domain;

namespace Orders.Services;

public class CreateOrderService() : ICreateOrderService
{
    public Task<Result<Order>> CreateOrder(CreateOrderRequest request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
