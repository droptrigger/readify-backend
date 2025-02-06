using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelpLibrary.DTOs.Books
{
    public class AddBookDTO
    {
        [MaxLength(200, ErrorMessage = "Максимальное количество символов: 200")]
        [Required]
        public string Name { get; set; } = null!;

        [MaxLength(250, ErrorMessage = "Максимальное количество символов: 250")]
        public string? Description { get; set; } = null!;

        [Required]
        public int PageQuantity { get; set; }

        [Required]
        public int IdAuthor { get; set; }

        [Required]
        public IFormFile CoverImageFIle { get; set; } = null!;

        [Required]
        public IFormFile FileBook { get; set; } = null!;

        public int? IdGenre { get; set; } = null;

        public bool IsPrivate { get; set; } = false;
    }
}
