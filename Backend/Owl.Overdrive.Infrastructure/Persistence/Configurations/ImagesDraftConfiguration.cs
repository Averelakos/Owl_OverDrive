using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Owl.Overdrive.Domain.Entities;

namespace Owl.Overdrive.Infrastructure.Persistence.Configurations
{
    public class ImagesDraftConfiguration :BaseEntityConfiguration, IEntityTypeConfiguration<ImageDraft>
    {
        public ImagesDraftConfiguration() : base()
        {
            
        }

        public void Configure(EntityTypeBuilder<ImageDraft> builder)
        {
            ApplyConfiguration(builder);
            ConfigurationBase(builder);
        }

        public static void ApplyConfiguration(EntityTypeBuilder<ImageDraft> builder)
        {
            // Table Name
            builder.ToTable("ImageDrafts");

            // Properties parameters
            builder.HasKey(x => x.GuiId);
            builder.Property(x => x.GuiId).HasDefaultValueSql("newsequentialid()");
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
