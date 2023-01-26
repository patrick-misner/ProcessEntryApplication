using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProcessEntryPlus.Models;
using ProcessEntryPlus.Services;

namespace ProcessEntryPlus.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddressesController : ControllerBase
    {
        private readonly AddressesService _addrServ;

        public AddressesController(AddressesService addrServ)
        {
            _addrServ = addrServ;
        }

        [HttpGet]
        public ActionResult<List<Address>> Get()
        {
            try
            {
                List<Address> addresses = _addrServ.GetAll();
                return Ok(addresses);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("{id}")]
        public ActionResult<Address> Get(int id)
        {
            try
            {
                Address address = _addrServ.Get(id);
                return Ok(address);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost]
        public ActionResult<Address> Create([FromBody] Address addressData)
        {
            try
            {
                Address newAddress = _addrServ.Create(addressData);
                return Ok(newAddress);
            }
            catch (Exception e) 
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut("{id}")]
        public ActionResult<Address> Edit(int id, [FromBody] Address addressData)
        {
            try
            {
                addressData.Id= id;
                Address update = _addrServ.Edit(addressData);
                return Ok(update);
            }
            catch(Exception e) 
            {
                return BadRequest(e.Message);
            }
        }

        [HttpDelete("{id}")]
        public ActionResult<Address> Delete(int id) 
        {
            try
            {
                Address deletedAddress = _addrServ.Delete(id);
                return Ok(deletedAddress);
            }
            catch(Exception e) 
            {
                return BadRequest(e.Message);
            }
        }
    }
}
