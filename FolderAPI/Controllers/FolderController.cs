using Folder.API;
using FolderAPI.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using NoteAPI.Models;
using System.Net;
using System.Text.Json;

namespace FolderAPI.Controllers
{

    [EnableCors]
    [Route("[controller]")]
    [ApiController]
    public class FolderController : ControllerBase
    {


        private readonly ILogger<FolderController> logger;
        private readonly IHttpClientFactory httpClientFactory;
        private readonly IFolderRepository folderRepository;

        public FolderController(ILogger<FolderController> _logger, IHttpClientFactory _httpClientFactory, IFolderRepository _folderRepository)
        {
            logger = _logger ?? throw new ArgumentException(nameof(logger));
            httpClientFactory = _httpClientFactory ?? throw new ArgumentException(nameof(httpClientFactory));
            folderRepository = _folderRepository ?? throw new ArgumentException(nameof(folderRepository));
        }

        

        //[HttpGet("{id}")]
        //[ProducesResponseType(typeof(FolderCollection), (int)HttpStatusCode.OK)]
        //public async Task<ActionResult<FolderCollection>> GetFolderById(int id)
        //{
        //    FolderCollection f;
        //    try
        //    {
        //        f = await folderRepository.GetFolderAsync(id);
        //        if (f == null)
        //        {
        //            throw new NullReferenceException();
        //        }
        //    }
        //    catch (Exception e)
        //    {
        //        logger.LogError(e.Message);
        //        return BadRequest("No folder with that id");
        //    }
        //    return Ok(f);
        //}

        //[HttpPost("add")]
        //[ProducesResponseType(typeof(FolderCollection), (int)HttpStatusCode.Accepted)]
        //[ProducesResponseType(typeof(FolderCollection), (int)HttpStatusCode.BadRequest)]
        //public async Task<ActionResult<FolderCollection>> AddNoteToFolder([FromBody] NoteItem note)
        //{

        //    // makes a http request to NoteController API
        //    HttpClient client = httpClientFactory.CreateClient();
        //    client.DefaultRequestHeaders.Accept.Clear();
        //    client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
        //    logger.LogError("Got here");


        //    HttpResponseMessage response = await client.PostAsJsonAsync("https://71.192.85.200:49157/Note/add", note);

        //    logger.LogError("Got here");

        //    if (response.IsSuccessStatusCode == false)
        //    {
        //        logger.LogError("Couldn't complete post request.");
        //        return BadRequest("Failed to add note to folder.");
        //    }

        //    HttpContent content = response.Content;
        //    string str = await content.ReadAsStringAsync();

        //    NoteItem noteItem = JsonSerializer.Deserialize<NoteItem>(str);

        //    // call FolderRepository to add the NoteItem to a Folder with Id
        //    await folderRepository.AddNoteToFolderAsync(noteItem);




        //    return Ok(JsonSerializer.Deserialize<FolderCollection>(str));
        //}

        //[HttpPost("create")]
        //public async Task<ActionResult> CreateFolder([FromBody] FolderCollection folder)
        //{
        //    try
        //    {

        //    }
        //    catch (Exception)
        //    {

        //        throw;
        //    }
        //}



        [HttpGet("all")]
        public async Task<ActionResult<List<FolderCollection>>> GetAllFolders()
        {

            List<FolderCollection> folders = await folderRepository.GetAllFoldersAsync();

            return Ok(folders);

        }

        //[HttpPut("update/{text}")]
        //public async Task<ActionResult<NoteItem>> ModifyFolder(string text)
        //{

        //}


        [HttpGet("foldernotes/{id}")]
        public async Task<ActionResult> GetFolderNotes(int id)
        {
            List<NoteItem> notes;

            try
            {
                notes = await folderRepository.GetNotesOfFolderAsync(id);
                if (notes == null)
                {
                    return BadRequest("Folder not found.");
                }
            }
            catch (Exception e)
            {

                logger.LogError(e.Message);
                return BadRequest();
            }

            return Ok(notes);
        }



        [HttpGet("exists/{id}")]
        public async Task<ActionResult<bool>> DoesFolderExist(int id)
        {
            bool exists;
            
            try
            {
                exists = await folderRepository.CheckExistsAsync(id);
                
            }
            catch (Exception e)
            {

                logger.LogError(e.Message);
                return NotFound();
            }

            return exists ? Ok(true) : NotFound(false);
        }

        [HttpPut("removenote")]
        public async Task<ActionResult> RemoveNote(NoteUpdate note)
        {
            logger.LogInformation("Removed received");
            bool wasRemoved;

            try
            {
                wasRemoved = await folderRepository.DeleteNoteFromFolderAsync(note);

                if(wasRemoved == false)
                {
                    return BadRequest();
                } 
            }
            catch (Exception)
            {

                throw;
            }

            return Ok();
        }

        [HttpPut("addnote")]
        public async Task<ActionResult<List<NoteItem>>> AddNoteToFolder(NoteItem note)
        {

            List<NoteItem> notes;
            
            try
            {
                notes = await folderRepository.AddNoteToFolderAsync(note);

                if(notes == null)
                {
                    return BadRequest();
                }
            }
            catch (Exception e)
            {


                logger.LogError(e.Message);
                return BadRequest();
            }

            return Ok(notes);
        }

    }

}
