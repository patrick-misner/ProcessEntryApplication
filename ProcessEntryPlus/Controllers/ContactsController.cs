using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProcessEntryPlus.Models;
using ProcessEntryPlus.Services;

namespace ProcessEntryPlus.Controllers
{
  [Route("api/[controller]")]
    [ApiController]
    public class ContactsController : ControllerBase
    {
        private readonly ContactsService _contactsServ;

        public ContactsController(ContactsService contactsServ)
        {
            _contactsServ = contactsServ;
        }

        [HttpGet]
        [Authorize]
        public ActionResult<List<Contact>> Get()
        {
            try
            {
                List<Contact> contacts = _contactsServ.GetAll();
                return Ok(contacts);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("{id}")]
        public ActionResult<Contact> Get(int id)
        {
            try
            {
                Contact Contact = _contactsServ.Get(id);
                return Ok(Contact);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost]
        public ActionResult<Contact> Create([FromBody] Contact contactData)
        {
            try
            {
                Contact newContact = _contactsServ.Create(contactData);
                return Ok(newContact);
            }
            catch (Exception e) 
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut("{id}")]
        public ActionResult<Contact> Edit(int id, [FromBody] Contact contactData)
        {
            try
            {
                contactData.Id= id;
                Contact update = _contactsServ.Edit(contactData);
                return Ok(update);
            }
            catch(Exception e) 
            {
                return BadRequest(e.Message);
            }
        }

        [HttpDelete("{id}")]
        public ActionResult<Contact> Delete(int id) 
        {
            try
            {
                Contact deletedContact = _contactsServ.Delete(id);
                return Ok(deletedContact);
            }
            catch(Exception e) 
            {
                return BadRequest(e.Message);
            }
        }
    }
}
