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
    public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.ToTable("Customers");
            builder.HasKey(x => x.CustomerId);  
            builder.Property(e => e.CustomerId)
                   .HasColumnName("customer_id");
            builder.Property(e => e.Score)
                    .HasColumnName("scores");
            builder.HasMany(e => e.Orders)
                   .WithOne(e => e.Customer)
                   .HasForeignKey(e => e.CustomerId);
            builder.HasMany(e => e.SearchHistories)
                   .WithOne(e => e.Customer)
                   .HasForeignKey(e => e.CustomerId);
        }
    }
}
