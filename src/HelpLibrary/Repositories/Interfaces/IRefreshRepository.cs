
using HelpLibrary.Entities;

namespace ServerLibrary.Repositories.Interfaces
{
    public interface IRefreshRepository
    {
        /// <summary>
        /// Метод обновления рефреш-токена
        /// </summary>
        /// <param name="session">Сессия из БД</param>
        /// <param name="refreshToken">Обновленный рефреш-токен</param>
        /// <returns>Обновленная сессия</returns>
        Task<UserSession> UpdateRefreshAsync(UserSession session, string refreshToken);

        /// <summary>
        /// Метод добавления сессии в БД
        /// </summary>
        /// <param name="session">Новый объект класса UserSession</param>
        /// <returns>Добавленная сессия</returns>
        Task<UserSession> AddSessionToDatabaseAsync(UserSession session);

        /// <summary>
        /// Метод поиска сессии по ID пользователя
        /// </summary>
        /// <param name="userId">Уникальный идентификатор пользователя</param>
        /// <param name="device">Тип устройства (web/desktop/mobile)</param>
        /// <returns>Найденная сессия</returns>
        Task<UserSession> FindSessionByUserIdAsync(int userId, string device);

        /// <summary>
        /// Метод поиска сессии по рефреш-токену
        /// </summary>
        /// <param name="refreshToken">Рефреш-токен</param>
        /// <returns>Найденная сессия</returns>
        Task<UserSession> FindRefreshAsync(string refreshToken);
    }
}
