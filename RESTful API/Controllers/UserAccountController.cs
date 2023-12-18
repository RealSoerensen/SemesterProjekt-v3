using Microsoft.AspNetCore.Mvc;
using Models;
using RESTful_API.Services;

namespace RESTful_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserAccountController : ControllerBase
    {
        private readonly UserAccountService _userAccountService = new();

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] long customerId)
        {
            try
            {
                var userAccounts = await _userAccountService.GetAllUserAccounts();
                if (customerId == 0)
                {
                    return Ok(userAccounts);
                }

                var userAccount = userAccounts.Find(u => u.CustomerID == customerId);
                if (userAccount == null)
                {
                    return NotFound($"User account with customer ID {customerId} was not found");
                }
                return Ok(userAccount);
            }
            catch (Exception)
            {
                return StatusCode(500, "An error occurred while getting the user account.");
            }
        }

        [HttpPut]
        public async Task<IActionResult> UpdateUserAccount([FromBody] UserAccount userAccount)
        {
            try
            {
                await Console.Out.WriteLineAsync(userAccount.Email + " " + userAccount.CustomerID);
                await _userAccountService.UpdateUserAccount(userAccount);
                return Ok();
            }
            catch (Exception)
            {
                return StatusCode(500, "An error occurred while updating the user account.");
            }
        }
    }
}
