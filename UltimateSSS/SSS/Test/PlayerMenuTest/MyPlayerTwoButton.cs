
using LabApi.Features.Wrappers;
using UltimateSSS.SSS.Interfaces;
using UltimateSSS.SSS.Settings.PlayerSetting;
using UserSettings.ServerSpecific;

namespace UltimateSSS.SSS.Test.PlayerMenuTest;

public class MyPlayerTwoButton : PlayerTwoButton, IDebugSetting
{
    public override IHeader Header { get; set; } = new MyPlayerHeader();
    public override string Label(Player player)
    {
        return player.DisplayName;
    }

    public override string OptionA(Player player)
    {
        return player.Health.ToString();
    }

    public override string OptionB(Player player)
    {
        return player.MaxHealth.ToString();
    }

    public override void OnAction(Player player, SSTwoButtonsSetting converted)
    {
        if (converted.SyncIsA)
        {
            player.Health -= 1;
            return;
        }
        
        player.Health = player.MaxHealth;
        base.OnAction(player, converted);
    }
}
