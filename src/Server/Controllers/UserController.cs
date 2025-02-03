using HelpLibrary.DTOs.Users;
using Microsoft.AspNetCore.Mvc;
using ServerLibrary.Services.Interfaces;

namespace Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : Controller
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPut("update")]
        [Consumes("multipart/form-data")]
        public async Task<IActionResult> UpdateAsync([FromForm] UpdateUser user)
        {
            if (user == null) return BadRequest("Model is empty");

            var result = await _userService.UpdateUserAsync(user);
            return Ok(result);
        }
    }
}
