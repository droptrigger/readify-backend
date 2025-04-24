using HelpLibrary.DTOs.Subscribe;
using HelpLibrary.DTOs.Users;
using HelpLibrary.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
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
        public async Task<IActionResult> UpdateAsync([FromForm] UpdateUserDTO user)
        {
            if (user == null) return BadRequest("Model is empty");

            var userIdClaim = User.Claims.FirstOrDefault(c => c.Type == "id");
            if (userIdClaim == null || !int.TryParse(userIdClaim.Value, out int userId))
            {
                return Unauthorized("Не удалось определить ID пользователя.");
            }

            if (user.UserId != userId)
                return Forbid("Ошибка");

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

        [HttpGet("/api/user/{id}")]
        public async Task<IActionResult> GetUser(int id)
        {
            var userDTO = await _userService.GetUserDTO(id);

            return Ok(userDTO);
        }

        [HttpGet("/api/user/search")] 
        public async Task<IActionResult> Search(string searchText)
        {
            var searchDTO = await _userService.SearchAsync(searchText);

            return Ok(searchDTO);
        }
        

        [HttpPost("/api/user/subscribe")]
        public async Task<IActionResult> Subscribe([FromForm] SubscribeDTO sub)
        {
            if (sub == null)
                return BadRequest("Model is empty");

            var userIdClaim = User.Claims.FirstOrDefault(c => c.Type == "id");
            if (userIdClaim == null || !int.TryParse(userIdClaim.Value, out int userId))
            {
                return Unauthorized("Не удалось определить ID пользователя.");
            }

            if (sub.SubscriberId != userId)
                return Forbid("Ошибка");

            if (sub.SubscriberId == sub.AuthorId)
                return BadRequest("Ошибка! Нельзя подписываться на себя.");

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

        [HttpPost("/api/user/unsubscribe")]
        public async Task<IActionResult> UnSubscribe([FromForm] SubscribeDTO unsub)
        {
            if (unsub == null) 
                return BadRequest("Model is empty");

            var userIdClaim = User.Claims.FirstOrDefault(c => c.Type == "id");
            if (userIdClaim == null || !int.TryParse(userIdClaim.Value, out int userId))
            {
                return Unauthorized("Не удалось определить ID пользователя.");
            }

            if (unsub.SubscriberId != userId)
                return Forbid("Ошибка");

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

        [HttpGet("/api/user/subscribers")]
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

        [HttpGet("/api/user/subscriptions")]
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
