namespace Orders.Domain;

public enum OrderStatus : byte
{
    Open = 0,
    Canceled = 1,
    Closed = 2
}
