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
        private readonly ILikesReviewsRepository _likesReviewRepository;

        public ReviewService(IBookReviewRepository bookReviewRepository, ILikesReviewsRepository likesReviewsRepository)
        { 
            _bookReviewRepository = bookReviewRepository;
            _likesReviewRepository = likesReviewsRepository;
        }

        public async Task<GeneralResponce> AddLikeAsync(AddLikeReviewDTO addLike)
        {
            if (addLike is null) throw new NullReferenceException("Model is empty");

            var findReview = await _likesReviewRepository.GetLikeByAuthorIdAndReviewIdAsync(addLike.IdAuthor, addLike.IdReview);
            if (findReview is not null) throw new Exception("Error: You have already left a like for this review.");

             LikesReview like = new LikesReview()
             {
                 IdAuthor = addLike.IdAuthor,
                 IdReview = addLike.IdReview,
                 ReactionType = addLike.ReactionType,
                 CreatedAt = DateTime.UtcNow
             };

            var addedLike = await _likesReviewRepository.AddToDatabaseAsync(like);

            return new GeneralResponce("Success");
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

        public async Task<GeneralResponce> DeleteLikeAsync(int idLike)
        {
            var like = await _likesReviewRepository.GetLikesReviewByIdAsync(idLike);
            if (like is null) throw new Exception("Don't found");

            await _likesReviewRepository.DeleteLikeReviewAsync(like);
            return new GeneralResponce("Success");
        }

        public async Task<GeneralResponce> DeleteReviewAsync(int id)
        {
            var findReview = await _bookReviewRepository.FindByIdAsync(id);
            if (findReview is null) throw new Exception("Don't found");

            await _bookReviewRepository.DeleteByIdAsync(id);
            return new GeneralResponce("Success");
        }

        public async Task<LikesReview> GetLikeAsync(int idLike)
        {
            var result = await _likesReviewRepository.GetLikesReviewByIdAsync(idLike);
            if (result is null) throw new Exception("Don't found");
            return result;
        }

        public async Task<BookReview> GetReviewAsync(int id)
        {
            var findReview = await _bookReviewRepository.FindByIdAsync(id);
            if (findReview is null) throw new Exception("Don't found");

            return findReview;
        }

        public async Task<GeneralResponce> UpdateLikeAsync(UpdateLikeReviewDTO updateLike)
        {
            if (updateLike is null) throw new NullReferenceException("Model is empty");

            await _likesReviewRepository.UpdateLikeReviewAsync(updateLike);
            return new GeneralResponce("Success");
        }

        public async Task<GeneralResponce> UpdateReviewAsync(UpdateReviewDTO updateReview)
        {
            if (updateReview is null) throw new NullReferenceException("Model is empty");

            await _bookReviewRepository.UpdateReviewAsync(updateReview);
            return new GeneralResponce("Success");
        }
    }
}
