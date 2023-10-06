using Microsoft.AspNetCore.Mvc;
using Models;
using RESTful_API.DAL;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RESTful_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddressController : ControllerBase
    {
        private readonly AddressDB addressDA;

        public AddressController(AddressDB addressDA)
        {
            this.addressDA = addressDA;
        }

        // GET: api/<AddressController>
        [HttpGet]
        public IActionResult Get()
        {
            var addresses = addressDA.GetAll();
            if (addresses.Count == 0)
            {
                return NotFound("No addresses found");
            }

            return Ok(addresses);
        }

        // GET api/<AddressController>/5
        [HttpGet("{id:int}")]
        public IActionResult Get(int id)
        {
            var address = addressDA.Get(id);
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
            var createdAddress = addressDA.Create(address);

            return Ok(createdAddress);
        }

        // PUT api/<AddressController>/5
        [HttpPut]
        public IActionResult Update([FromBody] Address address)
        {
            var updatedAddress = addressDA.Update(address);
            if (!updatedAddress)
            {
                return BadRequest("Address update failed");
            }

            return Ok(updatedAddress);
        }

        // DELETE api/<AddressController>/5
        [HttpDelete("{id:long}")]
        public IActionResult Delete(long id)
        {
            var address = addressDA.Get(id);
            if (address == null)
            {
                return NotFound($"Address with id {id} was not found");
            }

            var deletedAddress = addressDA.Delete(address);
            if (!deletedAddress)
            {
                return BadRequest("Address deletion failed");
            }

            return Ok(deletedAddress);
        }
    }
}