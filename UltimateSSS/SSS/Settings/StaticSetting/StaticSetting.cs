using System.Collections.Generic;
using LabApi.Features.Wrappers;
using UltimateSSS.SSS.Attributes;
using UserSettings.ServerSpecific;

namespace UltimateSSS.SSS.Settings.StaticSetting;

public abstract class StaticSetting<T> : SettingFinalMerger<T> where T : ServerSpecificSettingBase
{
    [RequiredSetting] public abstract string Label { get; set; }
    [OptionalSetting] public virtual int? Id { get; set; } = null;
    [OptionalSetting] public virtual string Hint { get; set; } = null;
    [OptionalSetting] public virtual void OnAction(Player player, T converted) { }
    
    public sealed override void AddWhen(Player player, List<ServerSpecificSettingBase> settings)
    {
        var based = ConvertToBase();
        settings.Add(based);
        SettingHolder.Add(based, this, player);
    }
    
    public abstract T ConvertToBase();

    public static implicit operator T(StaticSetting<T> setting)
    {
        return setting.ConvertToBase();
    }
}