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
    public class ProductTypeColorConfiguration : IEntityTypeConfiguration<ProductColorType>
    {
        public void Configure(EntityTypeBuilder<ProductColorType> builder)
        {
            builder.ToTable("ProductTypeColor");
            builder.Property(e => e.Id)
                   .UseIdentityColumn(1)
                   .HasColumnName("product_type_color_id");
            builder.HasIndex(e => new { e.ProductId, e.ColorId, e.TypeId })
                   .IsUnique(true);
            builder.Property(e => e.ProductId)
                   .HasColumnName("product_id");
            builder.Property(e => e.TypeId)
                    .HasColumnName("type_id");
            builder.Property(e => e.ColorId)
                   .HasColumnName("color_id");
            builder.Property(e => e.Available)
                   .HasColumnName("available");
            builder.Property(e => e.OriginPrice)
                   .HasColumnName("origin_price");
            builder.Property(e => e.IsSale)
                   .HasColumnName("is_sale");
            builder.HasOne(e => e.Product)
                   .WithMany(e => e.ColorTypes)
                   .HasForeignKey(e => e.ProductId);
            builder.HasOne(e => e.Color)
                   .WithMany()
                   .HasForeignKey(e => e.ColorId);
            builder.HasOne(e => e.Type)
                    .WithMany()
                    .HasForeignKey(e => e.TypeId);

        }
    }
}
