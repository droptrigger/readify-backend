using HelpLibrary.DTOs.Users;
using HelpLibrary.DTOs;
using HelpLibrary.Entities;
using HelpLibrary.Responces;
using Microsoft.AspNetCore.Identity;
using ServerLibrary.Services.Interfaces;
using ServerLibrary.Repositories.Interfaces;
using System.Security.Cryptography;
using System.Security.Claims;
using Microsoft.Extensions.Options;
using ServerLibrary.Helpers;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.IdentityModel.Tokens.Jwt;

namespace ServerLibrary.Services.Implementations
{
    public class AuthentificatonService : IAuthentificatonService
    {
        private readonly IUserRepository _userRepository;
        private readonly ILogRepository _logRepository;
        private readonly IOptions<JwtSection> _config;

        public AuthentificatonService(IUserRepository userRepository, ILogRepository logRepository, IOptions<JwtSection> config)
        {
            _userRepository = userRepository;
            _logRepository = logRepository;
            _config = config;
        }

        public async Task<GeneralResponce> RegisterUserAsync(Registration user)
        {
            if (user == null) return new GeneralResponce(false, "Model is empty");

            var checkUser = await _userRepository.FindByEmailAsync(user.Email!.ToLower());
            if (checkUser != null) return new GeneralResponce(false, "The user is already registered");

            checkUser = await _userRepository.FindByNicknameAsync(user.Nickname!.ToLower());
            if (checkUser != null) return new GeneralResponce(false, "The user is already registered");

            var hashPassword = new PasswordHasher<object>().HashPassword(null!, user.Password!);

            User addUser = await _userRepository.AddToDatabaseAsync(new User()
            {
                Nickname = user.Nickname!.ToLower(),
                Name = user.Name.ToLower(),
                Email = user.Email!.ToLower(),
                PasswordHash = hashPassword,
                CreatedAt = DateTime.UtcNow,
            });

            await _logRepository.WriteLogsAsync(new Logs { IdUser = addUser.Id, Action = Constants.Register });

            return new GeneralResponce(true, "You have successfully registered"); 
        }

        public async Task<LoginResponce> SignInAsync(Login user)
        {
            if (user is null) return new LoginResponce(false, "Model is empty");

            var checkUser = await _userRepository.FindByEmailAsync(user.EmailOrNickname!.ToLower());
            if (checkUser is null)
            {
                checkUser = await _userRepository.FindByNicknameAsync(user.EmailOrNickname!.ToLower());
                if (checkUser is null) return new LoginResponce(false, "There is no account with this email or nickname.");
            }

            var hashPassword = new PasswordHasher<object>().HashPassword(null!, user.Password!);

            var checkPass = new PasswordHasher<object>().VerifyHashedPassword(null!, checkUser.PasswordHash, user.Password!);
            if (checkPass != PasswordVerificationResult.Success) return new LoginResponce(false, "Invalid password");

            string token = await GenerateTokenAsync(checkUser, user.Device!.ToLower());
            string refreshToken = GenerateRefreshToken();

            var checkSession = await _userRepository.FindSessionByUserIdAsync(checkUser.Id!, user.Device!);

            await _logRepository.WriteLogsAsync(new Logs { IdUser = checkUser.Id, Action = Constants.Login});

            if (checkSession is not null)
            {
                Console.WriteLine("test");

                await _userRepository.UpdateRefreshAsync(checkSession, refreshToken);
                return new LoginResponce(true, "Success!", token, refreshToken);
            }
            else
            {
                Console.WriteLine("test2");

                var session = await _userRepository.AddSessionToDatabaseAsync(
                    new UserSession()
                    {
                        IdUser = checkUser.Id,
                        RefreshTokenHash = refreshToken,
                        DeviceType = user.Device!,
                        ExpiresIn = DateTime.UtcNow.AddDays(15),
                        CreatedAt = DateTime.UtcNow,
                    }
                );

                return new LoginResponce(true, "Success!", token, refreshToken);
            }
            
        }

        private async Task<string> GenerateTokenAsync(User user, string device)
        {
            var claims = new List<Claim>() 
            {
                new Claim("id", user.Id.ToString()),
                new Claim("nickname", user.Nickname),
                new Claim("email", user.Email),
                new Claim("role", Constants.Roles[user.IdRole]),
                new Claim("device", device)
            };

            var jwtToken = new JwtSecurityToken(
                expires: DateTime.UtcNow.Add(_config.Value.Expires),
                claims: claims,
                signingCredentials: 
                new SigningCredentials(
                    new SymmetricSecurityKey(
                        Encoding.UTF8.GetBytes(_config.Value.Key!)),
                            SecurityAlgorithms.HmacSha256));

            await _logRepository.WriteLogsAsync(new Logs { IdUser = user.Id, Action = Constants.GenerateToken });

            return new JwtSecurityTokenHandler().WriteToken(jwtToken);
        }

        private string GenerateRefreshToken()
        {
            var randomNumber = new byte[32];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(randomNumber);
                
                return Convert.ToBase64String(randomNumber);
            }
        }

        public async Task<LoginResponce> RefreshToken(string refreshToken)
        {
            if (refreshToken is null) return new LoginResponce(false, "Refresh token is required");

            var findToken = await _userRepository.FindRefreshAsync(refreshToken);
            if (findToken is null) return new LoginResponce(false, "Refresh token is required");

            var user = await _userRepository.FindByIdAsync(findToken.IdUser);
            if (user is null) return new LoginResponce(false, "Refresh token could not be generated because user not found");

            string jwtToken = await GenerateTokenAsync(user, findToken.DeviceType);
            string newRefreshToken = GenerateRefreshToken();

            await _userRepository.UpdateRefreshAsync(findToken, newRefreshToken);

            await _logRepository.WriteLogsAsync(new Logs { IdUser = user.Id, Action = Constants.Refresh });
            return new LoginResponce(true, "Token refreshed successfully", jwtToken, refreshToken);
        }
    }
}
