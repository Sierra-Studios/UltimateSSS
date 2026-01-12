
using LabApi.Features.Wrappers;
using UltimateSSS.SSS.Interfaces;
using UltimateSSS.SSS.Settings.PlayerSetting;
using UltimateSSS.SSS.Settings.StaticSetting;

namespace UltimateSSS.SSS.Test.PlayerMenuTest;

public class MyPlayerHeader : PlayerHeader, IDebugSetting
{
    public override string Label(Player player)
    {
        return "Player menu " + player.Nickname;
    }
}
