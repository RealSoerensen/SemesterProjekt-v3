using Microsoft.AspNetCore.Mvc;
using Models;
using RESTful_API.Services;

namespace RESTful_API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AddressController : ControllerBase
{
    private readonly AddressService addressService = new();

    // GET: api/<AddressController>
    [HttpGet]
    public async Task<IActionResult> Get()
    {
        List<Address> addresses;
        try
        {
            addresses = await addressService.GetAllAddresses();
        }
        catch (Exception)
        {
            return StatusCode(500, "An error occurred while fetching the addresses.");
        }

        return Ok(addresses);
    }

    // GET api/<AddressController>/5
    [HttpGet("{id:int}")]
    public async Task<IActionResult> Get(int id)
    {
        Address? address;
        try
        {
            address = await addressService.GetAddress(id);
        }
        catch (Exception)
        {
            return StatusCode(500, "An error occurred while fetching the address.");
        }

        return Ok(address);
    }

    // POST api/<AddressController>
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] Address address)
    {
        Address? createdAddress;
        try
        {
            createdAddress = await addressService.CreateAddress(address);
        }
        catch (Exception)
        {
            return BadRequest("Address creation failed - DB ERROR");
        }

        return createdAddress.ID == null ? BadRequest("Address creation failed - Unable to create in DB") : Ok(createdAddress);
    }

    // PUT api/<AddressController>/5
    [HttpPut]
    public async Task<IActionResult> Update([FromBody] Address address)
    {
        bool updatedAddress;
        try
        {
            updatedAddress = await addressService.UpdateAddress(address);
        }
        catch (Exception)
        {
            return BadRequest("Address update failed - DB ERROR");
        }

        return !updatedAddress ? BadRequest("Address update failed - Unable to update in DB") : Ok();
    }

    // DELETE api/<AddressController>/5
    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete(int id)
    {
        bool deletedAddress;
        try
        {
            deletedAddress = await addressService.DeleteAddress(id);
        }
        catch (Exception)
        {
            return BadRequest("Address deletion failed - DB ERROR");
        }

        return !deletedAddress ? BadRequest("Address deletion failed") : Ok();
    }
}