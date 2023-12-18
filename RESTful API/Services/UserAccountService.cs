using Models;
using RESTful_API.Repositories;

namespace RESTful_API.Services;

public class UserAccountService
{
    private readonly UserAccountRepository _userAccountDB;

    public UserAccountService()
    {
        var connectionString = DBConnection.GetConnectionString();
        _userAccountDB = new UserAccountRepository(connectionString);
    }

    internal async Task CreateUserAccount(UserAccount userAccount)
    {
        try
        {
            await _userAccountDB.CreateUserAccount(userAccount);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    internal async Task<UserAccount?> GetUserAccountByEmail(string email)
    {
        try
        {
            var account = await _userAccountDB.GetUserAccountByEmail(email);
            return account;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public async Task<bool> UpdateUserAccount(UserAccount user)
    {
        try
        {
            return await _userAccountDB.Update(user);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}