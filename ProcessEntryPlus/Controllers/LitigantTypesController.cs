using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProcessEntryPlus.Models;
using ProcessEntryPlus.Services;

namespace ProcessEntryPlus.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LitigantTypesController : ControllerBase
    {
        private readonly LitigantTypesService _litigantTypesServ;

        public LitigantTypesController(LitigantTypesService litigantTypesServ)
        {
            _litigantTypesServ = litigantTypesServ;
        }

        [HttpGet]
        public ActionResult<List<LitigantType>> Get()
        {
            try
            {
                List<LitigantType> litigantTypes = _litigantTypesServ.GetAll();
                return Ok(litigantTypes);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("{id}")]
        public ActionResult<LitigantType> Get(int id)
        {
            try
            {
                LitigantType litigantType = _litigantTypesServ.Get(id);
                return Ok(litigantType);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost]
        public ActionResult<LitigantType> Create([FromBody] LitigantType litigantTypeData)
        {
            try
            {
                LitigantType newLitigantType = _litigantTypesServ.Create(litigantTypeData);
                return Ok(newLitigantType);
            }
            catch (Exception e) 
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut("{id}")]
        public ActionResult<LitigantType> Edit(int id, [FromBody] LitigantType litigantTypeData)
        {
            try
            {
                litigantTypeData.Id= id;
                LitigantType update = _litigantTypesServ.Edit(litigantTypeData);
                return Ok(update);
            }
            catch(Exception e) 
            {
                return BadRequest(e.Message);
            }
        }

        [HttpDelete("{id}")]
        public ActionResult<LitigantType> Delete(int id) 
        {
            try
            {
                LitigantType deletedLitigantType = _litigantTypesServ.Delete(id);
                return Ok(deletedLitigantType);
            }
            catch(Exception e) 
            {
                return BadRequest(e.Message);
            }
        }
    }
}
