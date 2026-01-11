using LabApi.Features.Wrappers;
using UltimateSSS.SSS.Interfaces;
using UltimateSSS.SSS.Settings.StaticSetting;
using UserSettings.ServerSpecific;

namespace UltimateSSS.SSS.Test.EvilMenu;

public class EvilButton : StaticButton
{
    public override string Label { get; set; } = "Evil Button";
    public override string ButtonText { get; set; } = "Click Me";
    public override IHeader Header { get; set; } = new EvilMenuHeader();

    public override void OnAction(Player player, SSButton ssButton)
    {
        player.SendBroadcast("You sent button", 3);
        base.OnAction(player, ssButton);
    }
}