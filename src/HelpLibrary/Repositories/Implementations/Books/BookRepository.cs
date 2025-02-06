using HelpLibrary.DTOs.Books;
using HelpLibrary.Entities;
using Microsoft.EntityFrameworkCore;
using ServerLibrary.Data;
using ServerLibrary.Repositories.Interfaces.Books;

namespace ServerLibrary.Repositories.Implementations.Books
{
    public class BookRepository : IBookRepository
    {
        private readonly ReadifyContext _context;

        public BookRepository(ReadifyContext context) { _context = context; }

        public async Task<Book> AddToDatabaseAsync(Book book)
        {
            var result = await _context.Books.AddAsync(book);
            await _context.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<List<Book>> FindAllBooksByDescriptionAsync(string description) =>
            await _context.Books.Where(b => EF.Functions.Like(b.Description, $"%{description.ToLower()}%")).ToListAsync();

        public async Task<List<Book>> FindAllBooksByNameAsync(string name) =>
            await _context.Books.Where(b => EF.Functions.Like(b.Name, $"%{name.ToLower()}%")).ToListAsync();

        public async Task<Book> FindBookByIdAsync(int id) =>
            await _context.Books.FirstOrDefaultAsync(b => b.Id == id);

        public async Task<List<Book>> GetAllBooksByGenreAsync(int idGenre) =>
            await _context.Books.Where(b => b.IdGenre == idGenre).ToListAsync();

        public async Task RemoveFromDatabaseAsync(Book book)
        {
            _context.Books.Remove(book);
            await _context.SaveChangesAsync();
        }

        public async Task SaveChangesAsync() =>
            await _context.SaveChangesAsync();
        

        public async Task<Book> UpdateBookAsync(UpdateBookDTO book)
        {
            var model = await FindBookByIdAsync(book.Id);

            if (book.Name != null) model.Name = book.Name;
            if (book.Description != null) model.Description = book.Description;
            model.IdGenre = book.IdGenre;
            model.IsPrivate = book.IsPrivate;

            await _context.SaveChangesAsync();
            return model;
        }
    }
}
