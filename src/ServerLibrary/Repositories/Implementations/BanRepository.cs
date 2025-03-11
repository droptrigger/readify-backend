using HelpLibrary.Entities;
using Microsoft.EntityFrameworkCore;
using ServerLibrary.Data;
using ServerLibrary.Repositories.Interfaces;

namespace ServerLibrary.Repositories.Implementations
{
    public class BanRepository : IBanRepository
    {
        private readonly ReadifyContext _context;

        public BanRepository(ReadifyContext context) 
        {
            _context = context;
        }

        public async Task<BannedUser> BanUserAsync(BannedUser user)
        {
            var result = await _context.BannedUsers.AddAsync(user);
            await _context.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<BannedUser> GetBanByUserIdAsync(int userId) =>
            await _context.BannedUsers.FirstOrDefaultAsync(b => b.IdUser == userId);
            

        public async Task UnblockUserAsync(int id)
        {
            var user = await GetBanByUserIdAsync(id);
            _context.BannedUsers.Remove(user);
            await _context.SaveChangesAsync();
        }
    }
}
