 using HelpLibrary.DTOs.Mail;
using HelpLibrary.Entities;

namespace ServerLibrary.Repositories.Interfaces
{
    public interface IMailRepository
    {
        /// <summary>
        /// Метод добавления кода в БД
        /// </summary>
        /// <param name="code">Объект передачи данных, содержащий почту пользователя и код подтверждения</param>
        /// <returns>Созданный объект</returns>
        Task<СonfirmationСode> WriteCodeAsync(ConfirmCode code);

        /// <summary>
        /// Метод проверки кода подтверждения
        /// </summary>
        /// <param name="code">Объект передачи данных, содержащий почту пользователя и код подтверждения</param>
        /// <returns>Найденный объект</returns>
        Task<СonfirmationСode> VerifyCodeAsync(ConfirmCode code);

        /// <summary>
        /// Метод удаления кода подтверждения из БД
        /// </summary>
        /// <param name="code">Объект из БД</param>
        Task DeleteCodeAsync(СonfirmationСode code);

        /// <summary>
        /// Метод поиска кода по email
        /// </summary>
        /// <param name="email">Email</param>
        /// <returns>Найденный объект</returns>
        Task<СonfirmationСode> FindByEmailAsync(string email);
    }
}
