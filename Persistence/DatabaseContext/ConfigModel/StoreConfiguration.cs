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
    public class StoreConfiguration : IEntityTypeConfiguration<Store>
    {
        public void Configure(EntityTypeBuilder<Store> builder)
        {
            builder.Property(e => e.StoreId)
                   .IsRequired()
                   .HasColumnName("store_id")
                   .UseIdentityColumn(1);
            builder.Property(e => e.AccountId)
                   .HasColumnName("account_id");
            builder.Property(e => e.StoreName)
                   .HasColumnName("store_name");
            builder.Property(e => e.StoreAddress)
                   .HasColumnName("store_address");
            builder.Property(e => e.StoreImage)
                   .HasColumnName("store_image");
            builder.Property(e => e.StorePhone)
                   .HasColumnName("store_phone");
            builder.HasOne(e => e.Account)
                   .WithOne(e => e.Store)
                   .HasForeignKey<Store>(e => e.AccountId);
            builder.HasMany(e => e.Orders)
                   .WithOne(e => e.Store)
                   .HasForeignKey(e => e.StoreId);
                   
        }
    }
}
