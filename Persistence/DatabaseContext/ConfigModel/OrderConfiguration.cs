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
    public class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.ToTable("Orders");
            builder.Property(e => e.OrderId)
                   .IsRequired()
                   .UseIdentityColumn(1)
                   .HasColumnName("order_id");
            builder.Property(e => e.Status)
                   .HasColumnName("order_status");
            builder.Property(e => e.OrderDate)
                   .HasColumnName("order_date");
            builder.Property(e => e.CustomerId)
                   .HasColumnName("customer_id");
            builder.Property(e => e.AddScore)
                   .HasColumnName("add_score");
            builder.Property(e => e.UseScore)
                    .HasColumnName("use_score");
            builder.Property(e => e.StoreId)
                   .HasColumnName("store_id");
            builder.Property(e => e.IsFeedback)
                   .HasColumnName("is_feedback")
                   .HasDefaultValue(false);
            builder.Property(e => e.TotalPrice)
                   .HasColumnName("total_price");
            builder.HasOne(e => e.Store)
                   .WithMany(e => e.Orders)
                   .HasForeignKey(e => e.StoreId);           
        }
    }
}
