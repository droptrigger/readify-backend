using HelpLibrary.DTOs.Books;
using HelpLibrary.Entities;
using HelpLibrary.Responces;

namespace ServerLibrary.Services.Interfaces
{
    public interface IReviewService
    {
        Task<GeneralResponce> AddReviewAsync(AddReviewDTO addReview);
        Task<BookReview> GetReviewAsync(int id);
        Task<GeneralResponce> UpdateReviewAsync(UpdateReviewDTO updateReview);
        Task<GeneralResponce> DeleteReviewAsync(int id);

        Task<GeneralResponce> AddLikeAsync(AddLikeReviewDTO addLike);
        Task<LikesReview> GetLikeAsync(int idLike);
        Task<GeneralResponce> UpdateLikeAsync(UpdateLikeReviewDTO updateLike);
        Task<GeneralResponce> DeleteLikeAsync(int idLike);
    }
}
