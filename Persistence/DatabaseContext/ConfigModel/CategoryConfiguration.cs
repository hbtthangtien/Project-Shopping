using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.DatabaseContext.ConfigModel
{
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.ToTable("Categories");
            builder.Property(e => e.CategoryId)
                   .UseIdentityColumn(1)
                   .HasColumnName("category_id");
            builder.Property(e => e.CategoryName)
                   .HasMaxLength(100)
                   .HasColumnName("category_name");
            builder.HasMany(e => e.SubCategories)
                   .WithOne(e => e.Category)
                   .HasForeignKey(e => e.CategoryId)
                   .HasConstraintName("FK_Category_SubCategory")
                   .OnDelete(DeleteBehavior.SetNull);
            builder.HasMany(e => e.Products)
                   .WithOne();
        }
    }
}
