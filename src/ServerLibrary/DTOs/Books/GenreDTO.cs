using System.ComponentModel.DataAnnotations;

namespace HelpLibrary.DTOs.Books
{
    public class GenreDTO
    {
        [Required]
        public int id { get; set; }
        
        [Required]
        public string newName { get; set; } = null!;
    }
}
