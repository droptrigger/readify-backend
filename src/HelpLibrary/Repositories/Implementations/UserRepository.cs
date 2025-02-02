using HelpLibrary.Entities;
using Microsoft.EntityFrameworkCore;
using ServerLibrary.Data;
using ServerLibrary.Repositories.Interfaces;

namespace ServerLibrary.Repositories.Implementations
{
    public class UserRepository : IUserRepository
    {
        private readonly ReadifyContext _context;
        
        public UserRepository(ReadifyContext context) 
        {
            _context = context;
        }

        public async Task<User> AddToDatabaseAsync(User user)
        {
            var result = _context.Add(user!);
            await _context.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<User> FindByEmailAsync(string email) => 
            await _context.Users.FirstOrDefaultAsync(u => u.Email == email);

        public async Task<User> FindById(int id) =>
             await _context.Users.FirstOrDefaultAsync(u => u.Id == id);

        public async Task<User> FindByNicknameAsync(string nickname) =>
             await _context.Users.FirstOrDefaultAsync(u => u.Nickname == nickname);
    }
}
