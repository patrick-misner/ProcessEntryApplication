using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProcessEntryPlus.Models;
using ProcessEntryPlus.Services;

namespace ProcessEntryPlus.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CapacitiesController : ControllerBase
    {
        private readonly CapacitiesService _capacitiesServ;

        public CapacitiesController(CapacitiesService capacitiesServ)
        {
            _capacitiesServ = capacitiesServ;
        }

        [HttpGet]
        public ActionResult<List<Capacity>> Get()
        {
            try
            {
                List<Capacity> capacities = _capacitiesServ.GetAll();
                return Ok(capacities);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("{id}")]
        public ActionResult<Capacity> Get(int id)
        {
            try
            {
                Capacity capacity = _capacitiesServ.Get(id);
                return Ok(capacity);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost]
        public ActionResult<Capacity> Create([FromBody] Capacity capacityData)
        {
            try
            {
                Capacity newCapacity = _capacitiesServ.Create(capacityData);
                return Ok(newCapacity);
            }
            catch (Exception e) 
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut("{id}")]
        public ActionResult<Capacity> Edit(int id, [FromBody] Capacity capacityData)
        {
            try
            {
                capacityData.Id= id;
                Capacity update = _capacitiesServ.Edit(capacityData);
                return Ok(update);
            }
            catch(Exception e) 
            {
                return BadRequest(e.Message);
            }
        }

        [HttpDelete("{id}")]
        public ActionResult<Capacity> Delete(int id) 
        {
            try
            {
                Capacity deletedCapacity = _capacitiesServ.Delete(id);
                return Ok(deletedCapacity);
            }
            catch(Exception e) 
            {
                return BadRequest(e.Message);
            }
        }
    }
}
