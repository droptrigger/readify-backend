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

        [HttpPost("/auth/register")]
        public async Task<IActionResult> Register(RegistrationDTO user)
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

        [HttpPost("/auth/send-mail")]
        public async Task<IActionResult> SendMail(string email)
        {
            if (email == null) return BadRequest("Model is empty");
            try
            {
                var result = await _authService.SendRegisterEmailCodeAsync(email);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("/auth/login")]
        public async Task<IActionResult> Login(LoginDTO user)
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

        [HttpPost("/auth/refresh")]
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

        [HttpPost("/auth/logout")]
        [Authorize]
        public async Task<IActionResult> LogOut(string refreshToken)
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
