using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProcessEntryPlus.Models;
using ProcessEntryPlus.Services;

namespace ProcessEntryPlus.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MethodsController : ControllerBase
    {
        private readonly MethodsService _methodsServ;

        public MethodsController(MethodsService methodsServ)
        {
            _methodsServ = methodsServ;
        }

        [HttpGet]
        public ActionResult<List<Method>> Get()
        {
            try
            {
                List<Method> methods = _methodsServ.GetAll();
                return Ok(methods);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("{id}")]
        public ActionResult<Method> Get(int id)
        {
            try
            {
                Method method = _methodsServ.Get(id);
                return Ok(method);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost]
        public ActionResult<Method> Create([FromBody] Method methodData)
        {
            try
            {
                Method newMethod = _methodsServ.Create(methodData);
                return Ok(newMethod);
            }
            catch (Exception e) 
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut("{id}")]
        public ActionResult<Method> Edit(int id, [FromBody] Method methodData)
        {
            try
            {
                methodData.Id= id;
                Method update = _methodsServ.Edit(methodData);
                return Ok(update);
            }
            catch(Exception e) 
            {
                return BadRequest(e.Message);
            }
        }

        [HttpDelete("{id}")]
        public ActionResult<Method> Delete(int id) 
        {
            try
            {
                Method deletedMethod = _methodsServ.Delete(id);
                return Ok(deletedMethod);
            }
            catch(Exception e) 
            {
                return BadRequest(e.Message);
            }
        }
    }
}
