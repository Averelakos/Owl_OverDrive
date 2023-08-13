using Owl.Overdrive.Domain.Enums;

namespace Owl.Overdrive.Business.DTOs.GameDtos.Create
{
    public class CreativeAlternativeTitleDto
    {
        public string AlternativeName { get; set; } = null!;
        public EAlternativeTitleType AlternativeTitleType { get; set; }
    }
}
