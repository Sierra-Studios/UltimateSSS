
using LabApi.Features.Wrappers;
using UltimateSSS.SSS.Interfaces;
using UltimateSSS.SSS.Settings.PlayerSetting;
using UserSettings.ServerSpecific;

namespace UltimateSSS.SSS.Test.PlayerMenuTest;

public class MyPlayerButton : PlayerButton, IDebugSetting
{
    public override IHeader Header { get; set; } = new MyPlayerHeader();
    public override string Label(Player player)
    {
        return player.DisplayName;
    }

    public override string ButtonText(Player player)
    {
        return player.Nickname;
    }

    public override void OnAction(Player player, SSButton converted)
    {
        player.Kill("SSS");
        base.OnAction(player, converted);
    }
}
