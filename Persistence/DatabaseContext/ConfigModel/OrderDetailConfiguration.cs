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
    public class OrderDetailConfiguration : IEntityTypeConfiguration<OrderDetail>
    {
        public void Configure(EntityTypeBuilder<OrderDetail> builder)
        {
            builder.ToTable("OrderDetails");
            builder.Property(e => e.Id)
                   .IsRequired()
                   .HasColumnName("id")
                   .UseIdentityColumn(1);
            builder.Property(e => e.Quantity)
                   .HasColumnName("quantity");
            builder.Property(e => e.StoreId)
                   .HasColumnName("store_id");
            builder.Property(e => e.ColorId)
                   .HasColumnName("color_id");
            builder.Property(e => e.TypeId)
                   .HasColumnName("type_id");
            builder.Property(e => e.ProductId)
                   .HasColumnName("product_id");
            builder.HasOne(e => e.Store)
                   .WithMany()
                   .HasForeignKey(e => e.StoreId);
            builder.HasOne(e => e.Product)
                   .WithMany()
                   .HasForeignKey(e => e.ProductId);
            builder.HasOne(e => e.Type)
                   .WithMany()
                   .HasForeignKey(e => e.TypeId);
            builder.HasOne(e => e.Color)
                   .WithMany()
                   .HasForeignKey(e => e.ColorId);



        }
    }
}
