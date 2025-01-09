using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Persistence.DatabaseContext.ConfigModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.DatabaseContext
{
    public class TikilazapeeDbContext : DbContext
    {
        private readonly IConfiguration _configuration;
        public TikilazapeeDbContext(DbContextOptions options, IConfiguration configuration) : base(options) 
        {
            _configuration = configuration;
        }
        
        public virtual DbSet<Category> Categories { get; set; }

        public virtual DbSet<SubCategory> SubCategories { get; set; }

        public virtual DbSet<Product> Products { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            optionsBuilder.UseSqlServer(_configuration["ConnectionStrings:MyDatabase"]);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.HasDefaultSchema("dbo");
            modelBuilder.ApplyConfiguration(new CategoryConfiguration());
            modelBuilder.ApplyConfiguration(new SubCategoryConfiguration());
        }
    }
}
