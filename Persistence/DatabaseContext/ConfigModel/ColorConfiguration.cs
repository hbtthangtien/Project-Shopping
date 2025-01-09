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
    public class ColorConfiguration : IEntityTypeConfiguration<Color>
    {
        public void Configure(EntityTypeBuilder<Color> builder)
        {
            builder.ToTable("Colors");
            builder.Property(e => e.ColorId)
                   .HasColumnName("color_id")
                   .UseIdentityColumn(1);
            builder.Property(e => e.ColorName)
                   .HasColumnName("color_name")
                   .HasMaxLength(100);

        }
    }
}
