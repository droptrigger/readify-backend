using System.ComponentModel.DataAnnotations;

namespace HelpLibrary.DTOs.Subscribe
{
    public class SubscribeDTO
    {
        [Required]
        public int AuthorId { get; set; }

        [Required]
        public int SubscriberId { get; set; }
    }
}
