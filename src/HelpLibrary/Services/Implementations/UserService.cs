using HelpLibrary.DTOs.Users;
using HelpLibrary.DTOs;
using HelpLibrary.Entities;
using HelpLibrary.Responces;
using Microsoft.AspNetCore.Http;
using ServerLibrary.Helpers;
using ServerLibrary.Repositories.Interfaces;
using ServerLibrary.Services.Interfaces;
using ServerLibrary.Helpers.Exceptions.User;

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
            if (updateUser is null) throw new NotFoundUserException("Not found user");

            if (user.AvatarImage is not null)
            {
                if (File.Exists(updateUser.AvatarImagePath) &&
                    (Constants.PathToUserAvatar + updateUser.AvatarImagePath != Constants.DefaultAvatar))

                    File.Delete(updateUser.AvatarImagePath);

                await DownloadFile(user.AvatarImage, updateUser);
            }

            await _userRepository.UpdateAsync(user);
            await _logRepository.WriteLogsAsync(new Logs { IdUser = user.UserId, Action = Constants.Update });

            return new UpdateUserResponce(user);
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
