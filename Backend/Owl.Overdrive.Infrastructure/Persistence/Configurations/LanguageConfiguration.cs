using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Owl.Overdrive.Domain.Entities;

namespace Owl.Overdrive.Infrastructure.Persistence.Configurations
{
    public class LanguageConfiguration : BaseEntityConfiguration, IEntityTypeConfiguration<Language>
    {
        public LanguageConfiguration() : base()
        {

        }

        public void Configure(EntityTypeBuilder<Language> builder)
        {
            ApplyConfiguration(builder);
            ConfigurationBase(builder);
        }

        public static void ApplyConfiguration(EntityTypeBuilder<Language> builder)
        {
            // Table Name
            builder.ToTable("Languages");

            // Properties parameters
            builder.Property(p => p.Name).HasColumnType("varchar(MAX)");//.HasMaxLength(255);

            Seed(builder);
        }

        private static void Seed(EntityTypeBuilder<Language> builder)
        {
            builder.HasData(new Language() { Id = 1, Name = "German" });
            builder.HasData(new Language() { Id = 2, Name = "Ukrainian" });
            builder.HasData(new Language() { Id = 3, Name = "Arabic" });
            builder.HasData(new Language() { Id = 4, Name = "Chinese (Simplified)" });
            builder.HasData(new Language() { Id = 5, Name = "Chinese (Traditional)" });
            builder.HasData(new Language() { Id = 6, Name = "Czech" });
            builder.HasData(new Language() { Id = 7, Name = "Danish" });
            builder.HasData(new Language() { Id = 8, Name = "Dutch" });
            builder.HasData(new Language() { Id = 9, Name = "English" });
            builder.HasData(new Language() { Id = 10, Name = "English (UK)" });
            builder.HasData(new Language() { Id = 11, Name = "Spanish (Spain)" });
            builder.HasData(new Language() { Id = 12, Name = "Spanish (Mexico)" });
            builder.HasData(new Language() { Id = 13, Name = "French" });
            builder.HasData(new Language() { Id = 14, Name = "Finnish" });
            builder.HasData(new Language() { Id = 15, Name = "Hungarian" });
            builder.HasData(new Language() { Id = 16, Name = "Italian" });
            builder.HasData(new Language() { Id = 17, Name = "Hebrew" });
            builder.HasData(new Language() { Id = 18, Name = "Japanese" });
            builder.HasData(new Language() { Id = 19, Name = "Korean" });
            builder.HasData(new Language() { Id = 20, Name = "Norwegian" });
            builder.HasData(new Language() { Id = 21, Name = "Portuguese (Portugal)" });
            builder.HasData(new Language() { Id = 22, Name = "Polish" });
            builder.HasData(new Language() { Id = 23, Name = "Portuguese (Brazil)" });
            builder.HasData(new Language() { Id = 24, Name = "Russian" });
            builder.HasData(new Language() { Id = 25, Name = "Thai" });
            builder.HasData(new Language() { Id = 26, Name = "Turkish" });
            builder.HasData(new Language() { Id = 27, Name = "Vietnamese" });
            builder.HasData(new Language() { Id = 28, Name = "Swedish" });
        }
    }
}
