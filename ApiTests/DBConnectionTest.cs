using System.Data;
using Microsoft.Data.SqlClient;
using RESTful_API.Repositories;

namespace ApiTests;

[TestClass]
public class DBConnectionTest
{
    [TestMethod]
    public void GetConnection_ReturnsConnection()
    {
        // Arrange
        var connectionString = DBConnection.GetConnectionString();

        // Act
        using var connection = new SqlConnection(connectionString);
        connection.Open();

        // Assert
        Assert.IsNotNull(connection);
        Assert.AreEqual(ConnectionState.Open, connection.State);
        connection.Close();
    }
}