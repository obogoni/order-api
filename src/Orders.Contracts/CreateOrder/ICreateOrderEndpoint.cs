using Refit;

namespace Orders.Contracts.CreateOrder;

public interface ICreateOrderEndpoint
{
    [Post(Constants.OrdersRoute)]
    public Task<CreateOrderResponse> CreateOrder(CancellationToken cancellationToken);
}
