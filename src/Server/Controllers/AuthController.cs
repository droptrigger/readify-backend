using HelpLibrary.DTOs.Users;
using Microsoft.AspNetCore.Authorization;
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
        public async Task<IActionResult> Register([FromForm] RegistrationDTO user)
        {
            if (user == null) return BadRequest("Model is empty");

            try
            {
                var result = await _authService.RegisterUserAsync(user);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("send-mail")]
        [Consumes("multipart/form-data")]
        public async Task<IActionResult> SendMail([FromForm] string email)
        {
            if (email == null) return BadRequest("Model is empty");
            try
            {
                await _authService.SendRegisterEmailCodeAsync(email);
                return Ok("Success");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("login")]
        [Consumes("multipart/form-data")]
        public async Task<IActionResult> Login([FromForm] LoginDTO user)
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

        [HttpPost("logout")]
        [Authorize]
        [Consumes("multipart/form-data")]
        public async Task<IActionResult> LogOut([FromForm] string refreshToken)
        {
            if (refreshToken == null) return BadRequest("Model is empty");
            try
            {
                var result = await _authService.LogOut(refreshToken);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
