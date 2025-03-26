using HelpLibrary.DTOs.Users;
using HelpLibrary.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using ServerLibrary.Data;
using ServerLibrary.Repositories.Interfaces.IUser;

namespace ServerLibrary.Repositories.Implementations.UserI
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

        public async Task<User?> FindByEmailAsync(string email) =>
            await _context.Users
                .Include(u => u.Books)
                    .ThenInclude(b => b.IdGenreNavigation)
                .Include(u => u.Libraries)
                    .ThenInclude(l => l.IdBookNavigation)
                        .ThenInclude(b => b.IdGenreNavigation)
                .Include(u => u.Libraries)
                    .ThenInclude(l => l.IdBookNavigation)
                        .ThenInclude(u => u.IdAuthorNavigation)
                .Include(u => u.Libraries)
                    .ThenInclude(l => l.Bookmarks)
                .Include(u => u.UserSubscriberIdAuthorNavigations)
                    .ThenInclude(us => us.IdSubscriberNavigation)
                .Include(u => u.UserSubscriberIdSubscriberNavigations)
                    .ThenInclude(us => us.IdAuthorNavigation)
                .Include(u => u.BookReviews)
                    .ThenInclude(r => r.IdBookNavigation)
                        .ThenInclude(b => b.IdAuthorNavigation)
                .Include(u => u.BookReviews)
                    .ThenInclude(l => l.LikesReviews)
                .Include(u => u.BookReviews)
                    .ThenInclude(l => l.IdBookNavigation)
                        .ThenInclude(b => b.IdGenreNavigation)
                .AsSplitQuery()
                .FirstOrDefaultAsync(u => u.Email == email);

        public async Task<User?> FindByIdAsync(int id) =>
            await _context.Users
                .Include(u => u.Books)
                    .ThenInclude(b => b.IdGenreNavigation)
                .Include(u => u.Libraries)
                    .ThenInclude(l => l.IdBookNavigation)
                        .ThenInclude(b => b.IdGenreNavigation)
                .Include(u => u.Libraries)
                    .ThenInclude(l => l.IdBookNavigation)
                        .ThenInclude(u => u.IdAuthorNavigation)
                .Include(u => u.Libraries)
                    .ThenInclude(l => l.Bookmarks)
                .Include(u => u.UserSubscriberIdAuthorNavigations)
                    .ThenInclude(us => us.IdSubscriberNavigation)
                .Include(u => u.UserSubscriberIdSubscriberNavigations)
                    .ThenInclude(us => us.IdAuthorNavigation)
                .Include(u => u.BookReviews)
                    .ThenInclude(r => r.IdBookNavigation)
                        .ThenInclude(b => b.IdAuthorNavigation)
                .Include(u => u.BookReviews)
                    .ThenInclude(l => l.LikesReviews)
                .Include(u => u.BookReviews)
                    .ThenInclude(l => l.IdBookNavigation)
                        .ThenInclude(b => b.IdGenreNavigation)
                .AsSplitQuery()
                .FirstOrDefaultAsync(u => u.Id == id);

        public async Task<User?> FindByNicknameAsync(string nickname) =>
            await _context.Users
                .Include(u => u.Books)
                    .ThenInclude(b => b.IdGenreNavigation)
                .Include(u => u.Libraries)
                    .ThenInclude(l => l.IdBookNavigation)
                        .ThenInclude(b => b.IdGenreNavigation)
                .Include(u => u.Libraries)
                    .ThenInclude(l => l.IdBookNavigation)
                        .ThenInclude(u => u.IdAuthorNavigation)
                .Include(u => u.Libraries)
                    .ThenInclude(l => l.Bookmarks)
                .Include(u => u.UserSubscriberIdAuthorNavigations)
                    .ThenInclude(us => us.IdSubscriberNavigation)
                .Include(u => u.UserSubscriberIdSubscriberNavigations)
                    .ThenInclude(us => us.IdAuthorNavigation)
                .Include(u => u.BookReviews)
                    .ThenInclude(r => r.IdBookNavigation)
                        .ThenInclude(b => b.IdAuthorNavigation)
                .Include(u => u.BookReviews)
                    .ThenInclude(l => l.LikesReviews)
                .Include(u => u.BookReviews)
                    .ThenInclude(l => l.IdBookNavigation)
                        .ThenInclude(b => b.IdGenreNavigation)
                .AsSplitQuery()
                .FirstOrDefaultAsync(u => u.Nickname == nickname);

        public async Task RemoveFromDatabaseAsync(User user)
        {
            var subs = await GetAllSub(user.Id);
            _context.UserSubscribers.RemoveRange(subs);

            var book = await GetAllBooks(user.Id);
            _context.Books.RemoveRange(book);

            _context.Users.Remove(user);
            await _context.SaveChangesAsync();
        }

        private async Task<List<Book>> GetAllBooks(int idUser) =>
            await _context.Books.Where(b => b.IdAuthor == idUser).ToListAsync();

        private async Task<List<UserSubscriber>> GetAllSub(int idUser) =>
            await _context.UserSubscribers.Where(us => us.IdSubscriber == idUser || us.IdAuthor == idUser).ToListAsync();

        public async Task<User> UpdateAsync(UpdateUserDTO updateUser)
        {
            var findUser = await FindByIdAsync(updateUser.UserId);

            if (updateUser.Nickname is not null) findUser!.Nickname = updateUser.Nickname!;
            if (updateUser.Description is not null) findUser!.Description = updateUser.Description;
            if (updateUser.Name is not null) findUser!.Name = updateUser.Name!;
            if (updateUser.Password is not null) findUser!.PasswordHash = new PasswordHasher<object>().HashPassword(null!, updateUser.Password!);

            await _context.SaveChangesAsync();
            return findUser!;
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
