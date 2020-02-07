using AllNotes.Domain.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace AllNotes.Domain.EF.AllNotesContextModelConfigurations
{
    public class UserEntityConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {


           //    builder.HasKey(u => u.Id);

           // // Indexes for "normalized" username and email, to allow efficient lookups
           //builder.HasIndex(u => u.NormalizedUserName).HasName("UserNameIndex").IsUnique();
           //builder.HasIndex(u => u.NormalizedEmail).HasName("EmailIndex");

           // // Maps to the AspNetUsers table
           //builder.ToTable("AspNetUsers");

           // // A concurrency token for use with the optimistic concurrency checking
           //builder.Property(u => u.ConcurrencyStamp).IsConcurrencyToken();

           // // Limit the size of columns to use efficient database types
           //builder.Property(u => u.UserName).HasMaxLength(256);
           //builder.Property(u => u.NormalizedUserName).HasMaxLength(256);
           //builder.Property(u => u.Email).HasMaxLength(256);
           //builder.Property(u => u.NormalizedEmail).HasMaxLength(256);

           // // The relationships between User and other entity types
           // // Note that these relationships are configured with no navigation properties

           // // Each User can have many UserClaims
           //builder.HasMany<IdentityUserClaim<string>>().WithOne().HasForeignKey(uc => uc.UserId).IsRequired();

           // // Each User can have many UserLogins
           //builder.HasMany<IdentityUserLogin<>().WithOne().HasForeignKey(ul => ul.UserId).IsRequired();

           // // Each User can have many UserTokens
           //builder.HasMany<IdentityUserToken>().WithOne().HasForeignKey(ut => ut.UserId).IsRequired();

           // // Each User can have many entries in the UserRole join table
           //builder.HasMany<IdentityUserRole>().WithOne().HasForeignKey(ur => ur.UserId).IsRequired();

            builder.HasMany(c => c.Exercises)
                .WithOne(c => c.User)
                .HasForeignKey(b => b.UserId);
            builder.HasMany(c => c.CheckLists)
                .WithOne(c => c.User)
                .HasForeignKey(b => b.UserId);
            builder.HasMany(c => c.Notes)
                .WithOne(c => c.User)
                .HasForeignKey(b => b.UserId);
        }
    }
}
