using HelpLibrary.DTOs.Reviews;
using HelpLibrary.Entities;
using HelpLibrary.Responces;
using ServerLibrary.Repositories.Interfaces.BooksInterfaces;
using ServerLibrary.Services.Interfaces;

namespace ServerLibrary.Services.Implementations
{
    public class ReviewService : IReviewService
    {
        private readonly IBookReviewRepository _bookReviewRepository;

        public ReviewService(IBookReviewRepository bookReviewRepository)
        { 
            _bookReviewRepository = bookReviewRepository;
        }

        public async Task<GeneralResponce> AddReviewAsync(AddReviewDTO addReview)
        {
            if (addReview is null) throw new NullReferenceException("Model is empty");

            var findReview = await _bookReviewRepository.FindByAuthorIdAndBookIdAsync(addReview.IdAuthor, addReview.IdBook);
            if (findReview is not null) throw new Exception("Error: You have already left a review for this book.");

            BookReview review = new BookReview()
            {
                IdAuthor = addReview.IdAuthor,
                IdBook = addReview.IdBook,
                Comment = addReview.Comment,
                Rating = addReview.Rating,
                CreatedAt = DateTime.UtcNow
            };

            var addedReview = await _bookReviewRepository.AddToDatabaseAsync(review);

            return new GeneralResponce("Success");
        }

        public async Task<GeneralResponce> DeleteReviewAsync(int id)
        {
            var findReview = await _bookReviewRepository.FindByIdAsync(id);
            if (findReview is null) throw new Exception("Don't found");

            await _bookReviewRepository.DeleteByIdAsync(id);
            return new GeneralResponce("Success");
        }


        public async Task<BookReview> GetReviewAsync(int id)
        {
            var findReview = await _bookReviewRepository.FindByIdAsync(id);
            if (findReview is null) throw new Exception("Don't found");

            return findReview;
        }

        public async Task<GeneralResponce> UpdateReviewAsync(UpdateReviewDTO updateReview)
        {
            if (updateReview is null) throw new NullReferenceException("Model is empty");

            await _bookReviewRepository.UpdateReviewAsync(updateReview);
            return new GeneralResponce("Success");
        }
    }
}
