using Owl.Overdrive.Domain.Enums;

namespace Owl.Overdrive.Business.DTOs.GameDtos.Create
{
    public class CreativeAlternativeNameDto
    {
        public string AlternativeName { get; set; } = null!;
        public EAlternativeTitleType Type { get; set; }
    }
}
