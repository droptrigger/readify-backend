using System.ComponentModel.DataAnnotations;

namespace HelpLibrary.DTOs.Books
{
    public class AddLikeReviewDTO
    {
        [Required]
        public int IdAuthor { get; set; }

        [Required]
        public int IdReview { get; set; }

        [Required]
        public byte ReactionType { get; set; }
    }
}
