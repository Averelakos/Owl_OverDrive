using Owl.Overdrive.Domain.Utilities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Owl.Overdrive.Domain.Enums
{
    public enum EWebsiteCategory
    {
        [Title("Official")]
        [Description("Official")]
        official,
        [Title("Wikia")]
        [Description("Wikia")]
        wikia,
        [Title("Wikipedia")]
        [Description("Wikipedia")]
        wikipedia,
        [Title("Facebook")]
        [Description("Facebook")]
        facebook,
        [Title("Twitter")]
        [Description("Twitter")]
        twitter,
        [Title("Twitch")]
        [Description("Twitch")]
        twitch,
        [Title("Instagram")]
        [Description("Instagram")]
        instagram,
        [Title("Youtube")]
        [Description("Youtube")]
        youtube,
        [Title("Iphone")]
        [Description("Iphone")]
        iphone,
        [Title("Ipad")]
        [Description("Ipad")]
        ipad,
        [Title("Android")]
        [Description("Android")]
        android,
        [Title("Steam")]
        [Description("Steam")]
        steam,
        [Title("Reddit")]
        [Description("Reddit")]
        reddit,
        [Title("Itch")]
        [Description("Itch")]
        itch,
        [Title("Epicgames")]
        [Description("Epicgames")]
        epicgames,
        [Title("GOG")]
        [Description("GOG")]
        gog,
        [Title("Discord")]
        [Description("Discord")]
        discord,
    }
}
