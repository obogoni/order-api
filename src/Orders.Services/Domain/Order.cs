using CSharpFunctionalExtensions;

namespace Orders.Domain;

public class Order : Entity<Guid>
{
    public static Order Create(DateTime createdAt)
    {
        return new Order()
        {
            Id = Guid.NewGuid(),
            Status = OrderStatus.Open,
            CreatedAt = createdAt
        };
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
