using LabApi.Features.Wrappers;
using UltimateSSS.SSS.Interfaces;
using UltimateSSS.SSS.Settings.PlayerSetting;

namespace UltimateSSS.SSS.Test.EvilMenu;

public class EvilMenuHeader : PlayerHeader, IDebugSetting
{
    public override string Label(Player player)
    {
        return "Evil menu " + player.UserId;
    }
}