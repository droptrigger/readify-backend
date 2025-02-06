using HelpLibrary.DTOs.Subscribe;
using HelpLibrary.DTOs.Users;
using HelpLibrary.Entities;

namespace ServerLibrary.Repositories.Interfaces.IUser
{
    public interface ISubscribeRepository
    {
        /// <summary>
        /// Метод подписки на пользователя
        /// </summary>
        /// <param name="subscribe">Объект передачи данных, содержащий идентификаторы автора и подписчика</param>
        Task SubscribeAsync(SubscribeDTO subscribe);

        /// <summary>
        /// Метод отписки от пользователя
        /// </summary>
        /// <param name="unsubscribe">Объект передачи данных, содержащий идентификаторы автора и подписчика</param>
        Task UnsubscribeAsync(SubscribeDTO unsubscribe);

        /// <summary>
        /// Метод для поиска подписки.
        /// </summary>
        /// <param name="data">Объект передачи данных, содержащий идентификаторы автора и подписчика</param>
        /// <returns>Найденный объект</returns>
        Task<UserSubscriber> GetSubByIdAsync(SubscribeDTO data);

        /// <summary>
        /// Метод получения всех подписчиков
        /// </summary>
        /// <param name="id">Идентификатор автора</param>
        /// <returns>Список всех подписчиков</returns>
        Task<List<UserInfoDTO>> GetSubscribersByIdAsync(int id);

        /// <summary>
        /// Метод получения всех подписок пользователя
        /// </summary>
        /// <param name="id">Идентификатор пользователя</param>
        /// <returns>Список всех подписок</returns>
        Task<List<UserInfoDTO>> GetSubscriptionsByIdAsync(int id);

        /// <summary>
        /// МЕТОД ДЛЯ КАСКАДНОСТИ
        /// Метод получения всех объектов из бд
        /// </summary>
        /// <param name="authoId">Индентификатор автора</param>
        /// <returns>Список объектов для удаления</returns>
        Task<List<UserSubscriber>> GetAllSubsByAuthorAsync(int authoId);

        /// <summary>
        /// МЕТОД ДЛЯ КАСКАДНОСТИ
        /// Метод получения всех объектов из бд
        /// </summary>
        /// <param name="subId">Индентификатор подписчика</param>
        /// <returns>Список объектов для удаления</returns>
        Task<List<UserSubscriber>> GetAllSubsBySubAsync(int subId);
    }
}
