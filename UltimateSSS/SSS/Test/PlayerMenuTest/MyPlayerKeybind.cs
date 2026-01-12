
using LabApi.Features.Wrappers;
using UltimateSSS.SSS.Interfaces;
using UltimateSSS.SSS.Settings.PlayerSetting;
using UnityEngine;
using UserSettings.ServerSpecific;

namespace UltimateSSS.SSS.Test.PlayerMenuTest;

public class MyPlayerKeybind : PlayerKeybind, IDebugSetting
{
    public override int Order { get; set; } = -1;

    public override IHeader Header { get; set; } = new MyPlayerHeader();
    public override string Label(Player player)
    {
        return player.DisplayName;
    }

    public override KeyCode SuggestedKey(Player player)
    {
        return (KeyCode)player.PlayerId;
    }

    public override void OnPressed(Player player, SSKeybindSetting keybindSetting)
    {
        player.ClearBroadcasts();
        player.SendBroadcast("You pressed keybind", 5);
        base.OnPressed(player, keybindSetting);
    }
    
    public override void OnRelease(Player player, SSKeybindSetting keybindSetting)
    {
        player.ClearBroadcasts();
        player.SendBroadcast("You released keybind", 5);
        base.OnPressed(player, keybindSetting);
    }
}
