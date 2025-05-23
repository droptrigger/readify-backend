﻿using HelpLibrary.DTOs;
using HelpLibrary.DTOs.Subscribe;
using HelpLibrary.DTOs.Users;
using HelpLibrary.Entities;
using HelpLibrary.Responces;

namespace ServerLibrary.Services.Interfaces
{
    public interface IUserService
    {
        /// <summary>
        /// Метод обновления пользователя
        /// </summary>
        /// <param name="user">Объект передачи данных, который содержит обновленную информацию о пользователе</param>
        /// <returns>Объект класса UpdateUserResponce, содержащий обновленные данные</returns>
        Task<UserDTO> UpdateUserAsync(UpdateUserDTO user);

        Task<UserDTO> GetUserDTO(int id);

        /// <summary>
        /// Метод удаления пользователя
        /// </summary>
        /// <param name="id">Идентификатор пользователя</param>
        /// <returns>Ответ сервера</returns>
        Task<GeneralResponce> RemoveUserAsync(int id);

        /// <summary>
        /// Метод для подписки на пользователя
        /// </summary>
        /// <param name="subscribe">Объект передачи данных, содержащий идентификаторы автора и подписчика</param>
        /// <returns>Объект класса GeneralResponce, содержащий ответ сервера</returns>
        Task<UserDTO> SubscribeAsync(SubscribeDTO subscribe);

        /// <summary>
        /// Метод отписки от пользователя
        /// </summary>
        /// <param name="unsubscribe">Объект передачи данных, содержащий идентификаторы автора и подписчика</param>
        /// <returns>Объект класса GeneralResponce, содержащий ответ сервера</returns>
        Task<UserDTO> UnsubscribeAsync(SubscribeDTO unsubscribe);

        /// <summary>
        /// Метод получения всех подписчиков
        /// </summary>
        /// <param name="idAuthor">Идентификатор автора</param>
        /// <returns>Список пользователей</returns>
        Task<List<UserInfoDTO>> GetAllSubscribersAsync(int idAuthor);

        /// <summary>
        /// Метод получения всех подписок пользователя
        /// </summary>
        /// <param name="idUser">Идентификатор пользователя</param>
        /// <returns>Список пользователей</returns>
        Task<List<UserInfoDTO>> GetAllSubscriptionsAsync(int idUser);

        /// <summary>
        /// Метод поиска книг и пользователей
        /// </summary>
        /// <param name="searchText">Поисковой текст</param>
        /// <returns>Список найденных пользователей и книг</returns>
        Task<SearchDTO> SearchAsync(string searchText);
    }
}
