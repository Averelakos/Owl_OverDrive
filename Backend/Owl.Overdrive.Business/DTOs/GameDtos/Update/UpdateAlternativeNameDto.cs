using Owl.Overdrive.Domain.Enums;

namespace Owl.Overdrive.Business.DTOs.GameDtos.Update
{
    public class UpdateAlternativeNameDto
    {
        public string AlternativeName { get; set; } = null!;
        public EAlternativeTitleType Type { get; set; }
    }
}
