using HelpLibrary.DTOs.Users;

namespace HelpLibrary.Responces
{
    public record LoginResponce(string Message = null!, string Token = null!, string RefreshToken = null!, UserDTO User = null!);
}
