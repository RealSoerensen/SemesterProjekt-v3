using Client.DAL;
using Models;

namespace Client.Controllers
{
    internal class UserAccountController
    {
        private readonly UserAccountDA _userAccountDA = new();

        public Task<UserAccount?> Get(long customerId)
        {
            return _userAccountDA.Get(customerId);
        }

        public async Task<bool> Update(UserAccount userAccount)
        {
            return await _userAccountDA.Update(userAccount);
        }

    }
}
