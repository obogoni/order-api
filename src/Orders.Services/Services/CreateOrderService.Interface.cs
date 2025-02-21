using CSharpFunctionalExtensions;
using Orders.Domain;
using Orders.Contracts.CreateOrder;

namespace Orders.Services;

public interface ICreateOrderService
{
    Task<Result<Order>> CreateOrder(CreateOrderRequest request, CancellationToken cancellationToken);
}
