using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProcessEntryPlus.Models;
using ProcessEntryPlus.Services;

namespace ProcessEntryPlus.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SsAddressesController : ControllerBase
    {
        private readonly SsAddressesService _ssAddressesServ;

        public SsAddressesController(SsAddressesService ssAddressesServ)
        {
            _ssAddressesServ = ssAddressesServ;
        }

        [HttpGet]
        public ActionResult<List<SsAddress>> Get()
        {
            try
            {
                List<SsAddress> ssAddresses = _ssAddressesServ.GetAll();
                return Ok(ssAddresses);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("{id}")]
        public ActionResult<SsAddress> Get(int id)
        {
            try
            {
                SsAddress ssAddress = _ssAddressesServ.Get(id);
                return Ok(ssAddress);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost]
        public ActionResult<SsAddress> Create([FromBody] SsAddress ssAddressData)
        {
            try
            {
                SsAddress newSsAddress = _ssAddressesServ.Create(ssAddressData);
                return Ok(newSsAddress);
            }
            catch (Exception e) 
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut("{id}")]
        public ActionResult<SsAddress> Edit(int id, [FromBody] SsAddress ssAddressData)
        {
            try
            {
                ssAddressData.Id= id;
                SsAddress update = _ssAddressesServ.Edit(ssAddressData);
                return Ok(update);
            }
            catch(Exception e) 
            {
                return BadRequest(e.Message);
            }
        }

        [HttpDelete("{id}")]
        public ActionResult<SsAddress> Delete(int id) 
        {
            try
            {
                SsAddress deletedSsAddress = _ssAddressesServ.Delete(id);
                return Ok(deletedSsAddress);
            }
            catch(Exception e) 
            {
                return BadRequest(e.Message);
            }
        }
    }
}
