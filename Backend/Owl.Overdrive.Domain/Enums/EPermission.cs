using Owl.Overdrive.Domain.Utilities;
using System.ComponentModel;

namespace Owl.Overdrive.Domain.Enums
{
    public static class PermissionCategories
    {
        public const string Company = "Company";
        public const string Game = "Game";
        public const string User = "User";
    }
    public enum EPermission
    {
        [Category(PermissionCategories.Company)]
        [Title("Display Company")]
        [Description("Display Company")]
        Display_Company,

        [Category(PermissionCategories.Company)]
        [Title("Details Company")]
        [Description("Details Company")]
        Details_Company,

        [Category(PermissionCategories.Company)]
        [Title("Create Company")]
        [Description("Create Company")]
        Create_Company,

        [Category(PermissionCategories.Company)]
        [Title("Update Company")]
        [Description("Update Company")]
        Update_Company,

        [Category(PermissionCategories.Game)]
        [Title("Display Game")]
        [Description("Display Game")]
        Display_Game,

        [Category(PermissionCategories.Game)]
        [Title("Details Game")]
        [Description("Details Game")]
        Details_Game,

        [Category(PermissionCategories.Game)]
        [Title("Create Game")]
        [Description("Create Game")]
        Create_Game,

        [Category(PermissionCategories.Game)]
        [Title("Update Game")]
        [Description("Update Game")]
        Update_Game,
    }
}
