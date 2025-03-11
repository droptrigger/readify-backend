using System.ComponentModel.DataAnnotations;

namespace HelpLibrary.DTOs.Users
{
    public class RefreshDTO
    {
        public string? refreshToken { get; set; } = null!;

        [Required]
        public string? Device { get; set; }
    }
}
