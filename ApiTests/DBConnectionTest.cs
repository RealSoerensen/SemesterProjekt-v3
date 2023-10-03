using RESTful_API.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiTests
{
    [TestClass]
    public class DBConnectionTest
    {
        [TestMethod]
        public void GetConnection_ReturnsConnection()
        {
            // Arrange
            DBConnection dbConnection = DBConnection.Instance();

            // Act
            var result = dbConnection.GetConnection();

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void GetConnection_ReturnsSameConnection()
        {
            // Arrange
            DBConnection dbConnection = DBConnection.Instance();

            // Act
            var result = dbConnection.GetConnection();

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(dbConnection.GetConnection(), result);
        }

        [TestMethod]
        public void Dispose_ReturnsNull()
        {
            // Arrange
            DBConnection dbConnection = DBConnection.Instance();

            // Act
            dbConnection.Dispose();

            // Assert
            Assert.IsNull(dbConnection.GetConnection());
        }
    }
}
