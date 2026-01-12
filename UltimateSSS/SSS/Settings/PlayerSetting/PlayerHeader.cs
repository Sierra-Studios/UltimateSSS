using System.Collections.Generic;
using LabApi.Features.Wrappers;
using UltimateSSS.SSS.Attributes;
using UltimateSSS.SSS.Interfaces;
using UserSettings.ServerSpecific;

namespace UltimateSSS.SSS.Settings.PlayerSetting;

public abstract class PlayerHeader : PlayerSetting<SSGroupHeader>, IHeader
{
    [OptionalSetting] public virtual bool ReducedPadding(Player player) => false;
    [OptionalSetting] public virtual List<IDynamicSetting> PreDynamicSettings { get; set; } = new();
    [OptionalSetting] public virtual bool IsAlone { get; set; } = false;
    [OptionalSetting] public virtual int HeaderOrder { get; set; } = 0;
    [OptionalSetting] public List<IDynamicSetting> AfterDynamicSettings { get; set; } = new();
    
    [OptionalSetting] public virtual List<IDynamicSetting> AfterDynamic(Player player) => new();
    
    
    public sealed override IHeader Header { get; set; } = null;
    public sealed override int Order { get; set; } = 0;
    public sealed override void PreAction(Player player, ServerSpecificSettingBase theBase) {}
    public sealed override void OnAction(Player player, SSGroupHeader converted) {}
    
    public void AddYourselfInit(Player player, List<ServerSpecificSettingBase> settings)
    {
        var based = ConvertToBase(player);
        settings.Add(based);
        SettingHolder.Add(based, this, player);

        foreach (var i in AfterDynamicSettings)
        {
            var bs = i.ConvertToBase();
            settings.Add(bs);
            SettingHolder.Add(bs, i, player);
        }
        
        foreach (var i in AfterDynamic(player))
        {
            var bs = i.ConvertToBase();
            settings.Add(bs);
            SettingHolder.Add(bs, i, player);
        }
    }
    
    public sealed override SSGroupHeader ConvertToBase(Player player)
    {
        return Base = new SSGroupHeader(Id(player), Label(player), ReducedPadding(player), Hint(player));
    }
}