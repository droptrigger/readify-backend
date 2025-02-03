using HelpLibrary.DTOs.Users;
using HelpLibrary.Entities;

namespace ServerLibrary.Repositories.Interfaces
{
    public interface IUserRepository
    {
        Task<User> FindByIdAsync(int id);
        Task<User> FindByNicknameAsync(string nickname);
        Task<User> FindByEmailAsync(string email);
        Task<UserSession> FindRefreshAsync(string refreshToken);

        Task<User> UpdateAsync(UpdateUser user);
        Task<User> AddToDatabaseAsync(User user);
        Task<UserSession> UpdateRefreshAsync(UserSession session, string refreshToken);
        Task<UserSession> AddSessionToDatabaseAsync(UserSession session);
        Task<UserSession> FindSessionByUserIdAsync(int userId, string device);
    }
}
