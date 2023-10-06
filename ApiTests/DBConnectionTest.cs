using System.Data;
using Microsoft.Data.SqlClient;
using RESTful_API.DAL;

namespace ApiTests;

[TestClass]
public class DBConnectionTest
{
    [TestMethod]
    public void GetConnection_ReturnsConnection()
    {
        // Arrange
        var DBConnection = new DBConnection();
        var connectionString = DBConnection.ConnectionString;

        // Act
        using var connection = new SqlConnection(connectionString);
        connection.Open();

        // Assert
        Assert.IsNotNull(connection);
        Assert.AreEqual(ConnectionState.Open, connection.State);
        connection.Close();
    }
}