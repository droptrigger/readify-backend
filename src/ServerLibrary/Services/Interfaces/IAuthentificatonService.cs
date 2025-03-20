using HelpLibrary.DTOs.Users;
using HelpLibrary.Entities;
using HelpLibrary.Responces;

namespace ServerLibrary.Services.Interfaces
{
    public interface IAuthentificatonService
    {
        /// <summary>
        /// Метод регистрации пользователя
        /// </summary>
        /// <param name="user">Объект передачи данных, содержащий информацию, необходимю для регистрации</param>
        /// <returns>Ответ сервера, содержащий сообщение об удачной регистрации</returns>
        Task<UserDTO> RegisterUserAsync(RegistrationDTO user);

        /// <summary>
        /// Метод для входа в аккаунт
        /// </summary>
        /// <param name="user">Объект передачи данных, содержащий информацию, необходимую для входа</param>
        /// <returns>Ответ сервера, содержащий сообщение об удачном входе, Access и Refresh токен</returns>
        Task<LoginResponce> SignInAsync(LoginDTO user);

        /// <summary>
        /// Метод выхода из аккаунта
        /// </summary>
        /// <param name="refreshToken">Refresh-токен</param>
        /// <returns>Ответ сервера, содержащий сообщение об успешном выходе</returns>
        Task<GeneralResponce> LogOut(string refreshToken);

        /// <summary>
        /// Метод обновления refresh-токена
        /// </summary>
        /// <param name="refreshToken">Новый refresh-токек</param>
        /// <returns>Ответ сервера, содержащий новый Access токен</returns>
        Task<LoginResponce> RefreshToken(string refreshToken);

        /// <summary>
        /// Метод отправки кода подтверждения почты
        /// </summary>
        /// <param name="email">Email получателя</param>
        /// <returns>Ответ сервера</returns>
        Task<GeneralResponce> SendRegisterEmailCodeAsync(string email);

        /// <summary>
        /// Метод получения пользователя
        /// </summary>
        /// <param name="emailOrUsername"></param>
        /// <returns></returns>
        Task<User> GetUserByEmailOrUsernameAsync(string emailOrUsername);

        Task<bool> CheckUsernameAsync(string userneme);

        Task<bool> CheckEmailAsync(string email);
    }
}
