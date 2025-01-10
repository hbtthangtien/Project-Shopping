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
    public class TypeConfiguration : IEntityTypeConfiguration<Domain.Entities.Type>
    {
        public void Configure(EntityTypeBuilder<Domain.Entities.Type> builder)
        {
            builder.ToTable("Type");
            builder.Property(e => e.TypeId)
                   .IsRequired()
                   .HasColumnName("type_id");
            builder.Property(e => e.TypeName)
                   .HasMaxLength(100)
                   .IsUnicode(true)
                   .HasColumnName("type_name");
            builder.HasMany<Product>()
                   .WithMany(e => e.ProductTypes)
                   .UsingEntity<ProductColorType>(
                        j => j.HasOne(e => e.Product).WithMany(e => e.ColorTypes).HasForeignKey(e => e.ProductId)
                    );
        }
    }
}
