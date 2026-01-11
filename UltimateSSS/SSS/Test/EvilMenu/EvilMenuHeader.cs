using LabApi.Features.Wrappers;
using UltimateSSS.SSS.Settings.PlayerSetting;

namespace UltimateSSS.SSS.Test.EvilMenu;

public class EvilMenuHeader : PlayerHeader
{
    public override string Label(Player player)
    {
        return "Evil menu " + player.UserId;
    }
}