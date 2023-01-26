using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProcessEntryPlus.Models;
using ProcessEntryPlus.Services;

namespace ProcessEntryPlus.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServiceAttemptsController : ControllerBase
    {
        private readonly ServiceAttemptsService _serviceAttemptsServ;

        public ServiceAttemptsController(ServiceAttemptsService serviceAttemptsServ)
        {
            _serviceAttemptsServ = serviceAttemptsServ;
        }

        [HttpGet]
        public ActionResult<List<ServiceAttempt>> Get()
        {
            try
            {
                List<ServiceAttempt> serviceAttempts = _serviceAttemptsServ.GetAll();
                return Ok(serviceAttempts);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("{id}")]
        public ActionResult<ServiceAttempt> Get(int id)
        {
            try
            {
                ServiceAttempt serviceAttempt = _serviceAttemptsServ.Get(id);
                return Ok(serviceAttempt);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost]
        public ActionResult<ServiceAttempt> Create([FromBody] ServiceAttempt serviceAttemptData)
        {
            try
            {
                ServiceAttempt newServiceAttempt = _serviceAttemptsServ.Create(serviceAttemptData);
                return Ok(newServiceAttempt);
            }
            catch (Exception e) 
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut("{id}")]
        public ActionResult<ServiceAttempt> Edit(int id, [FromBody] ServiceAttempt serviceAttemptData)
        {
            try
            {
                serviceAttemptData.Id= id;
                ServiceAttempt update = _serviceAttemptsServ.Edit(serviceAttemptData);
                return Ok(update);
            }
            catch(Exception e) 
            {
                return BadRequest(e.Message);
            }
        }

        [HttpDelete("{id}")]
        public ActionResult<ServiceAttempt> Delete(int id) 
        {
            try
            {
                ServiceAttempt deletedServiceAttempt = _serviceAttemptsServ.Delete(id);
                return Ok(deletedServiceAttempt);
            }
            catch(Exception e) 
            {
                return BadRequest(e.Message);
            }
        }
    }
}
