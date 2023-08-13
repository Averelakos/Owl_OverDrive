using Owl.Overdrive.Domain.Utilities;
using System.ComponentModel;

namespace Owl.Overdrive.Domain.Enums
{
    public enum EAlternativeTitleType
    {
        [Title("Abbreviation")]
        [Description("Abbreviation")]
        Abbreviation,
        [Title("Acronym")]
        [Description("Acronym")]
        Acronym,
        [Title("Alternative spelling")]
        [Description("Alternativespelling")]
        Alternative_spelling,
        [Title("Alternative title")]
        [Description("Alternative title")]
        Alternative_title,
        [Title("Chinese title - simplified")]
        [Description("Chinese title - simplified")]
        Chinese_title_simplified,
        [Title("Chinese title - traditional")]
        [Description("Chinese title - traditional")]
        Chinese_title_traditional,
        [Title("European title")]
        [Description("European title")]
        European_title,
        [Title("French title")]
        [Description("French title")]
        French_title,
        [Title("German title")]
        [Description("German title")]
        German_title,
        [Title("Italian title")]
        [Description("Italian title")]
        Italian_title,
        [Title("Japanese title - original")]
        [Description("Japanese title - original")]
        Japanese_title_original,
        [Title("Japanese title - romanization")]
        [Description("Japanese title - romanization")]
        Japanese_title_romanization,
        [Title("Japanese title - stylized")]
        [Description("Japanese title - stylized")]
        Japanese_title_stylized,
        [Title("Japanese title - translated")]
        [Description("Japanese title - translated")]
        Japanese_title_translated,
        [Title("Korean title")]
        [Description("Korean title")]
        Korean_title,
        [Title("Korean title romanization")]
        [Description("Korean title romanization")]
        Korean_title_romanization,
        [Title("Korean title translated")]
        [Description("Korean title translated")]
        Korean_title_translated,
        [Title("Polish title")]
        [Description("Polish title")]
        Polish_title,
        [Title("Portuguese title")]
        [Description("Portuguese title")]
        Portuguese_title,
        [Title("Russian title")]
        [Description("Russian title")]
        Russian_title,
        [Title("Spanish title")]
        [Description("Spanish title")]
        Spanish_title,
        [Title("Stylized title")]
        [Description("Stylized title")]
        Stylized_title,
        [Title("Working title")]
        [Description("Working title")]
        Working_title,
    }
}
