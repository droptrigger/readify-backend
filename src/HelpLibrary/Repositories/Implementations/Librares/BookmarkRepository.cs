using HelpLibrary.DTOs.Library;
using HelpLibrary.Entities;
using Microsoft.EntityFrameworkCore;
using ServerLibrary.Data;
using ServerLibrary.Repositories.Interfaces.ILibrares;

namespace ServerLibrary.Repositories.Implementations.Librares
{
    public class BookmarkRepository : IBookmarksRepository
    {
        private readonly ReadifyContext _context;
        public BookmarkRepository(ReadifyContext context) 
        {
            _context = context;
        }

        public async Task<Bookmark> AddBookMarkAsync(Bookmark bookmark)
        {
            var result = await _context.Bookmarks.AddAsync(bookmark);
            await _context.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<List<Bookmark>> GetAllBookmarksByLibrayAsync(int idLibrary) =>
            await _context.Bookmarks.Where(b => b.IdLibrary == idLibrary).ToListAsync();

        public async Task<Bookmark> GetBookmarkByIdAsync(int idBookmark) =>
            await _context.Bookmarks.FirstOrDefaultAsync(b => b.Id == idBookmark);

        public async Task RemoveBookMarkAsync(Bookmark bookmark)
        {
            _context.Bookmarks.Remove(bookmark);
            await _context.SaveChangesAsync();
        }

        public async Task<Bookmark> UpdateBookmarkAsync(UpdateBookmarkDTO update)
        {
            var bookmark = await GetBookmarkByIdAsync(update.IdBookmark);
            bookmark.Comment = update.Comment;
            await _context.SaveChangesAsync();
            return bookmark;
        }
    }
}
