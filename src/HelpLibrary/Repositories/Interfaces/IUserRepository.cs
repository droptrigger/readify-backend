using HelpLibrary.DTOs.Users;
using HelpLibrary.Entities;

namespace ServerLibrary.Repositories.Interfaces
{
    public interface IUserRepository
    {
        /// <summary>
        /// Метод поиска пользователя по ID
        /// </summary>
        /// <param name="id">Уникальный идентификатор пользователя</param>
        /// <returns>Найденный пользователь</returns>
        Task<User> FindByIdAsync(int id);

        /// <summary>
        /// Метод поиска пользователя по прозвищу
        /// </summary>
        /// <param name="nickname">Прозвище пользователя</param>
        /// <returns>Найденный пользователь</returns>
        Task<User> FindByNicknameAsync(string nickname);

        /// <summary>
        /// Метод поиска пользователя по Email
        /// </summary>
        /// <param name="email">Email пользователя</param>
        /// <returns>Найденный пользователь</returns>
        Task<User> FindByEmailAsync(string email);

        /// <summary>
        /// Метод обновления пользователя
        /// </summary>
        /// <param name="user">Объект передачи данных, содержащий новые данные пользователя</param>
        /// <returns>Обновленный пользователь</returns>
        Task<User> UpdateAsync(UpdateUser user);

        /// <summary>
        /// Метод добавления пользователя в БД
        /// </summary>
        /// <param name="user">Новый объект класса User</param>
        /// <returns>Созданный пользователь</returns>
        Task<User> AddToDatabaseAsync(User user);
    }
}
