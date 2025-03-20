using HelpLibrary.DTOs.Reviews;
using HelpLibrary.Entities;
using Microsoft.EntityFrameworkCore;
using ServerLibrary.Data;
using ServerLibrary.Repositories.Interfaces.BooksInterfaces;

namespace ServerLibrary.Repositories.Implementations.Books
{
    public class BookReviewRepository : IBookReviewRepository
    {
        private readonly ReadifyContext _context;

        public BookReviewRepository(ReadifyContext context)
        {
            _context = context;
        }

        public async Task<BookReview> AddToDatabaseAsync(BookReview review)
        {
            var result = await _context.BookReviews.AddAsync(review);
            await _context.SaveChangesAsync();
            return result.Entity;
        }

        public async Task DeleteByIdAsync(int id)
        {
            var find = await FindByIdAsync(id);
            _context.BookReviews.Remove(find);
            await _context.SaveChangesAsync();
        }

        public async Task<BookReview> FindByAuthorIdAndBookIdAsync(int authoId, int bookId) =>
            await _context.BookReviews.FirstOrDefaultAsync(br => br.IdAuthor == authoId && br.IdBook == bookId);

        public async Task<BookReview> FindByIdAsync(int id) =>
            await _context.BookReviews.FirstOrDefaultAsync(r => r.Id == id);

        public async Task<BookReview> UpdateReviewAsync(UpdateReviewDTO update)
        {
            var find = await FindByIdAsync(update.Id);
            find.Rating = update.Rating;
            find.Comment = update.Comment;

            await _context.SaveChangesAsync();

            return find;
        }
    }
}
