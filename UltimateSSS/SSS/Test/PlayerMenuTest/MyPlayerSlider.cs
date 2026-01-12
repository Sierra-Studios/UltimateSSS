
using LabApi.Features.Wrappers;
using UltimateSSS.SSS.Interfaces;
using UltimateSSS.SSS.Settings.PlayerSetting;
using UserSettings.ServerSpecific;

namespace UltimateSSS.SSS.Test.PlayerMenuTest;

public class MyPlayerSlider : PlayerSlider, IDebugSetting
{
    public override IHeader Header { get; set; } = new MyPlayerHeader();
    public override string Label(Player player)
    {
        return player.DisplayName;
    }

    public override float Min(Player player)
    {
        return 1;
    }

    public override float Max(Player player)
    {
        return player.MaxHealth;
    }

    public override void OnAction(Player player, SSSliderSetting converted)
    {
        player.Health = converted.SyncFloatValue;
        base.OnAction(player, converted);
    }
}
