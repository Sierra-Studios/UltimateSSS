
using System.Linq;
using LabApi.Features.Wrappers;
using UltimateSSS.SSS.Interfaces;
using UltimateSSS.SSS.Settings.PlayerSetting;
using UserSettings.ServerSpecific;

namespace UltimateSSS.SSS.Test.PlayerMenuTest;

public class MyPlayerDropdown : PlayerDropdown, IDebugSetting
{
    public override IHeader Header { get; set; } = new MyPlayerHeader();
    public override string Label(Player player)
    {
        return player.DisplayName;
    }

    public override string[] Options(Player player)
    {
        return Room.List.Select(x => x.Name.ToString()).ToArray();
    }

    public override void OnAction(Player player, SSDropdownSetting converted)
    {
        player.SendBroadcast($"Chose {converted.SyncSelectionText}", 5);
        base.OnAction(player, converted);
    }
}
