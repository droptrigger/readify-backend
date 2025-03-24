using System.ComponentModel.DataAnnotations;

namespace HelpLibrary.DTOs.Users
{
    public class RefreshDTO
    {
        public string? Token { get; set; }

        public string? DeviceType { get; set; }
    }
}
