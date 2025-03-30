using HelpLibrary.DTOs.Library;
using HelpLibrary.Entities;
using Microsoft.EntityFrameworkCore;
using ServerLibrary.Data;
using ServerLibrary.Repositories.Interfaces.ILibrares;

namespace ServerLibrary.Repositories.Implementations.Librares
{
    public class LibraryRepository : ILibraryRepository
    {
        private readonly ReadifyContext _context;
        public LibraryRepository(ReadifyContext contrext)
        {
            _context = contrext;
        }

        public async Task<Library> AddBookToLibraryAsync(Library library)
        {
            var result = await _context.Libraries.AddAsync(library);
            await _context.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<Library> FindLibraryByIdUserIdBookAsync(AddLibraryDTO library) =>
            await _context.Libraries.FirstOrDefaultAsync(l => l.IdUser == library.idUser && l.IdBook == library.idBook);

        public async Task<List<Library>> GetAllBooksFromLibraryAsync(int idUser) =>
            await _context.Libraries
                .Include(library => library.IdBookNavigation)
                .Include(u => u.IdBookNavigation)
                .Include(u => u.IdBookNavigation)
                    .ThenInclude(l => l.IdGenreNavigation)
                .Include(l => l.IdBookNavigation)
                    .ThenInclude(u => u.IdAuthorNavigation)
                .Include(l => l.Bookmarks)
                .AsSplitQuery()
                .Where(library => library.IdUser == idUser)
                .ToListAsync();

        public async Task RemoveBookFromLibraryAsync(Library library)
        {
            _context.Libraries.Remove(library);
            await _context.SaveChangesAsync();

        }

        public async Task<Library> UpdateProgressAsync(UpdateProgressDTO update)
        {
            var library = await FindLibraryByIdUserIdBookAsync(new AddLibraryDTO { idBook = update.IdBook, idUser = update.IdUser });
            library.ProgressPage = update.NewPage;
            await _context.SaveChangesAsync();
            return library;
        }
    }
}
