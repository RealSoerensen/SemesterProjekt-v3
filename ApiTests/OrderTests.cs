using API.Controllers;
using API.DAL.OrderDA;
using API.Models;

namespace ApiTests
{
    [TestClass]
    public class OrderTests
    {
        private readonly OrderController _orderController = new(OrderContainer.Instance);

        [TestInitialize]
        public void TestInitialize()
        {
            OrderContainer.Instance.GetAll().Clear();
        }

        [TestMethod]
        public void TestCreateOrder()
        {
            // Arrange
            var order = new Order(1, 1);

            // Act
            var result = _orderController.Create(order);

            // Assert
            Assert.IsNotNull(result); // Check if the result is not null
        }

        [TestMethod]
        public void TestGetOrder()
        {
            // Arrange
            var order = new Order(1, 1);
            _orderController.Create(order);

            // Act
            order = _orderController.Get(1);

            // Assert
            Assert.IsNotNull(order); // Check if the order is not null
            Assert.AreEqual(1, order.Id);
            Assert.AreEqual(1, order.CustomerId);
        }

        [TestMethod]
        public void TestGetAllOrders()
        {
            // Arrange
            var order1 = new Order(1, 1);
            _orderController.Create(order1);
            var order2 = new Order(2, 2);
            _orderController.Create(order2);

            // Act
            var orders = _orderController.GetAll();

            // Assert
            Assert.IsNotNull(orders); // Check if the orders is not null
            Assert.IsTrue(orders.Count >= 2);
        }

        [TestMethod]
        public void TestUpdateOrder()
        {
            // Arrange
            var order = new Order(1, 1);
            _orderController.Create(order);

            // Act
            order = _orderController.Get(1);
            Assert.IsNotNull(order);
            order.CustomerId = 2;
            var result = _orderController.Update(order);

            // Assert
            Assert.IsNotNull(order); // Check if the order is not null
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void TestDeleteOrder()
        {
            // Arrange
            var order = new Order(1, 1);
            _orderController.Create(order);

            // Act
            var result = _orderController.Delete(order);

            // Assert
            Assert.IsTrue(result);
        }
    }
}