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
    public class CartItemConfiguration : IEntityTypeConfiguration<CartItem>
    {
        public void Configure(EntityTypeBuilder<CartItem> builder)
        {
            builder.Property(e => e.CartItemId)
                   .IsRequired()
                   .UseIdentityColumn(1)
                   .HasColumnName("cart_item_id");
            builder.Property(e => e.ProductColorTypeId)
                   .HasColumnName("product_color_type_id");
            builder.Property(e => e.Quantity)
                   .HasColumnName("quantity");
            builder.Property(e => e.CustomerId)
                   .HasColumnName("customer_id");
            builder.Property(e => e.ProductId)
                   .HasColumnName("product_id");
            builder.Property(e => e.ColorId)
                   .HasColumnName("color_id");
            builder.Property(e => e.TypeId)
                   .HasColumnName("type_id");
            builder.HasOne(e => e.Customer)
                   .WithMany(e => e.CartItems)
                   .HasForeignKey(e => e.CustomerId);
            builder.HasOne(e => e.Product)
                   .WithMany()
                   .HasForeignKey(e => e.ProductId);
            builder.HasOne(e => e.Type)
                   .WithMany()
                   .HasForeignKey(e => e.TypeId)
                   .OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(e => e.Color)
                   .WithMany()
                   .HasForeignKey(e => e.ColorId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
