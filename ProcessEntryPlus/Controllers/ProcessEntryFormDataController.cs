using Microsoft.AspNetCore.Mvc;
using ProcessEntryPlus.Models;
using ProcessEntryPlus.Services;


namespace ProcessEntryPlus.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class ProcessEntryFormDataController : ControllerBase
  {
    private readonly ProcessEntryFormDataService _processEntryFormDataServ;

    public ProcessEntryFormDataController(ProcessEntryFormDataService processEntryFormDataServ)
    {
      _processEntryFormDataServ = processEntryFormDataServ;
    }
    [HttpGet]
    public ActionResult<List<ProcessEntryFormData>> Get()
    {
      try
      {
        List<ProcessEntryFormData> processEntryFormData = _processEntryFormDataServ.GetAll();
        return Ok(processEntryFormData);
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }


  }
}
