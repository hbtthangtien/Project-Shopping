using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.DatabaseContext.ConfigModel
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("Product");
            builder.Property(e => e.ProductId)
                   .IsRequired()
                   .HasColumnName("product_id")
                   .UseIdentityColumn(1);
            builder.Property(e => e.ProductName)
                   .HasMaxLength(256)
                   .IsUnicode(true)
                   .HasColumnName("product_name");
            builder.Property(e => e.ProductDescribes)
                   .HasColumnType("nvarchar(max)")
                   .IsUnicode (true)
                   .HasColumnName("product_description");
            builder.Property(e => e.SaleLevel)
                   .HasColumnName("sale_level");
            builder.Property(e => e.IsActived)
                   .HasColumnName("is_active")
                   .HasDefaultValue(true);
            builder.HasKey(e => e.ProductId);
            builder.Property(e => e.BrandId)
                   .HasColumnName("brand_id");
            builder.Property(e => e.CategoryId)
                   .HasColumnName("category_id");
            builder.Property(e => e.SubCatecoryId)
                   .HasColumnName("sub_categoty_id");
            builder.HasOne(e => e.Brand)
                   .WithMany()
                   .HasForeignKey(e => e.BrandId)
                   .OnDelete(DeleteBehavior.Cascade); ;
            builder.HasOne(e => e.Category)
                   .WithMany(e => e.Products)
                   .HasForeignKey(e => e.CategoryId);
            builder.HasOne(e => e.SubCategory)
                   .WithMany(e => e.Products)
                   .HasForeignKey(e => e.SubCatecoryId);
            builder.Property(e => e.StoreId)
                   .HasColumnName("store_id");
            builder.HasMany(e => e.ProductColors)
                   .WithMany("Color");
            builder.HasMany(e => e.ProductImages)
                    .WithOne(e => e.Product)
                    .HasForeignKey(e => e.ProductId)
                    .OnDelete(DeleteBehavior.SetNull);
            builder.HasMany(e => e.ProductTypes)
                    .WithMany();
            builder.HasMany(e => e.ColorTypes)
                   .WithOne(e => e.Product)
                   .HasForeignKey(e => e.ProductId);
            builder.HasOne(e => e.Store)
                   .WithMany(e => e.Products)
                   .HasForeignKey(e => e.StoreId);
        }
    }
}
