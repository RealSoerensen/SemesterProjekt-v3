using Microsoft.AspNetCore.Mvc;
using Models;
using RESTful_API.Repositories;
using RESTful_API.Repositories.AddressDA;
using RESTful_API.Services;

namespace RESTful_API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AddressController : ControllerBase
{
    private readonly AddressService addressService;

    public AddressController()
    {
        addressService = new AddressService();
    }

    // GET: api/<AddressController>
    [HttpGet]
    public IActionResult Get()
    {
        List<Address> addresses = addressService.GetAllAddresses();

        if (addresses == null)
        {
            return NotFound("No addresses found");
        }

        return Ok(addresses);
    }

    // GET api/<AddressController>/5
    [HttpGet("{id:int}")]
    public IActionResult Get(int id)
    {
        Address? address = addressService.GetAddress(id);

        if (address == null)
        {
            return NotFound($"Address with id {id} was not found");
        }

        return Ok(address);
    }

    // POST api/<AddressController>
    [HttpPost]
    public IActionResult Create([FromBody] Address address)
    {
        Address? createdAddress = addressService.CreateAddress(address);
        if (createdAddress == null)
        {
            return BadRequest("Address creation failed - Unable to create in DB");
        }

        return Ok(createdAddress);
    }

    // PUT api/<AddressController>/5
    [HttpPut]
    public IActionResult Update([FromBody] Address address)
    {
        bool updatedAddress = addressService.UpdateAddress(address);

        if (!updatedAddress)
        {
            return BadRequest("Address update failed - Unable to update in DB");
        }

        return Ok();
    }

    // DELETE api/<AddressController>/5
    [HttpDelete("id:int")]
    public IActionResult Delete(int id)
    {
        var deletedAddress = addressService.DeleteAddress(id);
        if (!deletedAddress)
        {
            return BadRequest("Address deletion failed");
        }

        return Ok();
    }
}