using HelpLibrary.DTOs;
using HelpLibrary.Entities;
using HelpLibrary.Responces;
using ServerLibrary.Helpers;
using ServerLibrary.Helpers.Exceptions.User;
using ServerLibrary.Repositories.Interfaces;
using ServerLibrary.Repositories.Interfaces.IUser;
using ServerLibrary.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace ServerLibrary.Services.Implementations
{
    public class AdminService : IAdminService
    {
        private readonly IBanRepository _banRepository;
        private readonly IUserRepository _userRepository;
        private readonly ILogRepository _logRepository;
        public AdminService(
            IBanRepository banRepository,
            IUserRepository userRepository,
            ILogRepository logRepository) 
        {
            _banRepository = banRepository;
            _userRepository = userRepository;
            _logRepository = logRepository;
        }

        public async Task<GeneralResponce> BanUserAsync(BanUserDTO ban)
        {
            if (ban is null) throw new NullReferenceException("Model is empty");

            var user = await _userRepository.FindByIdAsync(ban.id);
            if (user == null) throw new NotFoundUserException("User not found");

            if (user.IsBanned) throw new Exception("The user has already been banned");

            user.IsBanned = true;

            var banuser = new BannedUser()
            {
                IdUser = ban.id,
                BanReason = ban.Reason,
                BannedAt = DateTime.UtcNow
            };

            await _banRepository.BanUserAsync(banuser);
            await _logRepository.WriteLogsAsync(new LogsDTO { IdUser = ban.id, Action = Constants.Ban });

            return new GeneralResponce($"User id: {ban.id} was banned");
        }

        public async Task<GeneralResponce> UnblockUserAsync(int id)
        {
            var userBan = await _banRepository.GetBanByUserIdAsync(id);
            if (userBan is null) throw new Exception("The user is not banned");

            var user = await _userRepository.FindByIdAsync(id);
            if (user is null) throw new NotFoundUserException("User not found");

            user.IsBanned = false;
            await _banRepository.UnblockUserAsync(id);

            await _logRepository.WriteLogsAsync(new LogsDTO { IdUser = id, Action = Constants.Unban });
            return new GeneralResponce($"User id: {id} was unblocked");
        }
    }
}
