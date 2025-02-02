using HelpLibrary.DTOs.Users;
using HelpLibrary.DTOs;
using HelpLibrary.Entities;
using HelpLibrary.Responces;
using Microsoft.AspNetCore.Identity;
using ServerLibrary.Services.Interfaces;
using ServerLibrary.Repositories.Interfaces;

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

        public async Task<GeneralResponce> RegisterUserAsync(Registration user)
        {
            if (user == null) return new GeneralResponce(false, "Model is empty");

            var checkUser = await _userRepository.FindByEmailAsync(user.Email!);
            if (checkUser != null) return new GeneralResponce(false, "The user is already registered");

            checkUser = await _userRepository.FindByNicknameAsync(user.Nickname!);
            if (checkUser != null) return new GeneralResponce(false, "The user is already registered");

            var hashPassword = new PasswordHasher<object>().HashPassword(null!, user.Password!);

            User addUser = await _userRepository.AddToDatabaseAsync(new User()
            {
                Nickname = user.Nickname!,
                Name = user.Name,
                Email = user.Email!,
                PasswordHash = hashPassword,
                CreatedAt = DateTime.UtcNow,
            });

            await _logRepository.WriteLogsAsync(new Logs { IdUser = addUser.Id, Action = Helpers.Constants.Register });

            return new GeneralResponce(true, "You have successfully registered"); 
        }

        public async Task<GeneralResponce> SignInAsync(Login user)
        {
            if (user is null) return new GeneralResponce(false, "Model is empty");

            var checkUser = await _userRepository.FindByEmailAsync(user.EmailOrNickname!);
            if (checkUser is null)
            {
                checkUser = await _userRepository.FindByNicknameAsync(user.EmailOrNickname!);
                if (checkUser is null) return new GeneralResponce(false, "There is no account with this email or nickname.");
            }

            var hashPassword = new PasswordHasher<object>().HashPassword(null!, user.Password!);

            var checkPass = new PasswordHasher<object>().VerifyHashedPassword(null!, checkUser.PasswordHash, user.Password!);
            if (checkPass != PasswordVerificationResult.Success) return new GeneralResponce(false, "Invalid password");

            return new GeneralResponce(true, "Success!");
        }

        public async Task<GeneralResponce> UpdateAsync(UpdateUser user)
        {
            throw new NotImplementedException();
        }
    }
}
