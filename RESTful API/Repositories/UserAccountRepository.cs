using Dapper;
using Microsoft.AspNetCore.Mvc;
using Models;
using System.Data;
using System.Data.SqlClient;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RESTful_API.Repositories;

[Route("api/[controller]")]
[ApiController]
public class UserAccountRepository
{
    private readonly string _connectionString;

    public UserAccountRepository(string connectionString)
    {
        _connectionString = connectionString;
    }

    // GET: api/<UserAccountRepository>
    [HttpGet]
    internal Task<UserAccount?> GetUserAccountByEmail(string email)
    {
        using IDbConnection dbConnection = new SqlConnection(_connectionString);

        var query = "SELECT * FROM UserAccount WHERE Email = @Email";
        var userAccount = dbConnection.QueryFirstOrDefaultAsync<UserAccount>(query, new { Email = email });
        return userAccount;
    }

    public async Task CreateUserAccount(UserAccount userAccount)
    {
        using IDbConnection dbConnection = new SqlConnection(_connectionString);
        dbConnection.Open();
        using var transaction = dbConnection.BeginTransaction();

        try
        {
            const string insertQuery = @"INSERT INTO [UserAccount] (Email, Password, CustomerID) VALUES (@Email, @Password, @CustomerID)";

            await dbConnection.ExecuteAsync(insertQuery, userAccount, transaction);
            transaction.Commit();
        }
        catch (Exception)
        {
            transaction.Rollback();
            throw;
        }
    }
}