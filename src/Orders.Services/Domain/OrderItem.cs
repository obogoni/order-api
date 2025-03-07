using CSharpFunctionalExtensions;

namespace Orders.Domain;

public class OrderItem : Entity<int>, IAggregateRoot
{
    public int ProductId { get; private set; }
    public int Quantity { get; private set; }
    public decimal Price { get; private set; }

    private OrderItem() { }

    public static Result<OrderItem> Create(int productId, int quantity, decimal price)
    {
        if (productId < 0)
        {
            return Result.Failure<OrderItem>(Errors.ProductIdLessThanZero);
        }

        if (quantity < 0)
        {
            return Result.Failure<OrderItem>(Errors.QuantityLessThanZero);
        }

        if (price < 0)
        {
            return Result.Failure<OrderItem>(Errors.PriceLessThanZero);
        }

        if (price < 0)
        {
            return Result.Failure<OrderItem>(Errors.PriceLessThanZero);
        }

        return Result.Success(new OrderItem
        {
            ProductId = productId,
            Quantity = quantity,
            Price = price
        });
    }

    public decimal GetTotalPrice()
    {
        return Quantity * Price;
    }

    public static class Errors
    {
        public const string QuantityLessThanZero = "Quantity cannot be less than zero.";
        public const string PriceLessThanZero = "Price cannot be less than zero.";
        public const string ProductIdLessThanZero = "Product ID cannot be less than zero";
    }

}

