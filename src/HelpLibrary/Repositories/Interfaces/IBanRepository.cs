using HelpLibrary.Entities;

namespace ServerLibrary.Repositories.Interfaces
{
    public interface IBanRepository
    {
        /// <summary>
        /// Метод блокировки пользователя
        /// </summary>
        /// <param name="user">Новый объект</param>
        /// <returns>Созданный объект</returns>
        Task<BannedUser> BanUserAsync(BannedUser user);

        /// <summary>
        /// Метод разблокировки пользователя
        /// </summary>
        /// <param name="id">Идентификатор пользователя</param>
        /// <returns>Объект разблокированного пользователя</returns>
        Task UnblockUserAsync(int id);
        
        /// <summary>
        /// Метод получения бана по Id пользователя
        /// </summary>
        /// <param name="userId">Идентификатор пользователя</param>
        /// <returns>Найденный объект</returns>
        Task<BannedUser> GetBanByUserIdAsync(int userId);
    }
}
