using System.ComponentModel.DataAnnotations;

namespace HelpLibrary.DTOs.Library
{
    public class UpdateProgressDTO
    {
        [Required]
        public int IdUser {  get; set; }
        [Required]
        public int IdBook {  get; set; }
        [Required]
        public int NewPage { get; set; }
    }
}
