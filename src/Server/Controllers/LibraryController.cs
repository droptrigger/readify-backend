﻿using HelpLibrary.DTOs.Library;
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

        [HttpPost("/api/library")]
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
        
        [HttpDelete("/api/library")]
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
        
        [HttpPut("/api/library")]
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
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
