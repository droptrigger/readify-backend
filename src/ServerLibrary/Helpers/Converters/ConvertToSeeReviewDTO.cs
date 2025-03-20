using HelpLibrary.DTOs.Reviews;
using HelpLibrary.Entities;

namespace ServerLibrary.Helpers.Converters
{
    public static class ConvertToSeeReviewDTO
    {

        public async static Task<SeeReviewDTO> Convert(BookReview review)
        {
            if (review == null)
                return null!;

            return new SeeReviewDTO
            {
                Id = review.Id,
                IdBook = review.IdBook,
                Comment = review.Comment,
                Rating = review.Rating,
                CreatedAt = review.CreatedAt,
                Author = await ConvertToAuthorDTO.Convert(review.IdAuthorNavigation),
                Likes = review.LikesReviews?.Select(ConvertToLikeDTO.Convert).ToList()
            };
        }
    }
}
