
using LabApi.Features.Wrappers;
using UltimateSSS.SSS.Interfaces;
using UltimateSSS.SSS.Settings.PlayerSetting;

namespace UltimateSSS.SSS.Test.PlayerMenuTest;

public class MyPlayerTextArea : PlayerTextArea, IDebugSetting
{
    public override IHeader Header { get; set; } = new MyPlayerHeader();
    public override string Context(Player player)
    {
        return $"Hello {player.DisplayName}! This is text just for you! Your ip is: {player.IpAddress}";
    }
}
