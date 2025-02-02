using HelpLibrary.Entities;

namespace ServerLibrary.Repositories.Interfaces
{
    public interface IUserRepository
    {
        Task<User> FindById(int id);
        Task<User> FindByNicknameAsync(string nickname);
        Task<User> FindByEmailAsync(string email);
        Task<User> AddToDatabaseAsync(User user);
    }
}
