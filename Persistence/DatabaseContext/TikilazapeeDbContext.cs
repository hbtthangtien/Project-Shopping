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

        public virtual DbSet<Brand> Brands { get; set; }

        public virtual DbSet<CategoryType> CategoryTypes { get; set; }

        public virtual DbSet<Color> Colors { get; set; }

        public virtual DbSet<Feedback>  Feedbacks { get; set; }

        public virtual DbSet<ImageFeedback> ImageFeedbacks { get; set; }

        public virtual DbSet<Order> Orders { get; set; }

        public virtual DbSet<ProductColorType> ProductColorTypes { get; set; }

        public virtual DbSet<ProductImages> ProductImages { get; set; }

        public virtual DbSet<SearchHistory> SearchHistories { get; set; }

        public virtual DbSet<Profile> Profile { get; set; }

        public virtual DbSet<Domain.Entities.Type> Types { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            optionsBuilder.UseSqlServer(_configuration["ConnectionStrings:MyDatabase"]);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.HasDefaultSchema("dbo");
            // custom table Identity Role
            modelBuilder.Entity<IdentityRole>(entity =>
            {
                entity.ToTable("Roles");
                entity.HasKey(e => e.Id)
                      .HasName("id");
                entity.Property(e => e.Name)
                      .HasColumnName("role_name");
                entity.Property(e => e.NormalizedName)
                      .HasColumnName("normalized_name");
                entity.Property(e => e.ConcurrencyStamp)
                      .HasColumnName("concurrency_stamp");
            });

            modelBuilder.Entity<IdentityUserClaim<string>>(entity =>
            {
                entity.ToTable("UserClaims");
                entity.HasKey(e => e.Id);
                entity.Property(e => e.UserId)
                      .HasColumnName("user_id");
                entity.Property(e => e.ClaimType)
                      .HasColumnName("claim_type");
                entity.Property(e => e.ClaimValue)
                      .HasColumnName("claim_value");
            });

            modelBuilder.Entity<IdentityUserLogin<string>>(entity =>
            {
                entity.ToTable("UserLogin");
                entity.HasKey(e => new { e.ProviderKey, e.LoginProvider });
                entity.Property(e => e.ProviderKey)
                      .HasColumnName("provider_key");
                entity.Property(e => e.LoginProvider)
                      .HasColumnName("login_provider");
                entity.Property(e => e.UserId)
                      .HasColumnName("user_id");
                entity.Property(e => e.ProviderDisplayName)
                      .HasColumnName("provider_display_name");
            }); 

            modelBuilder.Entity<IdentityUserToken<string>>(entity => 
            {
                entity.ToTable("UserTokens");
                entity.HasKey(e => new { e.UserId, e.LoginProvider, e.Name });
                entity.Property(e => e.UserId)
                      .HasColumnName("user_id");
                entity.Property(e => e.Name)
                      .HasColumnName("name");
                entity.Property(e => e.LoginProvider)
                      .HasColumnName("login_provider");
                entity.Property(e => e.Value)
                      .HasColumnName("value");
            });

            modelBuilder.Entity<IdentityRoleClaim<string>>(entity => 
            {
                entity.ToTable("RoleClaims");
                entity.HasKey(e => e.Id);
                entity.Property(e => e.RoleId)
                      .HasColumnName("role_id");
                entity.Property(e => e.ClaimType)
                      .HasColumnName("claim_type");
                entity.Property(e => e.ClaimValue)
                      .HasColumnName("claim_value");
            });

            modelBuilder.Entity<IdentityUserRole<string>>(entity => 
            { 
                entity.ToTable("UserRole");
                entity.HasKey(e => new { e.RoleId, e.UserId });
                entity.Property(e => e.RoleId)
                      .HasColumnName("role_is");
                entity.Property(e => e.UserId)
                      .HasColumnName("user_id");
            }); 
            
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
