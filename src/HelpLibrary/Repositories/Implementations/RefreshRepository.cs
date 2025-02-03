using HelpLibrary.Entities;
using Microsoft.EntityFrameworkCore;
using ServerLibrary.Data;
using ServerLibrary.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerLibrary.Repositories.Implementations
{
    public class RefreshRepository : IRefreshRepository
    {
        private readonly ReadifyContext _context;

        public RefreshRepository(ReadifyContext context)
        {
            _context = context;
        }

        public async Task<UserSession> AddSessionToDatabaseAsync(UserSession session)
        {
            var result = _context.Add(session!);
            await _context.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<UserSession> FindRefreshAsync(string refreshToken) =>
            await _context.UserSessions.FirstOrDefaultAsync(s => s.RefreshTokenHash == refreshToken);

        public async Task<UserSession> FindSessionByUserIdAsync(int userId, string device) =>
            await _context.UserSessions.FirstOrDefaultAsync(s => s.IdUser == userId && s.DeviceType == device);

        public async Task<UserSession> UpdateRefreshAsync(UserSession session, string refreshToken)
        {
            session.RefreshTokenHash = refreshToken;
            session.CreatedAt = DateTime.UtcNow;
            session.ExpiresIn = DateTime.UtcNow.AddDays(15);
            await _context.SaveChangesAsync();
            return session;
        }
    }
}
