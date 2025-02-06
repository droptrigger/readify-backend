using System.ComponentModel.DataAnnotations;

namespace HelpLibrary.DTOs.Library
{
    public class LibraryDTO
    {
        [Required]
        public int idUser { get; set; }

        [Required]
        public int idBook { get; set; }
    }
}
