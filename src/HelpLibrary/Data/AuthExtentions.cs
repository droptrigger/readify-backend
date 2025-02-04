using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using ServerLibrary.Helpers;
using System.Text;

namespace ServerLibrary.Data
{
    public static class AuthExtentions
    {
        public static IServiceCollection AddAuth(this IServiceCollection serviceCollections,
            IConfiguration configuration)
        {
            var config = configuration.GetSection("JwtSection")
                .Get<JwtSection>();

            serviceCollections.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(o =>
                {
                    o.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = false,
                        ValidateAudience = false,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config!.SecretKey!))
                    };
            });

            return serviceCollections;
        }
    }
}
