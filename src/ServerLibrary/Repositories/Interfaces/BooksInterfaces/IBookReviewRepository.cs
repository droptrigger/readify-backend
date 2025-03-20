using HelpLibrary.DTOs.Reviews;
using HelpLibrary.Entities;

namespace ServerLibrary.Repositories.Interfaces.BooksInterfaces
{
    public interface IBookReviewRepository
    {
        Task<BookReview> AddToDatabaseAsync(BookReview review);
        Task<BookReview> FindByIdAsync(int id);
        Task<BookReview> UpdateReviewAsync(UpdateReviewDTO update);
        Task DeleteByIdAsync(int id);

        Task<BookReview> FindByAuthorIdAndBookIdAsync(int authoId, int bookId);
    }
}
