using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Note.API;
using NoteAPI.Models;
using System.Net;
using System.Text;
using System.Text.Json;

namespace NoteAPI.Controllers
{
    [EnableCors]
    [Route("[controller]")]
    [ApiController]
    public class NoteController : ControllerBase
    {

        // readonly fields cannot be assigned after constructory is called
        private readonly ILogger<NoteController> logger;
        private readonly INoteRepository noteRepository;
        private readonly IHttpClientFactory httpClientFactory;

        public NoteController(ILogger<NoteController> _logger, INoteRepository _noteRepository, IHttpClientFactory _httpClientFactory)
        {
            logger = _logger;
            noteRepository = _noteRepository ?? throw new ArgumentNullException(nameof(noteRepository));
            httpClientFactory = _httpClientFactory ?? throw new ArgumentException(nameof(httpClientFactory));
        }

        [HttpGet]
        public void Index()
        {
            logger.LogInformation("here");
        }



        [HttpGet("all")]
        public async Task<ActionResult<List<NoteItem>>> GetAllNotes()
        {

            logger.LogInformation("GetAll request receieved.");
            List<NoteItem> notes;

            try
            {
                notes = await noteRepository.GetNotes();
            }
            catch (Exception e)
            {
                logger.LogError(e.Message);
                return BadRequest("Couldn't get notes.");
            }

            return Ok(notes);
        }

        [HttpGet("{title}")]
        [ProducesResponseType(typeof(NoteItem), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<ActionResult<NoteItem>> GetNote(string title)
        {
            NoteItem? n;
            try
            {
                n = await noteRepository.GetNoteByTitle(title.ToLower());
            }
            catch (Exception e)
            {
                logger.LogError(e.Message);
                return BadRequest($"Note with title {title} couldn't be found.");
            }

            return Ok(n);
        }

        [HttpPost("add")]
        [ProducesResponseType((int)HttpStatusCode.Accepted)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<ActionResult<NoteItem>> AddNote([FromBody] NoteItem note)
        {

            logger.LogCritical("Request received!");
            logger.LogCritical(note.ToString());


            NoteItem? n;

            try
            {
                n = await noteRepository.AddNote(note);
            }
            catch (Exception e)
            {
                logger.LogError(e.Message);
                return BadRequest("Couldn't add note.");
            }

            return Ok(n);
        }

        [HttpPut("update")]
        [ProducesResponseType((int)HttpStatusCode.Accepted)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<ActionResult<NoteItem>> UpdateNote([FromBody] NoteItem note)
        {
            logger.LogInformation("Request received.");

            NoteItem n;

            try
            {
                n = await noteRepository.UpdateNote(note);
            }
            catch (Exception e)
            {
                logger.LogError(e.Message);
                return BadRequest("Couldn't add note.");
            }

            logger.LogInformation("Request complete.");
            return Ok(n);
        }

        [HttpDelete("delete/{title}")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<ActionResult> DeleteNote(string title)
        {

            logger.LogInformation("Delete request received.");

            try
            {
                await noteRepository.DeleteNote(title.ToLower());
            }
            catch (Exception e)
            {
                logger.LogError(e.Message);
                return BadRequest($"Couldn't find note with title: {title}");
            }

            return Ok();
        }

        [HttpGet("folder/{id}")]
        public async Task<ActionResult<List<NoteItem>>> GetFolderNotes(int id)
        {
            List<NoteItem>? notes;

            try
            {
                notes = await noteRepository.GetFolderNotesAsync(id);

            }
            catch (Exception e)
            {
                logger.LogError(e.Message);
                return new List<NoteItem>();
            }

            return Ok(notes);
        }

        //[HttpPut("modifyfolder")]
        //[ProducesResponseType((int)HttpStatusCode.Accepted)]
        //[ProducesResponseType((int)HttpStatusCode.BadRequest)]
        //public async Task<ActionResult<NoteItem>> ModifyFolder([FromBody] NoteItemUpdate note)
        //{


        //    try
        //    {
        //        // Check if folder exists
        //        HttpClient client = httpClientFactory.CreateClient();
        //        HttpResponseMessage resp1 = await client.GetAsync($"https://localhost:7085/Folder/exists/{note.FolderId}");
                
        //        if(resp1.IsSuccessStatusCode)
        //        {

        //            logger.LogInformation("Response 1 successful.");

        //            StringContent content = new StringContent(JsonSerializer.Serialize(note), Encoding.UTF8, "application/json");

        //            HttpResponseMessage resp2 = await client.PutAsync("https://localhost:7085/Folder/removenote", content); // remove note from folder

        //            if(resp2.IsSuccessStatusCode)
        //            {

        //                logger.LogInformation("Response 2 successful.");

        //                note = await noteRepository.UpdateNote(note, ); // update note

        //                StringContent newNote = new StringContent(JsonSerializer.Serialize(note));

        //                HttpResponseMessage resp3 = await client.PutAsync($"https://localhost:7085/Folder/addnote", newNote);// add note to folder

        //                if (resp3.IsSuccessStatusCode)
        //                {
        //                    logger.LogInformation("Response 3 successful.");
        //                    List<NoteItem>? resultNotes = JsonSerializer.Deserialize<List<NoteItem>>(await resp3.Content.ReadAsStringAsync());
        //                }
        //            }
                    
             
        //        } else
        //        {
        //            return BadRequest("Couldn't update folder.");
        //        }

        //        // 
        //    }
        //    catch (Exception e)
        //    {
        //        logger.LogError(e.Message);
        //        return BadRequest("Error in ModifyFolder.");
        //    }

        //    return Ok(note);
        //}
    }
}
