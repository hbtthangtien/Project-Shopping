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
    public class BrandConfiguration : IEntityTypeConfiguration<Brand>
    {
        public void Configure(EntityTypeBuilder<Brand> builder)
        {
            builder.ToTable("Brands");
            builder.Property(x => x.BrandId)
                   .HasColumnName("brand_id")
                   .UseIdentityColumn(1);                                      
            builder.Property(x => x.BrandName)
                   .HasColumnName("brand_name")
                   .HasMaxLength(100);
            builder.Property(x => x.BrandName)
                   .HasColumnName("brand_image")
                   .HasMaxLength(256);
            builder.HasMany<Product>()
                   .WithOne(e => e.Brand)
                   .HasForeignKey(e => e.BrandId);
        }
    }
}
