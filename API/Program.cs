using Application;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Persistence;
using Persistence.DatabaseContext;
using Microsoft.Extensions.DependencyInjection;
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
            builder.Services.AddIdentity<Account, IdentityRole>()
                    .AddEntityFrameworkStores<TikilazapeeDbContext>()
                    .AddDefaultTokenProviders();
                            
            builder.Services.AddDbContext<TikilazapeeDbContext>(options =>
            {
                options.UseSqlServer(builder.Configuration["ConnectionStrings:MyDatabase"]);
            });
            var app = builder.Build();
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            app.UseHttpsRedirection();
            app.UseAuthorization();
            app.MapControllers();
            
            app.Run();
        }
    }
}
