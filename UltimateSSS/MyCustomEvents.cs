using LabApi.Events.Arguments.PlayerEvents;
using LabApi.Events.CustomHandlers;
using LabApi.Features.Console;
using MEC;
using UltimateSSS.SSS;
using UltimateSSS.Utils;

namespace UltimateSSS;

public class MyCustomEvents : CustomEventsHandler
{
    public override void OnPlayerJoined(PlayerJoinedEventArgs ev)
    {
        MyLogger.Debug("Bro joined");
        Timing.CallDelayed(2f, () => UltimateSetting.Update(ev.Player));
        base.OnPlayerJoined(ev);
    }
}