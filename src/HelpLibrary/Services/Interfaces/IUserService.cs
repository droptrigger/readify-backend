using HelpLibrary.DTOs.Users;
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
        Task<UpdateUserResponce> UpdateUserAsync(UpdateUser user);
    }
}
