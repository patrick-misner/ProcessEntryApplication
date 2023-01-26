using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProcessEntryPlus.Models;
using ProcessEntryPlus.Services;

namespace ProcessEntryPlus.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InstructionsController : ControllerBase
    {
        private readonly InstructionsService _instructionsServ;

        public InstructionsController(InstructionsService instructionsServ)
        {
            _instructionsServ = instructionsServ;
        }

        [HttpGet]
        public ActionResult<List<Instruction>> Get()
        {
            try
            {
                List<Instruction> instructions = _instructionsServ.GetAll();
                return Ok(instructions);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("{id}")]
        public ActionResult<Instruction> Get(int id)
        {
            try
            {
                Instruction instruction = _instructionsServ.Get(id);
                return Ok(instruction);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost]
        public ActionResult<Instruction> Create([FromBody] Instruction instructionData)
        {
            try
            {
                Instruction newInstruction = _instructionsServ.Create(instructionData);
                return Ok(newInstruction);
            }
            catch (Exception e) 
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut("{id}")]
        public ActionResult<Instruction> Edit(int id, [FromBody] Instruction instructionData)
        {
            try
            {
                instructionData.Id= id;
                Instruction update = _instructionsServ.Edit(instructionData);
                return Ok(update);
            }
            catch(Exception e) 
            {
                return BadRequest(e.Message);
            }
        }

        [HttpDelete("{id}")]
        public ActionResult<Instruction> Delete(int id) 
        {
            try
            {
                Instruction deletedInstruction = _instructionsServ.Delete(id);
                return Ok(deletedInstruction);
            }
            catch(Exception e) 
            {
                return BadRequest(e.Message);
            }
        }
    }
}
