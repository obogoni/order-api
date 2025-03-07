using Orders.Domain;
using CSharpFunctionalExtensions;

namespace Orders.Tests.Domain
{
    [TestClass]
    public class OrderItemTests
    {
        [TestMethod]
        public void Order_item_is_created_sucessfully()
        {
            // Arrange
            int productId = 1;
            int quantity = 5;
            decimal price = 10.0m;

            // Act
            Result<OrderItem> result = OrderItem.Create(productId, quantity, price);

            // Assert
            Assert.IsTrue(result.IsSuccess);
            Assert.AreEqual(productId, result.Value.ProductId);
            Assert.AreEqual(quantity, result.Value.Quantity);
            Assert.AreEqual(price, result.Value.Price);
        }

        [TestMethod]
        public void Order_item_creation_fails_when_quantity_is_less_than_zero()
        {
            // Arrange
            int productId = 1;
            int quantity = -1;
            decimal price = 10.0m;

            // Act
            Result<OrderItem> result = OrderItem.Create(productId, quantity, price);

            // Assert
            Assert.IsTrue(result.IsFailure);
            Assert.AreEqual(OrderItem.Errors.QuantityLessThanZero, result.Error);
        }

        [TestMethod]
        public void Order_item_creation_fails_when_price_is_less_than_zero()
        {
            // Arrange
            int productId = 1;
            int quantity = 5;
            decimal price = -10.0m;

            // Act
            Result<OrderItem> result = OrderItem.Create(productId, quantity, price);

            // Assert
            Assert.IsTrue(result.IsFailure);
            Assert.AreEqual(OrderItem.Errors.PriceLessThanZero, result.Error);
        }

        [TestMethod]
        public void Order_item_creation_fails_when_product_id_is_less_than_zero()
        {
            // Arrange
            int productId = -1;
            int quantity = 5;
            decimal price = 10.0m;

            // Act
            Result<OrderItem> result = OrderItem.Create(productId, quantity, price);

            // Assert
            Assert.IsTrue(result.IsFailure);
            Assert.AreEqual(OrderItem.Errors.ProductIdLessThanZero, result.Error);
        }

        [TestMethod]
        public void Order_item_total_price_is_calculated_correctly()
        {
            // Arrange
            int productId = 1;
            int quantity = 5;
            decimal price = 10.0m;
            OrderItem orderItem = OrderItem.Create(productId, quantity, price).Value;

            // Act
            decimal totalPrice = orderItem.GetTotalPrice();

            // Assert
            Assert.AreEqual(50.0m, totalPrice);
        }
    }
}

