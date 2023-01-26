using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProcessEntryPlus.Models;
using ProcessEntryPlus.Services;

namespace ProcessEntryPlus.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AffidavitTypesController : ControllerBase
    {
        private readonly AffidavitTypesService _affidavitTypesServ;

        public AffidavitTypesController(AffidavitTypesService affidavitTypesServ)
        {
            _affidavitTypesServ = affidavitTypesServ;
        }

        [HttpGet]
        public ActionResult<List<AffidavitType>> Get()
        {
            try
            {
                List<AffidavitType> affidavitTypes = _affidavitTypesServ.GetAll();
                return Ok(affidavitTypes);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("{id}")]
        public ActionResult<AffidavitType> Get(int id)
        {
            try
            {
                AffidavitType affidavitType = _affidavitTypesServ.Get(id);
                return Ok(affidavitType);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost]
        public ActionResult<AffidavitType> Create([FromBody] AffidavitType affidavitTypeData)
        {
            try
            {
                AffidavitType newAffidavitType = _affidavitTypesServ.Create(affidavitTypeData);
                return Ok(newAffidavitType);
            }
            catch (Exception e) 
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut("{id}")]
        public ActionResult<AffidavitType> Edit(int id, [FromBody] AffidavitType affidavitTypeData)
        {
            try
            {
                affidavitTypeData.Id= id;
                AffidavitType update = _affidavitTypesServ.Edit(affidavitTypeData);
                return Ok(update);
            }
            catch(Exception e) 
            {
                return BadRequest(e.Message);
            }
        }

        [HttpDelete("{id}")]
        public ActionResult<AffidavitType> Delete(int id) 
        {
            try
            {
                AffidavitType deletedAffidavitType = _affidavitTypesServ.Delete(id);
                return Ok(deletedAffidavitType);
            }
            catch(Exception e) 
            {
                return BadRequest(e.Message);
            }
        }
    }
}
