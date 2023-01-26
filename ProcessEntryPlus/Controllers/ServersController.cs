using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProcessEntryPlus.Models;
using ProcessEntryPlus.Services;

namespace ProcessEntryPlus.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServersController : ControllerBase
    {
        private readonly ServersService _serversServ;

        public ServersController(ServersService serversServ)
        {
            _serversServ = serversServ;
        }

        [HttpGet]
        public ActionResult<List<Server>> Get()
        {
            try
            {
                List<Server> servers = _serversServ.GetAll();
                return Ok(servers);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("{id}")]
        public ActionResult<Server> Get(int id)
        {
            try
            {
                Server server = _serversServ.Get(id);
                return Ok(server);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost]
        public ActionResult<Server> Create([FromBody] Server serverData)
        {
            try
            {
                Server newServer = _serversServ.Create(serverData);
                return Ok(newServer);
            }
            catch (Exception e) 
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut("{id}")]
        public ActionResult<Server> Edit(int id, [FromBody] Server serverData)
        {
            try
            {
                serverData.Id= id;
                Server update = _serversServ.Edit(serverData);
                return Ok(update);
            }
            catch(Exception e) 
            {
                return BadRequest(e.Message);
            }
        }

        [HttpDelete("{id}")]
        public ActionResult<Server> Delete(int id) 
        {
            try
            {
                Server deletedServer = _serversServ.Delete(id);
                return Ok(deletedServer);
            }
            catch(Exception e) 
            {
                return BadRequest(e.Message);
            }
        }
    }
}
