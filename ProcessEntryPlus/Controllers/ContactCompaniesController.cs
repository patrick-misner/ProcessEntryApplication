using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProcessEntryPlus.Models;
using ProcessEntryPlus.Services;

namespace ProcessEntryPlus.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactCompaniesController : ControllerBase
    {
        private readonly ContactCompaniesService _contactCompaniesServ;

        public ContactCompaniesController(ContactCompaniesService contactCompaniesServ)
        {
            _contactCompaniesServ = contactCompaniesServ;
        }

        [HttpGet]
        public ActionResult<List<ContactCompany>> Get()
        {
            try
            {
                List<ContactCompany> contactCompanies = _contactCompaniesServ.GetAll();
                return Ok(contactCompanies);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("{id}")]
        public ActionResult<ContactCompany> Get(int id)
        {
            try
            {
                ContactCompany contactCompany = _contactCompaniesServ.Get(id);
                return Ok(contactCompany);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost]
        public ActionResult<ContactCompany> Create([FromBody] ContactCompany contactCompanyData)
        {
            try
            {
                ContactCompany newContactCompany = _contactCompaniesServ.Create(contactCompanyData);
                return Ok(newContactCompany);
            }
            catch (Exception e) 
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut("{id}")]
        public ActionResult<ContactCompany> Edit(int id, [FromBody] ContactCompany contactCompanyData)
        {
            try
            {
                contactCompanyData.Id= id;
                ContactCompany update = _contactCompaniesServ.Edit(contactCompanyData);
                return Ok(update);
            }
            catch(Exception e) 
            {
                return BadRequest(e.Message);
            }
        }

        [HttpDelete("{id}")]
        public ActionResult<ContactCompany> Delete(int id) 
        {
            try
            {
                ContactCompany deletedContactCompany = _contactCompaniesServ.Delete(id);
                return Ok(deletedContactCompany);
            }
            catch(Exception e) 
            {
                return BadRequest(e.Message);
            }
        }
    }
}
