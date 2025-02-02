using HelpLibrary.DTOs;
using HelpLibrary.Entities;

namespace ServerLibrary.Repositories.Interfaces
{
    public interface ILogRepository
    {
        Task<Log> WriteLogsAsync(Logs logs);
    }
}
