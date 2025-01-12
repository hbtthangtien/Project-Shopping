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
    public class SubCategoryConfiguration : IEntityTypeConfiguration<SubCategory>
    {
        public void Configure(EntityTypeBuilder<SubCategory> builder)
        {
            builder.ToTable("Sub_Categories");
            builder.Property(e => e.SubCategoryId)
                   .UseIdentityColumn(1)
                   .HasColumnName("sub_category_id");
            builder.Property(e => e.SubCategoryName)
                   .HasMaxLength(100)
                   .IsUnicode(true)
                   .HasColumnName("sub_category_name");
            builder.Property(e => e.CategoryId)
                   .HasColumnName("category_id");
            builder.HasOne(e => e.Category)
                   .WithMany(e => e.SubCategories)
                   .HasForeignKey(e => e.CategoryId)
                   .HasConstraintName("FK_Category_SubCategory")
                   .OnDelete(DeleteBehavior.SetNull);
            builder.HasMany(e => e.Products)
                   .WithOne(e => e.SubCategory)
                   .HasForeignKey(e => e.SubCatecoryId);
        }
    }
}
