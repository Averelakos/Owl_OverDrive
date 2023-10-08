using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Owl.Overdrive.Domain.Entities.Auth;

namespace Owl.Overdrive.Infrastructure.Persistence.Configurations.AuthConfiguration
{
    public class RolePermissionConfiguration : BaseEntityConfiguration, IEntityTypeConfiguration<RolePermission>
    {
        public RolePermissionConfiguration() : base()
        {

        }

        public void Configure(EntityTypeBuilder<RolePermission> builder)
        {
            ApplyConfiguration(builder);
            ConfigurationBase(builder);
        }

        public static void ApplyConfiguration(EntityTypeBuilder<RolePermission> builder)
        {
            // Table Name
            builder.ToTable("RolePermissions");

            // Properties parameters
            builder.HasOne(x => x.Role).WithMany(x => x.RolePermissions).HasForeignKey(x => x.RoleId);
            builder.Property(u => u.Permission).HasMaxLength(255);

            Seed(builder);
        }

        private static void Seed(EntityTypeBuilder<RolePermission> builder)
        {
            builder.HasData(new RolePermission()
            {
                Id = -8,
                RoleId = -1,
                Permission = "Display_Company",
            });
            builder.HasData(new RolePermission()
            {
                Id = -7,
                RoleId = -1,
                Permission = "Details_Company",
            });
            builder.HasData(new RolePermission()
            {
                Id = -6,
                RoleId = -1,
                Permission = "Create_Company",
            });
            builder.HasData(new RolePermission()
            {
                Id = -5,
                RoleId = -1,
                Permission = "Update_Company",
            });
            builder.HasData(new RolePermission()
            {
                Id = -4,
                RoleId = -1,
                Permission = "Display_Game",
            });
            builder.HasData(new RolePermission()
            {
                Id = -3,
                RoleId = -1,
                Permission = "Details_Game",
            });
            builder.HasData(new RolePermission()
            {
                Id = -2,
                RoleId = -1,
                Permission = "Create_Game",
            });
            builder.HasData(new RolePermission()
            {
                Id = -1,
                RoleId = -1,
                Permission = "Update_Game",
            });
            // Administrator
            builder.HasData(new RolePermission()
            {
                Id = 1,
                RoleId = 1,
                Permission = "Display_Company",
            });
            builder.HasData(new RolePermission()
            {
                Id = 2,
                RoleId = 1,
                Permission = "Details_Company",
            });
            builder.HasData(new RolePermission()
            {
                Id = 3,
                RoleId = 1,
                Permission = "Create_Company",
            });
            builder.HasData(new RolePermission()
            {
                Id = 4,
                RoleId = 1,
                Permission = "Update_Company",
            });
            builder.HasData(new RolePermission()
            {
                Id = 5,
                RoleId = 1,
                Permission = "Display_Game",
            });
            builder.HasData(new RolePermission()
            {
                Id = 6,
                RoleId = 1,
                Permission = "Details_Game",
            });
            builder.HasData(new RolePermission()
            {
                Id = 7,
                RoleId = 1,
                Permission = "Create_Game",
            });
            builder.HasData(new RolePermission()
            {
                Id = 8,
                RoleId = 1,
                Permission = "Update_Game",
            });

            // Agent 
            builder.HasData(new RolePermission()
            {
                Id = 9,
                RoleId = 2,
                Permission = "Display_Company",
            });
            builder.HasData(new RolePermission()
            {
                Id =10,
                RoleId = 2,
                Permission = "Details_Company",
            });
            builder.HasData(new RolePermission()
            {
                Id = 11,
                RoleId = 2,
                Permission = "Create_Company",
            });
            builder.HasData(new RolePermission()
            {
                Id = 12,
                RoleId = 2,
                Permission = "Update_Company",
            });
            builder.HasData(new RolePermission()
            {
                Id = 13,
                RoleId = 2,
                Permission = "Display_Game",
            });
            builder.HasData(new RolePermission()
            {
                Id = 14,
                RoleId = 2,
                Permission = "Details_Game",
            });
            builder.HasData(new RolePermission()
            {
                Id = 15,
                RoleId = 2,
                Permission = "Create_Game",
            });
            builder.HasData(new RolePermission()
            {
                Id = 16,
                RoleId = 2,
                Permission = "Update_Game",
            });

            //Reviewer
            builder.HasData(new RolePermission()
            {
                Id = 17,
                RoleId = 3,
                Permission = "Display_Company",
            });
            builder.HasData(new RolePermission()
            {
                Id = 18,
                RoleId = 3,
                Permission = "Details_Company",
            });
            
            builder.HasData(new RolePermission()
            {
                Id = 19,
                RoleId = 3,
                Permission = "Display_Game",
            });
            builder.HasData(new RolePermission()
            {
                Id = 20,
                RoleId = 3,
                Permission = "Details_Game",
            });
            

            //Default
            builder.HasData(new RolePermission()
            {
                Id = 21,
                RoleId = 4,
                Permission = "Display_Company",
            });
            builder.HasData(new RolePermission()
            {
                Id = 22,
                RoleId = 4,
                Permission = "Details_Company",
            });
            
            builder.HasData(new RolePermission()
            {
                Id = 23,
                RoleId = 4,
                Permission = "Display_Game",
            });
            builder.HasData(new RolePermission()
            {
                Id = 24,
                RoleId = 4,
                Permission = "Details_Game",
            });

            builder.HasData(new RolePermission()
            {
                Id = 25,
                RoleId = 1,
                Permission = "Display_User",
            });
            builder.HasData(new RolePermission()
            {
                Id = 26,
                RoleId = 1,
                Permission = "Update_User",
            });



        }
    }
}
