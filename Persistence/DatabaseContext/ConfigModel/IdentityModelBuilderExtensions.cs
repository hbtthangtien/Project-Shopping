using Domain.Constants;
using Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.DatabaseContext.ConfigModel
{
    public static class IdentityModelBuilderExtensions
    {
        public static void SeedIdentityData(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<IdentityRole>().HasData(
                new IdentityRole { Id = "1", Name = UserRole.ADMIN, NormalizedName = UserRole.ADMIN },
                new IdentityRole { Id = "2", Name = UserRole.SELLER, NormalizedName = UserRole.SELLER },
                new IdentityRole { Id = "3", Name = UserRole.MARKETING, NormalizedName = UserRole.MARKETING },
                new IdentityRole { Id = "4", Name = UserRole.CUSTOMER, NormalizedName = UserRole.CUSTOMER }
            );
            var hasher = new PasswordHasher<Account>();
            var adminUser = new Account
            {
                Id = "1", // Unique ID
                UserName = "admin",
                NormalizedUserName = "ADMIN",
                Email = "admin@example.com",
                NormalizedEmail = "ADMIN@EXAMPLE.COM",
                EmailConfirmed = true
            };
            adminUser.PasswordHash = hasher.HashPassword(adminUser, "Admin@123");

            modelBuilder.Entity<Account>().HasData(adminUser);

            // Seed User Roles
            modelBuilder.Entity<IdentityUserRole<string>>().HasData(
                new IdentityUserRole<string> { UserId = "1", RoleId = "1" } // Admin user with Admin role
            );
        }
    }
}
