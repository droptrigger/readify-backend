using System.ComponentModel.DataAnnotations;

namespace HelpLibrary.DTOs.Users
{
    public class Login
    {
        [MinLength(5, ErrorMessage = "Минимальное количество символов: 5")]
        [MaxLength(150, ErrorMessage = "Максимальное количество символов: 150")]
        [Required]
        public string? EmailOrNickname { get; set; }

        [DataType(DataType.Password)]
        [Required]
        public string? Password { get; set; }
    }
}
