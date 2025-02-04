using System.ComponentModel.DataAnnotations;

namespace HelpLibrary.DTOs.Users
{
    public class SubscribeDTO
    {
        [Required]
        public int AuthorId { get; set; }

        [Required]
        public int SubscriberId { get; set; }
    }
}
