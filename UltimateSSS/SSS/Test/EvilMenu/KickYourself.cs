/*using LabApi.Features.Wrappers;
using UltimateSSS.SSS.Interfaces;
using UltimateSSS.SSS.Settings.PlayerSetting;
using UserSettings.ServerSpecific;

namespace UltimateSSS.SSS.Test.EvilMenu;

public class KickYourself : PlayerButton
{
    public override IHeader Header { get; set; } = new EvilMenuHeader();
    public override string Label(Player player)
    {
        return $"Kick yourself";
    }

    public override string ButtonText(Player player)
    {
        return $"{player.Nickname}";
    }

    public override void OnAction(Player player, SSButton ssButton)
    {
        player.Kick("Idiot");
        base.OnAction(player, ssButton);
    }
}*/