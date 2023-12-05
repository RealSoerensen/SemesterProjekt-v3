﻿using Microsoft.AspNetCore.Mvc;
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

    [Route("login")]
    [HttpGet]
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
            var customer = await customerService.GetCustomerByEmail(email);

            if (customer == null)
            {
                return NotFound($"Customer with email {email} was not found");
            }

            // Verify the password securely (e.g., using a password hashing library).
            if (!VerifyPassword(password, customer.Password))
            {
                return Unauthorized("Incorrect password");
            }

            return Ok(customer);
        }
        catch (Exception)
        {
            return StatusCode(500, "An error occurred while processing the request.");
        }
    }

    [Route("register")]
    [HttpPost]
    public async Task<IActionResult> Register([FromBody] JObject? data)
    {
        if (data == null)
        {
            return BadRequest("Invalid input");
        }

        var customerData = data["customer"];
        var addressData = data["address"];

        if (customerData == null || addressData == null)
        {
            return BadRequest("Invalid input");
        }

        try
        {
            var customer = customerData.ToObject<Customer>();
            var address = addressData.ToObject<Address>();

            if (customer == null || address == null)
            {
                return BadRequest("Failed to convert to object");
            }

            customer.Password = HashPassword(customer.Password);

            address = await addressService.CreateAddress(address);
            customer.AddressID = address.ID;
            await customerService.CreateCustomer(customer);
            return Ok();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.StackTrace);
            return BadRequest("An error occurred during registration");
        }
    }

    private bool VerifyPassword(string enteredPassword, string storedHash)
    {
        return BCrypt.Net.BCrypt.Verify(enteredPassword, storedHash);
    }

    private string HashPassword(string password)
    {
        return BCrypt.Net.BCrypt.HashPassword(password);
    }
}