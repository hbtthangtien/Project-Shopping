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
    public class ImageFeedbackConfiguration : IEntityTypeConfiguration<ImageFeedback>
    {
        public void Configure(EntityTypeBuilder<ImageFeedback> builder)
        {
            builder.Property(e => e.ImageFeedbackId)
                   .IsRequired()
                   .HasColumnName("image_feedback_id")
                   .UseIdentityColumn(1);
            builder.Property(e => e.ImageFeedbackUrl)
                   .HasColumnName("image_feedback_url");
            builder.Property(e => e.FeedbackId)
                   .HasColumnName("feedback_id");
            builder.HasOne(e => e.Feedback)
                   .WithMany(e => e.ImageFeedbacks)
                   .HasForeignKey(e => e.FeedbackId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
