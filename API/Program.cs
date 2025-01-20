using Application;
using Microsoft.EntityFrameworkCore;
using Persistence;
using Persistence.DatabaseContext;
using API.Middlewares;
using Domain.Configs;
namespace API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSignalR();
            builder.Services.AddSwaggerGen();
            builder.Services.AddApplication();
            builder.Services.AddPersistence();
            builder.Services.AddSercurity();            
            var JwtConfig = builder.Configuration.GetSection("JwtConfig");
            builder.Services.Configure<JwtConfigs>(JwtConfig);
            builder.Services.Configure<EmailConfig>(builder.Configuration.GetSection("EmailConfig"));
            builder.Services.AddDbContext<TikilazapeeDbContext>(options =>
            {
                options.UseSqlServer(builder.Configuration["ConnectionStrings:MyDatabase"]);
            });
            builder.Services.AddAuthenticateJwt(JwtConfig.Get<JwtConfigs>()!);
            var app = builder.Build();
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            app.UseMiddleware<ExceptionMiddleware>();
            app.UseHttpsRedirection();
            app.UseAuthorization();
            app.MapControllers();            
            app.Run();
        }
    }
}
