using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ProcessEntryPlus.Services;
using ProcessEntryPlus.Models;


namespace ProcessEntryPlus.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProcessEntriesController : ControllerBase
    {

        private readonly ProcessEntriesService _processEntriesService;
        

        public ProcessEntriesController(ProcessEntriesService processEntriesService)
        {
            _processEntriesService = processEntriesService;
        }



        [HttpGet]
        public ActionResult<List<ProcessEntry>> GetAll()
        {
           try
            {
                List<ProcessEntry> processEntries = _processEntriesService.GetAll();
                return Ok(processEntries);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("{id}")]
        public ActionResult<ProcessEntry> Get(int id)
        {
            try
            {
                ProcessEntry processEntry = _processEntriesService.Get(id);
                return Ok(processEntry);
            }
            catch (Exception e) 
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost]
        public ActionResult<ProcessEntry> Create([FromBody] ProcessEntry processEntryData)
        {
            try
            {
                ProcessEntry newProcessEntry = _processEntriesService.Create(processEntryData);
                return Ok(newProcessEntry);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [HttpPut("{id}")]
        public ActionResult<ProcessEntry> Edit(int id, [FromBody] ProcessEntry processEntryData)
        {
            try
            {
                processEntryData.Id = id;
                ProcessEntry update = _processEntriesService.Edit(processEntryData);
                return Ok(update);
            }
            catch (Exception e) 
            {
                return BadRequest(e.Message);
            }
        }

        [HttpDelete("{id}")]
        public ActionResult<ProcessEntry> Delete(int id)
        {
            try
            {
                ProcessEntry deletedProcessEntry = _processEntriesService.Delete(id);
                return Ok(deletedProcessEntry);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

    }
}
