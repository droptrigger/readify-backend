using HelpLibrary.DTOs.Users;
using HelpLibrary.Responces;

namespace ServerLibrary.Services.Interfaces
{
    public interface IAuthentificatonService
    {
        Task<GeneralResponce> RegisterUserAsync(Registration user);
        Task<LoginResponce> SignInAsync(Login user);
        Task<LoginResponce> RefreshToken(string refreshToken);
    }
}
