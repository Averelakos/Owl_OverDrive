using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Owl.Overdrive.Domain.Entities.Auth;

namespace Owl.Overdrive.Infrastructure.Persistence.Configurations.AuthConfiguration
{
    public class UserRoleConfiguration : BaseEntityConfiguration, IEntityTypeConfiguration<UserRole>
    {
        public UserRoleConfiguration() : base()
        {

        }

        public void Configure(EntityTypeBuilder<UserRole> builder)
        {
            ApplyConfiguration(builder);
            ConfigurationBase(builder);
        }

        public static void ApplyConfiguration(EntityTypeBuilder<UserRole> builder)
        {
            // Table Name
            builder.ToTable("UserRole");

            // Properties parameters
            builder.HasOne(x => x.Role).WithMany().HasForeignKey(x => x.RoleId);
            //builder.HasOne(x => x.User).WithMany(x => x.Roles).HasForeignKey(x => x.UserId);

        }
    }
}
