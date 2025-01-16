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
    public class ProfileConfiguration : IEntityTypeConfiguration<Profile>
    {
        public void Configure(EntityTypeBuilder<Profile> builder)
        {
            builder.Property(e => e.ProfileId)
                   .HasColumnName("profile_id")
                   .IsRequired()
                   .UseIdentityColumn(1);
            builder.Property(e => e.AccountId)
                   .HasColumnName("account_id");
            builder.Property(e => e.AvatarProfile)
                   .HasColumnName("avatar_profile");
            builder.Property(e => e.IdentityCard)
                   .HasColumnName("identity_card");
            builder.Property(e => e.Address)
                   .HasColumnName("address");
            builder.Property(e => e.DateOfBirth)
                   .HasColumnName("date_of_birth");
            builder.Property(e => e.Gender)
                   .HasColumnName("gender");
            builder.Property(e => e.Fullname)
                   .HasColumnName("fullname");
            builder.Property(e => e.PhoneNumber)
                   .HasColumnName("phone_number");

            builder.HasOne(e => e.Account)
                   .WithOne(e => e.Profile);
                   
        }
    }
}
