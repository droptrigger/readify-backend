using HelpLibrary.DTOs.Users;
using Microsoft.AspNetCore.Mvc;
using ServerLibrary.Helpers.Exceptions.User;
using ServerLibrary.Services.Interfaces;

namespace Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : Controller
    {
        private readonly IAuthentificatonService _authService;

        public AuthController(IAuthentificatonService authService)
        {
            _authService = authService;
        }

        [HttpPost("register")]
        [Consumes("multipart/form-data")]
        public async Task<IActionResult> Register([FromForm] Registration user)
        {
            if (user == null) return BadRequest("Model is empty");

            try
            {
                var result = await _authService.RegisterUserAsync(user);
                return Ok(result);
            }
            catch (Exception ex){
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("login")]
        [Consumes("multipart/form-data")]
        public async Task<IActionResult> Login([FromForm] Login user)
        {
            if (user == null) return BadRequest("Model is empty");

            try
            {
                var result = await _authService.SignInAsync(user);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("refresh")]
        [Consumes("multipart/form-data")]
        public async Task<IActionResult> Refresh([FromForm] string refreshToken)
        {
            if (refreshToken == null) return BadRequest("Model is empty");
            try
            {
                var result = await _authService.RefreshToken(refreshToken);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
