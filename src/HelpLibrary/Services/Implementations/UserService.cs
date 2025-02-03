using HelpLibrary.DTOs.Users;
using HelpLibrary.DTOs;
using HelpLibrary.Entities;
using HelpLibrary.Responces;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using ServerLibrary.Helpers;
using ServerLibrary.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServerLibrary.Services.Interfaces;

namespace ServerLibrary.Services.Implementations
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly ILogRepository _logRepository;

        public UserService(IUserRepository userRepository, ILogRepository logRepository)
        {
            _userRepository = userRepository;
            _logRepository = logRepository;
        }

        public async Task<UpdateUserResponce> UpdateUserAsync(UpdateUser user)
        {
            var updateUser = await _userRepository.FindByIdAsync(user.UserId);
            if (updateUser is null) return new UpdateUserResponce(false);

            if (user.AvatarImage is not null)
            {
                if (File.Exists(updateUser.AvatarImagePath) &&
                    (Constants.PathToUserAvatar + updateUser.AvatarImagePath != Constants.DefaultAvatar))

                    File.Delete(updateUser.AvatarImagePath);

                await DownloadFile(user.AvatarImage, updateUser);
            }

            await _userRepository.UpdateAsync(user);
            await _logRepository.WriteLogsAsync(new Logs { IdUser = user.UserId, Action = Constants.Update });

            return new UpdateUserResponce(true, user);
        }

        private async Task<string> DownloadFile(IFormFile file, User user)
        {
            try
            {
                var filePath = Path.Combine(Constants.PathToUserAvatar!, $"user-id{user.Id}.png");

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                    user.AvatarImagePath = filePath;
                    return filePath;
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error while downloading file: {ex.Message}", ex);
            }
        }
    }
}
