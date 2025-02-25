using Orders.Shared;

namespace Orders.Infrastructure;

public class DateTimeService : IDateTimeService
{
    public DateTime Now => DateTime.UtcNow;

    public DateTime Today => DateTime.UtcNow.Date;
}
