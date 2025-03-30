using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace HelpLibrary.DTOs.Users
{
    public class UpdateUserDTO
    {
        [Key]
        [Required]
        public int UserId {  get; set; }

        [MinLength(5, ErrorMessage = "Минимальное количество символов: 5")]
        [MaxLength(50, ErrorMessage = "Максимальное количество символов: 50")]
        public string? Nickname { get; set; } = null!;

        [MaxLength(250)]
        public string? Description { get; set; } = null!;


        [MaxFileSize(5 * 1024 * 1024, ErrorMessage = "Максимальный размер файла: 5 МБ")]
        public IFormFile? AvatarImage { get; set; } = null!;

        [MinLength(2, ErrorMessage = "Минимальное количество символов: 2")]
        [MaxLength(100, ErrorMessage = "Максимальное количество символов: 100")]
        public string? Name { get; set; } = null!;
    }
}
