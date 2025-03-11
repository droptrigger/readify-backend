using HelpLibrary.DTOs.Subscribe;
using HelpLibrary.DTOs.Users;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ServerLibrary.Services.Interfaces;

namespace Server.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    [ApiController]
    public class UserController : Controller
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPut("/api/user/update")]
        [Consumes("multipart/form-data")]
        public async Task<IActionResult> UpdateAsync([FromForm] UpdateUserDTO user)
        {
            var userIdClaim = User.Claims.FirstOrDefault(c => c.Type == "id");
            if (userIdClaim == null || !int.TryParse(userIdClaim.Value, out int userId))
            {
                return BadRequest("Не удалось определить ID пользователя.");
            }

            user.UserId = userId;
            if (user == null) return BadRequest("Model is empty");

            try
            {
                var result = await _userService.UpdateUserAsync(user);
                return Ok(result);
            }
            catch (Exception ex) 
            { 
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("/user/subscribe")]
        public async Task<IActionResult> Subscribe([FromForm] SubscribeDTO sub)
        {
            if (sub == null) return BadRequest("Model is empty");

            try
            {
                var result = await _userService.SubscribeAsync(sub);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("/user/unsubscribe")]
        public async Task<IActionResult> UnSubscribe([FromForm] SubscribeDTO unsub)
        {
            if (unsub == null) return BadRequest("Model is empty");

            try
            {
                var result = await _userService.UnsubscribeAsync(unsub);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("/user/subscribers")]
        public async Task<IActionResult> GetSubscribers(int id)
        {
            try
            {
                var result = await _userService.GetAllSubscribersAsync(id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("/user/subscriptions")]
        public async Task<IActionResult> GetSubscriptions(int id)
        {
            try
            {
                var result = await _userService.GetAllSubscriptionsAsync(id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
