using HelpLibrary.DTOs;
using HelpLibrary.DTOs.Books;
using HelpLibrary.DTOs.Users;
using HelpLibrary.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ServerLibrary.Services.Interfaces;

namespace Server.Controllers
{
    [Route("api/[controller]")]
    [Authorize(Policy = "AdminOnly")]
    [ApiController]
    public class AdminController : Controller
    {
        private readonly IUserService _userService;
        private readonly IAdminService _adminService;
        private readonly IBookService _bookService;

        public AdminController(
            IAdminService adminService,
            IUserService userService,
            IBookService bookService)
        {
            _adminService = adminService;
            _userService = userService;
            _bookService = bookService;
        }

        [HttpDelete("/user/delete")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            if (id < 0) return BadRequest("Error");

            try
            {
                var result = await _userService.RemoveUserAsync(id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("/user/ban")]
        public async Task<IActionResult> BanUser(BanUserDTO ban)
        {
            if (ban is null) return BadRequest("Error");

            try
            {
                var result = await _adminService.BanUserAsync(ban);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("/user/unblock")]
        public async Task<IActionResult> UnblockUser(int id)
        {
            if (id < 0) return BadRequest("Error");

            try
            {
                var result = await _adminService.UnblockUserAsync(id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("/genres/add")]
        public async Task<IActionResult> AddGenre(string name)
        {
            if (name is null) return BadRequest("Error");

            try
            {
                var result = await _bookService.AddGenreAsync(name);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("/genres/delete")]
        [Consumes("multipart/form-data")]
        public async Task<IActionResult> DeleteGenre(int id)
        {
            if (id < 0) return BadRequest("Error");

            try
            {
                var result = await _bookService.RemoveGenreAsync(id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("/genres/update")]
        [Consumes("multipart/form-data")]
        public async Task<IActionResult> UpdateGenre([FromForm] GenreDTO genre)
        {
            if (genre is null) return BadRequest("Error");

            try
            {
                var result = await _bookService.UpdateGenreAsync(genre);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
