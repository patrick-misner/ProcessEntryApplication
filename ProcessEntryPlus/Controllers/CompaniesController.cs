using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProcessEntryPlus.Models;
using ProcessEntryPlus.Services;

namespace ProcessEntryPlus.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompaniesController : ControllerBase
    {
        private readonly CompaniesService _companiesServ;

        public CompaniesController(CompaniesService companiesServ)
        {
            _companiesServ = companiesServ;
        }

        [HttpGet]
        public ActionResult<List<Company>> Get()
        {
            try
            {
                List<Company> companies = _companiesServ.GetAll();
                return Ok(companies);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("{id}")]
        public ActionResult<Company> Get(int id)
        {
            try
            {
                Company company = _companiesServ.Get(id);
                return Ok(company);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost]
        public ActionResult<Company> Create([FromBody] Company companyData)
        {
            try
            {
                Company newCompany = _companiesServ.Create(companyData);
                return Ok(newCompany);
            }
            catch (Exception e) 
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut("{id}")]
        public ActionResult<Company> Edit(int id, [FromBody] Company companyData)
        {
            try
            {
                companyData.Id= id;
                Company update = _companiesServ.Edit(companyData);
                return Ok(update);
            }
            catch(Exception e) 
            {
                return BadRequest(e.Message);
            }
        }

        [HttpDelete("{id}")]
        public ActionResult<Company> Delete(int id) 
        {
            try
            {
                Company deletedCompany = _companiesServ.Delete(id);
                return Ok(deletedCompany);
            }
            catch(Exception e) 
            {
                return BadRequest(e.Message);
            }
        }
    }
}
