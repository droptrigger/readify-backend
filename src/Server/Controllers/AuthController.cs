using HelpLibrary.DTOs.Users;
using HelpLibrary.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ServerLibrary.Helpers.Exceptions.User;
using ServerLibrary.Services.Interfaces;

namespace Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthentificatonService _authService;

        public AuthController(IAuthentificatonService authService)
        {
            _authService = authService;
        }

        [HttpPost("register")]
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

        [HttpPost("send-mail")]
        public async Task<IActionResult> SendMail([FromBody] string email)
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

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromForm] LoginDTO user)
        {
            if (user == null) return BadRequest("Model is empty");

            try
            {
                var result = await _authService.SignInAsync(user);

                if (user.Device!.ToLower() == "web")
                {
                    Response.Cookies.Append("refreshToken", result.RefreshToken, new CookieOptions
                    {
                        HttpOnly = true,
                        Expires = DateTimeOffset.UtcNow.AddDays(150),
                        Secure = false
                    });
                }

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("refresh")]
        public async Task<IActionResult> Refresh([FromForm] RefreshDTO refreshToken)
        {
            refreshToken.refreshToken = Request.Cookies["refreshToken"];

            if (string.IsNullOrEmpty(refreshToken?.refreshToken))
            {
                return BadRequest("Refresh token is missing.");
            }

            try
            {
                var result = await _authService.RefreshToken(refreshToken.refreshToken!);

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("logout")]
        [Authorize]
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

        [HttpPost("checkusername")]
        public async Task<IActionResult> CheckUsername([FromForm] string username)
        {
            if (username == null) return BadRequest("Model is empty");
            try
            {
                var result = await _authService.CheckUsernameAsync(username);

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("checkemail")]
        public async Task<IActionResult> CheckEmail([FromForm] string email)
        {
            if (email == null) return BadRequest("Model is empty");
            try
            {
                var result = await _authService.CheckEmailAsync(email);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
