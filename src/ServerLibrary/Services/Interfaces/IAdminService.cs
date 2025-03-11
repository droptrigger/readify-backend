using HelpLibrary.DTOs;
using HelpLibrary.Entities;
using HelpLibrary.Responces;

namespace ServerLibrary.Services.Interfaces
{
    public interface IAdminService
    {
        /// <summary>
        /// Метод бана пользователя
        /// </summary>
        /// <param name="id">Идентификатор пользователя</param>
        /// <returns>Ответ сервера</returns>
        Task<GeneralResponce> BanUserAsync(BanUserDTO ban);

        /// <summary>
        /// Метод разбана пользователя
        /// </summary>
        /// <param name="id">Идентификатор пользователя</param>
        /// <returns>Ответ сервера</returns>
        Task<GeneralResponce> UnblockUserAsync(int id);
    }
}
