using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Owl.Overdrive.Domain.Entities.Auth;

namespace Owl.Overdrive.Infrastructure.Persistence.Configurations.AuthConfiguration
{
    public class RoleConfiguration : BaseEntityConfiguration, IEntityTypeConfiguration<Role>
    {
        public RoleConfiguration() : base()
        {

        }

        public void Configure(EntityTypeBuilder<Role> builder)
        {
            ApplyConfiguration(builder);
            ConfigurationBase(builder);
        }

        public static void ApplyConfiguration(EntityTypeBuilder<Role> builder)
        {
            // Table Name
            builder.ToTable("Roles");

            // Properties parameters
            builder.Property(x => x.Name).HasMaxLength(255);
            builder.Property(x => x.Description).HasMaxLength(4000);

            Seed(builder);
        }

        private static void Seed(EntityTypeBuilder<Role> builder)
        {
            builder.HasData(new Role()
            {
                Id = -1,
                Name = "System",
                Description = "System Role"
            });
            builder.HasData(new Role()
            {
                Id = 1,
                Name = "Administrator",
                Description = "Administrator Role"
            });
            builder.HasData(new Role()
            {
                Id = 2,
                Name = "Agent",
                Description = "Agent Role"
            });
            builder.HasData(new Role()
            {
                Id = 3,
                Name = "Reviewer",
                Description = "Reviewer Role"
            });
            builder.HasData(new Role()
            {
                Id = 4,
                Name = "Default",
                Description = "Default Role"
            });
        }
    }
}
