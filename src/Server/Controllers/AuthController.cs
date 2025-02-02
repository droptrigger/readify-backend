using HelpLibrary.DTOs.Users;
using Microsoft.AspNetCore.Mvc;
using ServerLibrary.Services.Interfaces;

namespace Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IUserService _userInterface;

        public AuthController(IUserService userInterface)
        {
            _userInterface = userInterface;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(Registration user)
        {
            if (user == null) return BadRequest("Model is empty");
            var result = await _userInterface.RegisterUserAsync(user);
            return Ok(result);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(Login user)
        {
            if (user == null) return BadRequest("Model is empty");
            var result = await _userInterface.SignInAsync(user);
            return Ok(result);
        }
    }
}
