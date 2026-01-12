
using LabApi.Features.Wrappers;
using UltimateSSS.SSS.Interfaces;
using UltimateSSS.SSS.Settings.PlayerSetting;
using UserSettings.ServerSpecific;

namespace UltimateSSS.SSS.Test.PlayerMenuTest;

public class MyPlayerPlainText : PlayerPlainText, IDebugSetting
{
    public override IHeader Header { get; set; } = new MyPlayerHeader();
    public override string Label(Player player)
    {
        return player.DisplayName;
    }

    public override string PlaceHolder(Player player)
    {
        return player.DisplayName + " " + player.LifeId + " " + player.NetworkId + " " + player.PlayerId;
    }

    public override void OnAction(Player player, SSPlaintextSetting converted)
    {
        player.ClearBroadcasts();
        player.SendBroadcast($"You wrote: {converted.SyncInputText}", 5);
        base.OnAction(player, converted);
    }
}
