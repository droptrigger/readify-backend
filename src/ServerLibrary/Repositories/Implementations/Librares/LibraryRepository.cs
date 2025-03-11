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

        public async Task<Library> FindLibraryByIdUserIdBookAsync(LibraryDTO library) =>
            await _context.Libraries.FirstOrDefaultAsync(l => l.IdUser == library.idUser && l.IdBook == library.idBook);

        public async Task<List<Book>> GetAllBooksFromLibraryAsync(int idUser) =>
            await _context.Libraries
                .Where(library => library.IdUser == idUser)
                .Include(library => library.IdBookNavigation)
                .Select(library => library.IdBookNavigation)
                .ToListAsync();

        public async Task RemoveBookFromLibraryAsync(Library library)
        {
            _context.Libraries.Remove(library);
            await _context.SaveChangesAsync();

        }

        public async Task<Library> UpdateProgressAsync(UpdateProgressDTO update)
        {
            var library = await FindLibraryByIdUserIdBookAsync(new LibraryDTO { idBook = update.IdBook, idUser = update.IdUser });
            library.ProgressPage = update.NewPage;
            await _context.SaveChangesAsync();
            return library;
        }
    }
}
