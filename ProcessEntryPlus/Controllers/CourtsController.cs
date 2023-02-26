using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ProcessEntryPlus.Models;
using ProcessEntryPlus.Services;
using Microsoft.AspNetCore.Mvc;



namespace ProcessEntryPlus.Controllers
{
  [ApiController]
  [Route("api/[controller]")]

  public class CourtsController : ControllerBase
  {
    private readonly CourtsService _cServ;

    public CourtsController(CourtsService cServ)
    {
      _cServ = cServ;
    }
    [HttpGet]
    public ActionResult<List<Court>> Get()
    {
      try
      {
        List<Court> courts = _cServ.GetAll();
        return Ok(courts);
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }
    [HttpGet("{id}")]
    public ActionResult<Court> Get(int id)
    {
      try
      {
        Court court = _cServ.Get(id);
        return Ok(court);
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }
    [HttpPost]
    public ActionResult<Court> Create([FromBody] Court courtData)
    {
      try
      {
        Court newCourt = _cServ.Create(courtData);
        return Ok(newCourt);
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }
    [HttpPut("{id}")]
    public ActionResult<Court> Edit(int id, [FromBody] Court courtData)
    {
      try
      {
        courtData.Id = id;
        Court update = _cServ.Edit(courtData);
        return Ok(update);
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }
    [HttpDelete("{id}")]
    public ActionResult<Court> Delete(int id)
    {
      try
      {
        Court deletedCourt = _cServ.Delete(id);
        return Ok(deletedCourt);
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }
  }
}