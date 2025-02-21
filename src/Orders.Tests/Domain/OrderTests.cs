using Orders.Domain;

namespace Orders.Tests.Domain;

[TestClass]
public class OrderTests
{
    public void Order_is_created_successfully()
    {
        //Act
        var order = Order.Create(DateTime.Now);

        //Assert
        Assert.IsTrue(order.Status == OrderStatus.Open);
    }

    public void Order_cant_be_canceled_with_invalid_date()
    {
        //Arrange
        var order = Order.Create(DateTime.Now);

        //Act
        var result = order.Cancel(DateTime.Now.AddDays(-1));

        //Assert
        Assert.IsTrue(result.IsFailure);
    }
}
