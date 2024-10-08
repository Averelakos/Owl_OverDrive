﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Owl.Overdrive.Domain.Entities.Auth;

namespace Owl.Overdrive.Infrastructure.Persistence.Configurations.AuthConfiguration
{
    public class UserConfiguration : BaseEntityConfiguration, IEntityTypeConfiguration<User>
    {
        public UserConfiguration() : base()
        {

        }

        public void Configure(EntityTypeBuilder<User> builder)
        {
            ApplyConfiguration(builder);
            ConfigurationBase(builder);
        }

        public static void ApplyConfiguration(EntityTypeBuilder<User> builder)
        {
            // Table Name
            builder.ToTable("Users");

            // Properties parameters
            //builder.Property(p => p.Firstname).HasMaxLength(255);
            //builder.Property(p => p.Lastname).HasMaxLength(255);
            builder.Property(p => p.Email).HasMaxLength(255);
            builder.Property(p => p.Username).HasMaxLength(255);
            //builder.Property(p => p.Phone).HasMaxLength(255);
            //builder.Property(p => p.Birthdate).HasColumnType("datetime2(7)");

            //Seed(builder);
        }

        private static void Seed(EntityTypeBuilder<User> builder)
        {
            builder.HasData(new User()
            {
                Id = 1,
                Username = "administrator",
                Email = "admin@owloverdrive.com",
                //PasswordHash = "",
                //PasswordSalt = ""
                
            });
        }
    }
}
