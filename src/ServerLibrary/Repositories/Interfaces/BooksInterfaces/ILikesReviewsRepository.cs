using HelpLibrary.DTOs.Books;
using HelpLibrary.Entities;

namespace ServerLibrary.Repositories.Interfaces.BooksInterfaces
{
    public interface ILikesReviewsRepository
    {
        Task<LikesReview> AddToDatabaseAsync(LikesReview likesReview);

        Task<LikesReview> GetLikesReviewByIdAsync(int id);

        Task<LikesReview> UpdateLikeReviewAsync(UpdateLikeReviewDTO update);

        Task DeleteLikeReviewAsync(LikesReview delete);

        Task<LikesReview> GetLikeByAuthorIdAndReviewIdAsync(int idAuthor, int idReview);
    }
}
