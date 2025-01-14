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
    public class CategoryTypeConfiguration : IEntityTypeConfiguration<CategoryType>
    {
        public void Configure(EntityTypeBuilder<CategoryType> builder)
        {
            builder.Property(e => e.CategoryTypeID)
                   .IsRequired()
                   .HasColumnName("category_type_id")
                   .UseIdentityColumn(1);
            builder.Property(e => e.CategoryTypeName)
                   .HasColumnName("category_type_name");
            builder.HasMany(e => e.Types)
                   .WithOne(e => e.CategoryType)
                   .HasForeignKey(e => e.CategoryTypeId);





        }
    }
}
