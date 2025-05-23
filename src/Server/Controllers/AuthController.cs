﻿using HelpLibrary.DTOs.Users;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
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

        [HttpPost("/api/auth/register")]
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

        [HttpPost("/api/auth/send-mail")]
        public async Task<IActionResult> SendMail([FromForm] string email)
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

        [HttpPost("/api/auth/login")]
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

        [HttpPost("/api/auth/refresh")]
        public async Task<IActionResult> Refresh([FromForm] RefreshDTO refreshToken)
        {
            if (refreshToken.DeviceType == "web")
            {
                refreshToken.Token = Request.Cookies["refreshToken"];
            }
            
            if (string.IsNullOrEmpty(refreshToken?.Token))
            {
                return BadRequest("Refresh token is missing.");
            }

            try
            {
                var result = await _authService.RefreshToken(refreshToken.Token!);

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        //[HttpGet("/api/auth/user")]
        //public async Task<IActionResult> GetUser(string emailOrUsername)
        //{
        //    if (emailOrUsername is null) return BadRequest("Model is empty");
        //    try
        //    {
        //        var result = await _authService.GetUserByEmailOrUsernameAsync(emailOrUsername);
        //        return Ok(result);
        //    }
        //    catch (Exception ex) 
        //    {
        //        return BadRequest(ex.Message);
        //    }

        //}

        [HttpPost("/api/auth/logout")]
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

        [HttpPost("/api/auth/checkusername")]
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

        [HttpPost("/api/auth/checkemail")]
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
