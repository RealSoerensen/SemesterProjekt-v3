using Models;
using RESTful_API.Repositories;

namespace RESTful_API.Services
{
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
                return await _userAccountDB.GetUserAccountByEmail(email);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}
