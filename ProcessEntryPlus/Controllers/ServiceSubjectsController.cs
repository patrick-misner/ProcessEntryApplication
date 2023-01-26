using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProcessEntryPlus.Models;
using ProcessEntryPlus.Services;

namespace ProcessEntryPlus.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServiceSubjectsController : ControllerBase
    {
        private readonly ServiceSubjectsService _serviceSubjectsServ;

        public ServiceSubjectsController(ServiceSubjectsService serviceSubjectsServ)
        {
            _serviceSubjectsServ = serviceSubjectsServ;
        }

        [HttpGet]
        public ActionResult<List<ServiceSubject>> Get()
        {
            try
            {
                List<ServiceSubject> serviceSubjects = _serviceSubjectsServ.GetAll();
                return Ok(serviceSubjects);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("{id}")]
        public ActionResult<ServiceSubject> Get(int id)
        {
            try
            {
                ServiceSubject serviceSubject = _serviceSubjectsServ.Get(id);
                return Ok(serviceSubject);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost]
        public ActionResult<ServiceSubject> Create([FromBody] ServiceSubject serviceSubjectData)
        {
            try
            {
                ServiceSubject newServiceSubject = _serviceSubjectsServ.Create(serviceSubjectData);
                return Ok(newServiceSubject);
            }
            catch (Exception e) 
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut("{id}")]
        public ActionResult<ServiceSubject> Edit(int id, [FromBody] ServiceSubject serviceSubjectData)
        {
            try
            {
                serviceSubjectData.Id= id;
                ServiceSubject update = _serviceSubjectsServ.Edit(serviceSubjectData);
                return Ok(update);
            }
            catch(Exception e) 
            {
                return BadRequest(e.Message);
            }
        }

        [HttpDelete("{id}")]
        public ActionResult<ServiceSubject> Delete(int id) 
        {
            try
            {
                ServiceSubject deletedServiceSubject = _serviceSubjectsServ.Delete(id);
                return Ok(deletedServiceSubject);
            }
            catch(Exception e) 
            {
                return BadRequest(e.Message);
            }
        }
    }
}
