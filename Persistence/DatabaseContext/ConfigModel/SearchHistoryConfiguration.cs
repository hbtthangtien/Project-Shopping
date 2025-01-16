using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.DatabaseContext.ConfigModel
{
    public class SearchHistoryConfiguration : IEntityTypeConfiguration<SearchHistory>
    {
        public void Configure(EntityTypeBuilder<SearchHistory> builder)
        {
            builder.Property(e => e.SearchHistoryId)
                   .IsRequired()
                   .HasColumnName("search_history_id")
                   .UseIdentityColumn(1);
            builder.Property(e => e.SearchKey)
                   .HasColumnName("search_key");
            builder.Property(e => e.CustomerId)
                   .HasColumnName("customer_id");
            builder.Property(e => e.SearchLog)
                   .HasColumnName("search_log");
            builder.HasOne(e => e.Customer)
                   .WithMany(e => e.SearchHistories)
                   .HasForeignKey(e => e.CustomerId);
        }
    }
}
