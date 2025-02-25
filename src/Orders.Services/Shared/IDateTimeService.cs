namespace Orders.Shared;

public interface IDateTimeService
{
    DateTime Now { get; }

    DateTime Today { get; }
}
