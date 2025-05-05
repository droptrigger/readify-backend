using HelpLibrary.DTOs.Reviews;
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
    }
}
