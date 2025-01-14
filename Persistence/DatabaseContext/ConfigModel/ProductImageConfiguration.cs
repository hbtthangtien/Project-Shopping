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
    public class ProductImageConfiguration : IEntityTypeConfiguration<ProductImages>
    {
        public void Configure(EntityTypeBuilder<ProductImages> builder)
        {
            builder.Property(e => e.Id)
                   .IsRequired()
                   .UseIdentityColumn(1);

            builder.Property(e => e.ProductId)
                   .HasColumnName("product_id");
            builder.Property(e => e.UrlImage)
                   .HasColumnName("url_image");
            builder.HasOne(e => e.Product)
                   .WithMany(e => e.ProductImages)
                   .HasForeignKey(e => e.ProductId);


        }
    }
}
