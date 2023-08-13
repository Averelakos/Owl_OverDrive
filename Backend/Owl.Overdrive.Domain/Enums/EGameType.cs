using Owl.Overdrive.Domain.Utilities;
using System.ComponentModel;

namespace Owl.Overdrive.Domain.Enums
{
    public enum EGameType
    {
        [Title("Main Game")]
        [Description("Main Game")]
        Main,
        [Title("Bundle")]
        [Description("Bundle")]
        Bundle,
        [Title("DLC")]
        [Description("DLC")]
        DLC,
        [Title("Episode")]
        [Description("Episode")]
        Episode,
        [Title("Expanded game")]
        [Description("Expanded game")]
        Expanded_game,
        [Title("Expansion")]
        [Description("Expansion")]
        Expansion,
        [Title("Fork")]
        [Description("Fork")]
        Fork,
        [Title("Mod")]
        [Description("Mod")]
        Mod,
        [Title("'Pack / Addon'")]
        [Description("'Pack / Addon'")]
        Pack_Addon,
        [Title("Port")]
        [Description("Port")]
        Port,
        [Title("Remake")]
        [Description("Remake")]
        Remake,
        [Title("Remaster")]
        [Description("Remaster")]
        Remaster,
        [Title("Season")]
        [Description("Season")]
        Season,
        [Title("Standalone Expansion")]
        [Description("Standalone Expansion")]
        Standalone_Expansion,
        [Title("Update")]
        [Description("Update")]
        Update
    }
}
