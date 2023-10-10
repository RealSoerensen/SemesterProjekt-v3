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
            List<Address> addresses;
            try
            {
                addresses = addressDA.GetAll();
            }
            catch (Exception)
            {
                return BadRequest("Address retrieval failed - DB ERROR");
            }

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
            Address? address;
            try
            {
                address = addressDA.Get(id);
            }
            catch (Exception)
            {
                return BadRequest("Address retrieval failed - DB ERROR");
            }

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
            Address createdAddress;
            try
            {
                createdAddress = addressDA.Create(address);
            } 
            catch (Exception)
            {
                return BadRequest("Address creation failed");
            }

            return Ok(createdAddress);
        }

        // PUT api/<AddressController>/5
        [HttpPut]
        public IActionResult Update([FromBody] Address address)
        {
            bool updatedAddress;
            try
            {
                updatedAddress = addressDA.Update(address);
            } 
            catch (Exception)
            {
                return BadRequest("Address update failed - DB ERROR");
            }
            
            if (!updatedAddress)
            {
                return BadRequest("Address update failed - Unable to update in DB");
            }

            return Ok();
        }

        // DELETE api/<AddressController>/5
        [HttpDelete("{id:long}")]
        public IActionResult Delete(long id)
        {
            Address? address;
            try
            {
                address = addressDA.Get(id);
            }
            catch (Exception)
            {
                return BadRequest("Address deletion failed - DB ERROR");
            }

            if (address == null)
            {
                return NotFound($"Address with id {id} was not found");
            }

            var deletedAddress = addressDA.Delete(address);
            if (!deletedAddress)
            {
                return BadRequest("Address deletion failed");
            }

            return Ok();
        }
    }
}