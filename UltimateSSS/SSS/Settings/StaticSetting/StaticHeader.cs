using System.Collections.Generic;
using LabApi.Features.Wrappers;
using UltimateSSS.SSS.Attributes;
using UltimateSSS.SSS.Interfaces;
using UserSettings.ServerSpecific;

namespace UltimateSSS.SSS.Settings.StaticSetting;

public abstract class StaticHeader : StaticSetting<SSGroupHeader>, IHeader
{
    [OptionalSetting] public virtual bool ReducedPadding { get; set; } = false;
    [OptionalSetting] public virtual List<IDynamicSetting> PreDynamicSettings { get; } = new();
    [OptionalSetting] public virtual bool IsAlone { get; set; } = false;
    [OptionalSetting] public virtual int HeaderOrder { get; set; } = 0;
    [OptionalSetting] public virtual List<IDynamicSetting> AfterDynamicSettings() => new();
    
    public sealed override IHeader Header { get; set; } = null;
    public sealed override int Order { get; set; } = 0;
    public sealed override void PreAction(Player player, ServerSpecificSettingBase theBase) {}
    public sealed override void OnAction(Player player, SSGroupHeader converted) {}
    
    public void AddYourselfInit(Player player, List<ServerSpecificSettingBase> settings)
    {
        var based = ConvertToBase();
        settings.Add(based);
        SettingHolder.Add(based, this, player);

        foreach (var i in AfterDynamicSettings())
        {
            var bs = i.ConvertToBase();
            settings.Add(bs);
            SettingHolder.Add(bs, i, player);
        }
    }
    
    public sealed override SSGroupHeader ConvertToBase()
    {
        return Base = new SSGroupHeader(Id, Label, ReducedPadding, Hint);
    }
}