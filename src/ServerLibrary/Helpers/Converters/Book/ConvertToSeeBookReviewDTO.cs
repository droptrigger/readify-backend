using HelpLibrary.DTOs.Books;
using HelpLibrary.DTOs.Reviews;
using HelpLibrary.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerLibrary.Helpers.Converters
{
    public static class ConvertToSeeBookReviewDTO
    {
        public async static Task<SeeReviewBookDTO> Convert(BookReview review)
        {
            if (review == null)
                return null!;

            return new SeeReviewBookDTO
            {
                Id = review.Id,
                IdBook = review.IdBook,
                Comment = review.Comment,
                Rating = review.Rating,
                CreatedAt = review.CreatedAt,
                Author = await ConvertToAuthorDTO.Convert(review.IdAuthorNavigation),
            };
        }
    }
}
