using Owl.Overdrive.Domain.Utilities;
using System.ComponentModel;

namespace Owl.Overdrive.Domain.Enums
{
    public enum EGameStatus
    {
        [Title("Alpha")]
        [Description("Alpha")]
        Alpha,
        [Title("Beta")]
        [Description("Beta")]
        Beta,
        [Title("Cancelled")]
        [Description("Cancelled")]
        Cancelled,
        [Title("Early Access")]
        [Description("Early Access")]
        Early_Access,
        [Title("Full Release")]
        [Description("Full Release")]
        Full_Release,
        [Title("Offline")]
        [Description("Offline")]
        Offline,
    }
}
