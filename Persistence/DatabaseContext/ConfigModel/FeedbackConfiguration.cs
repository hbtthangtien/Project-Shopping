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
    public class FeedbackConfiguration : IEntityTypeConfiguration<Feedback>
    {
        public void Configure(EntityTypeBuilder<Feedback> builder)
        {
            builder.Property(e => e.FeedbackId)
                   .IsRequired()
                   .HasColumnName("feedback_id")
                   .UseIdentityColumn(1);
            builder.Property(e => e.FeedbackDescribe)
                   .HasColumnName("feedback_describe")
                   .IsUnicode(true);
            builder.Property(e => e.IsFeedback)
                   .HasColumnName("is_feedback");
            builder.Property(e => e.FeedbackDate)
                   .HasColumnName("feedback_date")
                   .HasDefaultValue(DateTime.Now);
            builder.Property(e => e.ProductId)
                   .HasColumnName("product_id");
            builder.Property(e => e.AccountId)
                   .HasColumnName("account_id");
            builder.HasOne(e => e.Product)
                   .WithMany(e => e.Feedbacks)
                   .HasForeignKey(e => e.ProductId);
            builder.HasOne(e => e.Account)
                   .WithMany()
                   .HasForeignKey(e => e.AccountId);
            builder.HasMany(e => e.ImageFeedbacks)
                   .WithOne(e => e.Feedback)
                   .HasForeignKey(e => e.FeedbackId);

        }
    }
}
