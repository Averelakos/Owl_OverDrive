using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Owl.Overdrive.Domain.Entities;
using Owl.Overdrive.Domain.Entities.Auth;

namespace Owl.Overdrive.Infrastructure.Persistence.Configurations
{
    public class ImagesDraftConfiguration :BaseEntityConfiguration, IEntityTypeConfiguration<ImageDraft>
    {
        public ImagesDraftConfiguration() : base()
        {
            
        }

        public void Configure(EntityTypeBuilder<ImageDraft> builder)
        {
            ConfigurationBase(builder);
            ApplyConfiguration(builder);
        }

        public static void ApplyConfiguration(EntityTypeBuilder<ImageDraft> builder)
        {
            // Table Name
            builder.ToTable("ImageDrafts");

            // Properties parameters
            //builder.HasKey(x => x.GuidId);
            builder.HasKey(x => x.Id );
            builder.Property(x => x.Id).HasDefaultValueSql("newsequentialid()");
        }

        private static void Seed(EntityTypeBuilder<User> builder)
        {
            //builder.HasData(new User()
            //{
            //    Id = -1,
            //    Username = "Admin",
            //    Email = "Admin@owlo.gr"
            //});
        }
    }
}
