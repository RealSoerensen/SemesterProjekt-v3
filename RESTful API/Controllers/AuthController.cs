using Microsoft.AspNetCore.Mvc;
using Models;
using Newtonsoft.Json.Linq;
using RESTful_API.Services;

namespace RESTful_API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AuthController : ControllerBase
{
    private readonly CustomerService customerService = new();
    private readonly AddressService addressService = new();
    private readonly UserAccountService userAccountService = new();

    [HttpGet("login")]
    public async Task<IActionResult> Login(string email, string password)
    {
        try
        {
            // Validate the email and password inputs here.
            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
            {
                return BadRequest("Email and password are required");
            }

            // Check if the customer exists.
            var user = await userAccountService.GetUserAccountByEmail(email);

            if (user == null)
            {
                return NotFound($"Customer with email {email} was not found");
            }

            // Verify the password securely (e.g., using a password hashing library).
            if (!VerifyPassword(password, user.Password))
            {
                return Unauthorized("Incorrect password");
            }

            return Ok(user);
        }
        catch (Exception)
        {
            return StatusCode(500, "An error occurred while processing the request.");
        }
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] JObject? data)
    {
        if (data == null)
        {
            return BadRequest("Invalid input");
        }

        var customerData = data["customer"];
        var userAccountData = data["userAccount"];
        var addressData = data["address"];

        if (customerData == null || userAccountData == null || addressData == null)
        {
            return BadRequest("Invalid input");
        }

        try
        {
            var customer = customerData.ToObject<Customer>();
            var userAccount = userAccountData.ToObject<UserAccount>();
            var address = addressData.ToObject<Address>();

            if (customer == null || userAccount == null || address == null)
            {
                return BadRequest("Failed to convert to object");
            }

            userAccount.Password = HashPassword(userAccount.Password);

            address = await addressService.CreateAddress(address);
            customer.AddressID = address.ID;
            await customerService.CreateCustomer(customer);
            await userAccountService.CreateUserAccount(userAccount);
            return Ok();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.StackTrace);
            return BadRequest("An error occurred during registration");
        }
    }

    [HttpGet("{email}")]
    public async Task<bool> IsEmailValid(string email)
    {
        try
        {
            var user = await userAccountService.GetUserAccountByEmail(email);
            return user == null;
        }
        catch (Exception)
        {
            return false;
        }
    }

    private static bool VerifyPassword(string enteredPassword, string storedHash)
    {
        return BCrypt.Net.BCrypt.Verify(enteredPassword, storedHash);
    }

    private static string HashPassword(string password)
    {
        return BCrypt.Net.BCrypt.HashPassword(password);
    }
}