using Domain.Configs;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace API.Middlewares
{
    public static class AuthenticateConfiguration
    {
        public static void AddAuthenticateJwt(this IServiceCollection services, JwtConfigs jwt)
        {
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultForbidScheme = JwtBearerDefaults.AuthenticationScheme;
            })
                .AddJwtBearer(options =>
                {
                    var key = Encoding.UTF8.GetBytes(jwt.Token);
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = jwt.ValidateIssuer,
                        ValidIssuer = jwt.ValidIssuer,
                        ValidateAudience = jwt.ValidateAudience,
                        ValidAudience = jwt.ValidAudience,
                        ValidateLifetime = jwt.ValidateLifetime,
                        ClockSkew = TimeSpan.Zero,
                        ValidateIssuerSigningKey = jwt.ValidateIssuerSigningKey,
                        IssuerSigningKey = new SymmetricSecurityKey(key)
                    };
                });
        }
    }
}
