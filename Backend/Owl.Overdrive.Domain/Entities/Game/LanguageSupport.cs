using Owl.Overdrive.Domain.Entities.Base;

namespace Owl.Overdrive.Domain.Entities.Game
{
    public class LanguageSupport : BaseEntity
    {
        public long GameId { get; set; }
        public long LanguageId { get; set; }
        public long LanguageSupportTypeId { get; set; }

        public LanguageSupportType LanguageSupportType { get; set; } = null!;
        public Language Language { get; set; } = null!;
        public Game Game { get; set; } = null!;
    }
}
