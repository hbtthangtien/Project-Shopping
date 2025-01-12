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
    public class AccountConfiguration : IEntityTypeConfiguration<Account>
    {
        public void Configure(EntityTypeBuilder<Account> builder)
        {
            builder.ToTable(nameof(Account));
            builder.Property(e => e.Id)
                   .IsRequired()
                   .HasColumnName("account_id");
            builder.Property(e => e.LatestLogin)
                   .HasColumnName("latest_login");
            builder.Property(e => e.Score)
                   .HasColumnName("scores");
            builder.Property(e => e.UserName)
                   .HasColumnName("username");
            builder.Property(e => e.Email)
                    .HasColumnName("email");
            builder.Property(e => e.NormalizedEmail)
                   .HasColumnName("normalized_email");
            builder.Property(e => e.EmailConfirmed)
                   .HasColumnName("email_confirmed");
            builder.Property(e => e.PasswordHash)
                   .HasColumnName("password_hash");
            builder.Property(e => e.SecurityStamp)
                   .HasColumnName("sercurity_stamp");
            builder.Property(e => e.PhoneNumber)
                   .HasColumnName("phone_number");
            builder.Property(e => e.ConcurrencyStamp)
                   .HasColumnName("concurrency_stamp");
            builder.Property(e => e.PhoneNumberConfirmed)
                   .HasColumnName("phone_number_confirmed");
            builder.Property(e => e.TwoFactorEnabled)
                   .HasColumnName("two_factor_enabled");
            builder.Property(e => e.LockoutEnd)
                   .HasColumnName("lockout_end");
            builder.Property(e => e.LockoutEnabled)
                   .HasColumnName("lockout_enabled");
            builder.Property(e => e.AccessFailedCount)
                   .HasColumnName("access_failed_count")
                   .HasDefaultValue(0);
            builder.HasOne(e => e.Profile)
                   .WithOne(e => e.Account)
                   .HasForeignKey<Profile>(e => e.AccountId);

        }
    }
}
