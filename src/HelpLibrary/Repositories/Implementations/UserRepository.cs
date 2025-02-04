using HelpLibrary.DTOs.Users;
using HelpLibrary.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations.Operations;
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
            var result = await _context.AddAsync(user!);
            await _context.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<User> FindByEmailAsync(string email) => 
            await _context.Users.FirstOrDefaultAsync(u => u.Email == email);

        public async Task<User> FindByIdAsync(int id) =>
             await _context.Users.FirstOrDefaultAsync(u => u.Id == id);

        public async Task<User> FindByNicknameAsync(string nickname) =>
             await _context.Users.FirstOrDefaultAsync(u => u.Nickname == nickname);

        public async Task<User> UpdateAsync(UpdateUser updateUser)
        {
            var findUser = await FindByIdAsync(updateUser.UserId);

            if (updateUser.Nickname is not null) findUser.Nickname = updateUser.Nickname!;
            if (updateUser.Description is not null) findUser.Description = updateUser.Description;
            if (updateUser.Name is not null) findUser.Name = updateUser.Name!;
            if (updateUser.Password is not null) findUser.PasswordHash = new PasswordHasher<object>().HashPassword(null!, updateUser.Password!);

            await _context.SaveChangesAsync();
            return findUser;
        }
    }
}
