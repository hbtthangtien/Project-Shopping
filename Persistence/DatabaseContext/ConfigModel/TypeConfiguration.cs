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
        }
    }
}
