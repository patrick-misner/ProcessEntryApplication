using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProcessEntryPlus.Models;
using ProcessEntryPlus.Services;

namespace ProcessEntryPlus.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DocumentsController : ControllerBase
    {
        private readonly DocumentsService _documentsServ;

        public DocumentsController(DocumentsService documentsServ)
        {
            _documentsServ = documentsServ;
        }

        [HttpGet]
        public ActionResult<List<Document>> Get()
        {
            try
            {
                List<Document> documents = _documentsServ.GetAll();
                return Ok(documents);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("{id}")]
        public ActionResult<Document> Get(int id)
        {
            try
            {
                Document document = _documentsServ.Get(id);
                return Ok(document);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost]
        public ActionResult<Document> Create([FromBody] Document documentData)
        {
            try
            {
                Document newDocument = _documentsServ.Create(documentData);
                return Ok(newDocument);
            }
            catch (Exception e) 
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut("{id}")]
        public ActionResult<Document> Edit(int id, [FromBody] Document documentData)
        {
            try
            {
                documentData.Id= id;
                Document update = _documentsServ.Edit(documentData);
                return Ok(update);
            }
            catch(Exception e) 
            {
                return BadRequest(e.Message);
            }
        }

        [HttpDelete("{id}")]
        public ActionResult<Document> Delete(int id) 
        {
            try
            {
                Document deletedDocument = _documentsServ.Delete(id);
                return Ok(deletedDocument);
            }
            catch(Exception e) 
            {
                return BadRequest(e.Message);
            }
        }
    }
}
