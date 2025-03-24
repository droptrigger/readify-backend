using HelpLibrary.DTOs.Users;
using HelpLibrary.DTOs;
using HelpLibrary.Entities;
using HelpLibrary.Responces;
using Microsoft.AspNetCore.Http;
using ServerLibrary.Helpers;
using ServerLibrary.Repositories.Interfaces;
using ServerLibrary.Services.Interfaces;
using ServerLibrary.Helpers.Exceptions.User;
using ServerLibrary.Helpers.Exceptions;
using Microsoft.EntityFrameworkCore;
using HelpLibrary.DTOs.Subscribe;
using ServerLibrary.Repositories.Interfaces.IUser;
using ServerLibrary.Helpers.Converters;

namespace ServerLibrary.Services.Implementations
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly ILogRepository _logRepository;
        private readonly ISubscribeRepository _subscribeRepository;

        public UserService(IUserRepository userRepository, ILogRepository logRepository, ISubscribeRepository subscribeRepository)
        {
            _userRepository = userRepository;
            _logRepository = logRepository;
            _subscribeRepository = subscribeRepository;
        }

        public async Task<List<UserInfoDTO>> GetAllSubscribersAsync(int idAuthor) =>
            await _subscribeRepository.GetSubscribersByIdAsync(idAuthor);


        public async Task<List<UserInfoDTO>> GetAllSubscriptionsAsync(int idUser) =>
            await _subscribeRepository.GetSubscriptionsByIdAsync(idUser);
        

        public async Task<UserDTO> GetUserDTO(int id)
        {
            var user = await _userRepository.FindByIdAsync(id);

            return await ConvertToUserDTO.Convert(user);
        }

        public async Task<GeneralResponce> SubscribeAsync(SubscribeDTO subscribe)
        {
            if (subscribe is null) throw new NullReferenceException("Model is empty");

            if (subscribe.SubscriberId == subscribe.AuthorId) throw new Exception();

            var sub = await _subscribeRepository.GetSubByIdAsync(subscribe);
            if (sub is not null) throw new AlreadySubscribedExceprion("You have already subscribed to this user");

            await _subscribeRepository.SubscribeAsync(subscribe);
            await _logRepository.WriteLogsAsync(new LogsDTO { IdUser = subscribe.SubscriberId, Action = Constants.Subscribe + subscribe.AuthorId });

            return new GeneralResponce("Success");
        }

        public async Task<GeneralResponce> UnsubscribeAsync(SubscribeDTO unsubscribe)
        {
            if (unsubscribe is null) throw new NullReferenceException("Model is empty");

            var sub = await _subscribeRepository.GetSubByIdAsync(unsubscribe);
            if (sub is null) throw new NotFoundException("Don't found");

            await _subscribeRepository.UnsubscribeAsync(unsubscribe);
            await _logRepository.WriteLogsAsync(new LogsDTO { IdUser = unsubscribe.SubscriberId, Action = Constants.UnSubscribe + unsubscribe.AuthorId });

            return new GeneralResponce("Success");
        }

        public async Task<UserDTO> UpdateUserAsync(UpdateUserDTO user)
        {
            var updateUser = await _userRepository.FindByIdAsync(user.UserId);
            if (updateUser is null) throw new NotFoundUserException("Not found user");

            if (user.AvatarImage is not null)
            {
                if (File.Exists(updateUser.AvatarImagePath) &&
                    (updateUser.AvatarImagePath != Constants.DefaultAvatar))

                    File.Delete(updateUser.AvatarImagePath);

                await DownloadFile(user.AvatarImage, updateUser);
            }

            await _userRepository.UpdateAsync(user);
            await _logRepository.WriteLogsAsync(new LogsDTO { IdUser = user.UserId, Action = Constants.Update });

            return await ConvertToUserDTO.Convert(updateUser);
        }

        public async Task<GeneralResponce> RemoveUserAsync(int id)
        {
            var user = await _userRepository.FindByIdAsync(id);
            if (user is null) throw new NotFoundUserException("User not found");

            await _userRepository.RemoveFromDatabaseAsync(user);

            return new GeneralResponce("Success");
        }

        private async Task<string> DownloadFile(IFormFile file, User user)
        {
            try
            {
                string fileName = $"user-id{user.Id}.png";
                var filePath = Path.Combine(Constants.PathToUserAvatar!,fileName);

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                    user.AvatarImagePath = Constants.PathUserImages + fileName;
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
