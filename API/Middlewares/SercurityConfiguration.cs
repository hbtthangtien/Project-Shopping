using Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Persistence.DatabaseContext;

namespace API.Middlewares
{
    public static class SercurityConfiguration
    {
        public static void AddSercurity(this IServiceCollection services)
        {
            services.AddIdentity<Account, IdentityRole>(options =>
             {
                 // config password
                 options.Password.RequireDigit = true;
                 options.Password.RequireLowercase = true;
                 options.Password.RequireNonAlphanumeric = true;
                 options.Password.RequireUppercase = true;
                 options.Password.RequiredLength = 8;
                 
                 options.User.RequireUniqueEmail = true;

                 options.Lockout.AllowedForNewUsers = true;
                 options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
                 options.Lockout.MaxFailedAccessAttempts = 5;

                 
//                 options.SignIn.RequireConfirmedEmail = true;
             })
                    .AddEntityFrameworkStores<TikilazapeeDbContext>()
                    .AddDefaultTokenProviders();
            services.Configure<DataProtectionTokenProviderOptions>(options =>
            {
                options.TokenLifespan = TimeSpan.FromMinutes(5);
            });
        }
    }
}
