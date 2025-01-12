using Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Persistence.DatabaseContext.ConfigModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.DatabaseContext
{
    public class TikilazapeeDbContext : IdentityDbContext<Account>
    {
        private readonly IConfiguration _configuration;
        public TikilazapeeDbContext(DbContextOptions<TikilazapeeDbContext> options,
            IConfiguration configuration) : base(options) 
        {
            _configuration = configuration;
        }
        
        public virtual DbSet<Category> Categories { get; set; }

        public virtual DbSet<SubCategory> SubCategories { get; set; }

        public virtual DbSet<Product> Products { get; set; }

        //public virtual DbSet<Account> Accounts { get; set; }

        public virtual DbSet<Brand> Brands { get; set; }

        //public virtual DbSet<CategoryType> CategoryTypes { get; set; }

        public virtual DbSet<Color> Colors { get; set; }

        //public virtual DbSet<Feedback>  Feedbacks { get; set; }

        //public virtual DbSet<ImageFeedback> ImageFeedbacks { get; set; }

        //public virtual DbSet<Order> Orders { get; set; }

        public virtual DbSet<ProductColorType> ProductColorTypes { get; set; }

        public virtual DbSet<ProductImages> ProductImages { get; set; }

        //public virtual DbSet<SearchHistory> SearchHistories { get; set; }

        public virtual DbSet<Domain.Entities.Type> Types { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            optionsBuilder.UseSqlServer(_configuration["ConnectionStrings:MyDatabase"]);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.HasDefaultSchema("dbo");
            modelBuilder.Entity<IdentityRole>().ToTable("Roles");
            modelBuilder.Entity<IdentityUserClaim<string>>().ToTable("UserClaims");
            modelBuilder.Entity<IdentityUserLogin<string>>().ToTable("UserLogin");
            modelBuilder.Entity<IdentityRoleClaim<string>>().ToTable("RoleClaims");
            modelBuilder.Entity<IdentityUserToken<string>>().ToTable("UserTokens");
            modelBuilder.Entity<IdentityUserRole<string>>().ToTable("UserRole");
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
