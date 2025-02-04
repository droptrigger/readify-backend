using HelpLibrary.DTOs;
using HelpLibrary.Entities;
using ServerLibrary.Data;
using ServerLibrary.Repositories.Interfaces;

namespace ServerLibrary.Repositories.Implementations
{
    public class LogRepository : ILogRepository
    {
        private readonly ReadifyContext _context;

        public LogRepository(ReadifyContext context)
        {
            _context = context;
        }

        public async Task<Log> WriteLogsAsync(Logs logs)
        {
            var result = await _context.AddAsync(new Log()
            {
                IdUser = logs.IdUser,
                Action = logs.Action!,
                CreatedAt = DateTime.UtcNow
            });

            await _context.SaveChangesAsync();
            return result.Entity;
        }
    }
}
