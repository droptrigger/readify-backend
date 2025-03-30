using HelpLibrary.DTOs.Library;
using HelpLibrary.DTOs.Users;
using HelpLibrary.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ServerLibrary.Repositories.Interfaces.ILibrares;
using ServerLibrary.Services.Interfaces;

namespace Server.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    [ApiController]
    public class LibraryController : Controller
    {
        private readonly ILibraryService _libraryService;

        public LibraryController(ILibraryService libraryService)
        {
            _libraryService = libraryService;
        }

        [HttpPost("/library")]
        [Consumes("multipart/form-data")]
        public async Task<IActionResult> AddLibrary([FromForm] AddLibraryDTO library)
        {
            if (library == null) return BadRequest("Model is empty");

            try
            {
                var result = await _libraryService.AddBookToLibraryAsync(library);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        
        [HttpDelete("/library")]
        public async Task<IActionResult> DeleteLibrary([FromForm] AddLibraryDTO library)
        {
            if (library == null) return BadRequest("Model is empty");

            try
            {
                var result = await _libraryService.DeleteBookFromLibraryAsync(library);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        
        [HttpPut("/api/library/{id}")]
        [Consumes("multipart/form-data")]
        public async Task<IActionResult> UpdateLibrary([FromForm] UpdateProgressDTO library)
        {
            if (library == null) return BadRequest("Model is empty");

            try
            {
                var result = await _libraryService.UpdateProgressPagesAsync(library);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("/api/library/{id}")]
        public async Task<IActionResult> GetLibrary(int id)
        {
            if (id < 0) return BadRequest("Model is empty");

            try
            {
                var result = await _libraryService.GetAllBooksUserAsync(id);
                Console.WriteLine(result.NotFullyReadBooks.Count);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("/library/bookmarks")]
        [Consumes("multipart/form-data")]
        public async Task<IActionResult> CreateBookmark([FromForm] AddBookmarkDTO bookmark)
        {
            if (bookmark is null) return BadRequest("Model is empty");

            try
            {
                var result = await _libraryService.AddBokmarkAsync(bookmark);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("/library/bookmarks")]
        [Consumes("multipart/form-data")]
        public async Task<IActionResult> DeleteBookmark([FromForm] int id)
        {
            if (id < 0) return BadRequest("Model is empty");

            try
            {
                var result = await _libraryService.DeleteBookmarkAsync(id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("/library/bookmarks")]
        [Consumes("multipart/form-data")]
        public async Task<IActionResult> UpdateBookmark([FromForm] UpdateBookmarkDTO bookmark)
        {
            if (bookmark is null) return BadRequest("Model is empty");

            try
            {
                var result = await _libraryService.UpdateBookmarkAsync(bookmark);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("/library/bookmarks")]
        [Consumes("multipart/form-data")]
        public async Task<IActionResult> GetBookmark([FromForm] int id)
        {
            if (id < 0) return BadRequest("Model is empty");

            try
            {
                var result = await _libraryService.GetAllBookmarksLibraryAsync(id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
