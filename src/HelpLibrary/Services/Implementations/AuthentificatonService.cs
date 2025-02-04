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
using ServerLibrary.Helpers.Exceptions;
using ServerLibrary.Helpers.Exceptions.User;
using System.Net.Mail;
using System.Net;
using HelpLibrary.DTOs.Mail;

namespace ServerLibrary.Services.Implementations
{
    public class AuthentificatonService : IAuthentificatonService
    {
        private readonly IUserRepository _userRepository;
        private readonly ILogRepository _logRepository;
        private readonly IRefreshRepository _refreshRepository;
        private readonly IMailRepository _mailRepository;
        private readonly IOptions<JwtSection> _config;

        public AuthentificatonService(
            IUserRepository userRepository, 
            ILogRepository logRepository,
            IOptions<JwtSection> config,
            IRefreshRepository refreshRepository,
            IMailRepository mailRepository)
        {
            _userRepository = userRepository;
            _logRepository = logRepository;
            _config = config;
            _refreshRepository = refreshRepository;
            _mailRepository = mailRepository;
        }

        public async Task<GeneralResponce> RegisterUserAsync(Registration user)
        {
            if (user == null) throw new NullReferenceException("Model is empty");

            var checkUser = await _userRepository.FindByEmailAsync(user.Email!.ToLower());
            if (checkUser != null) throw new EmailIsBusyException("The user is already registered");

            checkUser = await _userRepository.FindByNicknameAsync(user.Nickname!.ToLower());
            if (checkUser != null) throw new NicknameIsBusyException("The user is already registered");

            var code = await _mailRepository.VerifyCodeAsync(new ConfirmCode { Code = user.Code, Email = user.Email });
            if (code == null) throw new InvalidCodeException("The code has is incorrect");
            if (code.ExpiresIn < DateTime.UtcNow)
            {
                await _mailRepository.DeleteCodeAsync(code);
                throw new InvalidCodeException("The code has expired");
            }

            await _mailRepository.DeleteCodeAsync(code);

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

            return new GeneralResponce("You have successfully registered"); 
        }

        public async Task<LoginResponce> SignInAsync(Login user)
        {
            if (user is null) throw new NullReferenceException("Model is empty");

            var checkUser = await _userRepository.FindByEmailAsync(user.EmailOrNickname!.ToLower());
            if (checkUser is null)
            {
                checkUser = await _userRepository.FindByNicknameAsync(user.EmailOrNickname!.ToLower());
                if (checkUser is null) throw new NotFoundUserException("There is no account with this email or nickname.");
            }

            var hashPassword = new PasswordHasher<object>().HashPassword(null!, user.Password!);

            var checkPass = new PasswordHasher<object>().VerifyHashedPassword(null!, checkUser.PasswordHash, user.Password!);
            if (checkPass != PasswordVerificationResult.Success) throw new InvalidPasswordException("Invalid password");

            string token = await GenerateTokenAsync(checkUser, user.Device!.ToLower());
            string refreshToken = GenerateRefreshToken();

            var checkSession = await _refreshRepository.FindSessionByUserIdAsync(checkUser.Id!, user.Device!);

            await _logRepository.WriteLogsAsync(new Logs { IdUser = checkUser.Id, Action = Constants.Login});

            if (checkSession is not null)
            {
                await _refreshRepository.UpdateRefreshAsync(checkSession, refreshToken);
                return new LoginResponce("Success!", token, refreshToken);
            }
            else
            {
                var session = await _refreshRepository.AddSessionToDatabaseAsync(
                    new UserSession()
                    {
                        IdUser = checkUser.Id,
                        RefreshTokenHash = refreshToken,
                        DeviceType = user.Device!,
                        ExpiresIn = DateTime.UtcNow.AddDays(150),
                        CreatedAt = DateTime.UtcNow,
                    }
                );

                return new LoginResponce("Success!", token, refreshToken);
            }
        }

        private async Task<string> GenerateTokenAsync(User user, string device)
        {
            Console.WriteLine(_config.Value.SecretKey);

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
                        Encoding.UTF8.GetBytes(_config.Value.SecretKey!)),
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
            if (refreshToken is null) throw new NullReferenceException("Model is empty");

            var findToken = await _refreshRepository.FindRefreshAsync(refreshToken);
            if (findToken is null) throw new NotFoundException("Not found");

            var user = await _userRepository.FindByIdAsync(findToken.IdUser);
            if (user is null) throw new NotFoundUserException("User not found");

            string jwtToken = await GenerateTokenAsync(user, findToken.DeviceType);

            await _logRepository.WriteLogsAsync(new Logs { IdUser = user.Id, Action = Constants.Refresh });

            // Expire
            if (findToken.ExpiresIn < DateTime.UtcNow)
            {
                string newRefreshToken = GenerateRefreshToken();
                await _refreshRepository.UpdateRefreshAsync(findToken, newRefreshToken);
                return new LoginResponce("Token refreshed successfully", jwtToken, newRefreshToken);
            }

            return new LoginResponce("Token refreshed successfully", jwtToken);
        }

        public async Task<GeneralResponce> LogOut(string refreshToken)
        {
            if (refreshToken is null) throw new NullReferenceException("Model is empty");

            await _refreshRepository.DeleteSession(refreshToken);

            return new GeneralResponce("Success");
        }

        public async Task SendRegisterEmailCodeAsync(string email)
        {
            var user = await _userRepository.FindByEmailAsync(email);
            if (user is not null) throw new Exception("User already register");

            var model = await _mailRepository.FindByEmailAsync(email);
            if (model is not null) await _mailRepository.DeleteCodeAsync(model);

            string code = GenerateCode();
            await _mailRepository.WriteCodeAsync(new ConfirmCode
            {
                Email = email,
                Code = code,
            });

            string smtpServer = "smtp.mail.ru";
            int smtpPort = 587;
            string smtpUsername = "readify@mail.ru";
            string smtpPassword = Secrets.PassMail;

            try
            {
                MailMessage message = new MailMessage();
                message.IsBodyHtml = true;
                message.From = new MailAddress(smtpUsername, "Readify");
                message.To.Add(email);
                message.Subject = "Подтвердите адрес электронной почты";

                message.Body = Constants.HtmlTemplate!.Replace("{email}", email).Replace("{code}", code);

                using (SmtpClient smtpClient = new SmtpClient(smtpServer, smtpPort))
                {
                    smtpClient.Credentials = new NetworkCredential(smtpUsername, smtpPassword);
                    smtpClient.EnableSsl = true;

                    smtpClient.Send(message);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private string GenerateCode()
        {
            Random random = new Random();
            int number = random.Next(1, 999999);
            return number.ToString("D6");
        }
    }
}
