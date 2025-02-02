using HelpLibrary.DTOs.Users;
using HelpLibrary.Responces;

namespace ServerLibrary.Services.Interfaces
{
    public interface IUserService
    {
        Task<GeneralResponce> RegisterUserAsync(Registration user);
        Task<GeneralResponce> SignInAsync(Login user);
    }
}
