using Dapper;
using Models;
using System.Data;
using System.Data.SqlClient;

namespace RESTful_API.Repositories;

public class UserAccountRepository
{
    private readonly string _connectionString;

    public UserAccountRepository(string connectionString)
    {
        _connectionString = connectionString;
    }

    public async Task<UserAccount?> GetUserAccountByEmail(string email)
    {
        using IDbConnection dbConnection = new SqlConnection(_connectionString);

        const string query = "SELECT * FROM UserAccount WHERE Email = @Email";

        var userAccount = await dbConnection.QueryFirstOrDefaultAsync<UserAccount>(query, new { Email = email });

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

    public async Task Update(UserAccount user)
    {
        using IDbConnection dbConnection = new SqlConnection(_connectionString);
        dbConnection.Open();
        using var transaction = dbConnection.BeginTransaction();

        try
        {
            const string updateQuery = @"UPDATE [UserAccount] SET Email = @Email WHERE customerID = @CustomerID";

            await dbConnection.ExecuteAsync(updateQuery, user, transaction);
            transaction.Commit();
        }
        catch (Exception)
        {
            transaction.Rollback();
            throw;
        }
    }

    public async Task<List<UserAccount>> GetAll()
    {
        using IDbConnection dbConnection = new SqlConnection(_connectionString);
        dbConnection.Open();
        const string sql = "SELECT * FROM UserAccount";
        var productList = await dbConnection.QueryAsync<UserAccount>(sql);
        return productList.ToList();
    }
}