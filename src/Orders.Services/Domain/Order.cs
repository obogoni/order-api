using CSharpFunctionalExtensions;

namespace Orders.Domain;

public class Order : Entity<int>, IAggregateRoot
{
    private readonly List<OrderItem> _items = new List<OrderItem>();

    public static Order Create(DateTime createdAt)
    {
        return new Order()
        {
            Status = OrderStatus.Open,
            CreatedAt = createdAt
        };
    }

    public IReadOnlyList<OrderItem> Items => _items.AsReadOnly();

    public Result AddItem(OrderItem item)
    {
        if (item == null)
        {
            return Result.Failure("Item cannot be null.");
        }

        _items.Add(item);
        return Result.Success();
    }

    public Result RemoveItem(OrderItem item)
    {
        if (item == null || !_items.Contains(item))
        {
            return Result.Failure("Item not found.");
        }

        _items.Remove(item);
        return Result.Success();
    }

    public Result Cancel(DateTime canceledAt)
    {
        if (canceledAt < CreatedAt)
        {
            return Result.Failure(Errors.CancelDateBeforeCreationDate);
        }

        Status = OrderStatus.Canceled;
        CanceledAt = canceledAt;

        return Result.Success();
    }

    public OrderStatus Status { get; private set; }

    public DateTime CreatedAt { get; private set; }

    public DateTime? CanceledAt { get; private set; }

    public class Errors
    {
        public static string CancelDateBeforeCreationDate = "Cancel date can't be before creation date.";

    }
}
