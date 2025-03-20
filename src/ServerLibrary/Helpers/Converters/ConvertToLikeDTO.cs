using HelpLibrary.DTOs.Reviews;
using HelpLibrary.Entities;

namespace ServerLibrary.Helpers.Converters
{
    public static class ConvertToLikeDTO
    {
        public static LikeDTO Convert(LikesReview like)
        {
            if (like == null)
                return  null!;

            return new LikeDTO
            {
                Id = like.Id,
                IdAuthor = like.IdAuthor,
                IdReview = like.IdReview,
                ReactionType = like.ReactionType,
                CreatedAt = like.CreatedAt
            };
        }
    }
}
