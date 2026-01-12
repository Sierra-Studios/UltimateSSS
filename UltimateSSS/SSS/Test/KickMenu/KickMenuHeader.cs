using System.Collections.Generic;
using LabApi.Features.Wrappers;
using Mirror;
using UltimateSSS.SSS.Interfaces;
using UltimateSSS.SSS.Settings.DynamicSetting;
using UltimateSSS.SSS.Settings.PlayerSetting;

namespace UltimateSSS.SSS.Test.KickMenu;

public class KickMenuHeader : PlayerHeader, IDebugSetting
{
    public override bool IsAlone { get; set; } = true;

    public override string Label(Player player)
    {
        return "KickSection";
    }

    public override List<IDynamicSetting> AfterDynamic(Player player)
    {
        List<IDynamicSetting> settings = new List<IDynamicSetting>();
        
        foreach (var plr in Player.ReadyList)
        {
            settings.Add(new DynamicButton(plr.PlayerId.ToString(), "Kick", () =>
            {
                plr.Kick("You were kicked because of SSS");
                if (plr.IsDummy)
                {
                    NetworkServer.Destroy(plr.GameObject);
                }
                Update(player, 0.5f);
            }));
        }

        return settings;
    }
}