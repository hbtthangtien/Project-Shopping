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
            builder.Property(e => e.AccountId)
                   .HasColumnName("account_id");
            builder.HasOne(e => e.Account)
                   .WithMany(e => e.CartItems)
                   .HasForeignKey(e => e.AccountId);
            builder.HasOne(e => e.ProductColorType)
                   .WithMany()
                   .HasForeignKey(e => e.ProductColorTypeId);
        }
    }
}
