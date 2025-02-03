using HelpLibrary.DTOs;
using HelpLibrary.Entities;

namespace ServerLibrary.Repositories.Interfaces
{
    public interface ILogRepository
    {
        /// <summary>
        /// Метод добавления логов
        /// </summary>
        /// <param name="logs">Объект передачи данных, содержащий IdUser (идентификатор пользователя) и Action (действие)</param>
        /// <returns>Объект Log</returns>
        Task<Log> WriteLogsAsync(Logs logs);
    }
}
