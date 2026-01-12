using System.Collections.Generic;
using LabApi.Features.Wrappers;
using UltimateSSS.SSS.Attributes;
using UserSettings.ServerSpecific;

namespace UltimateSSS.SSS.Settings.PlayerSetting;

public abstract class PlayerSetting<T> : SettingFinalMerger<T> where T : ServerSpecificSettingBase
{
    [RequiredSetting] public abstract string Label(Player player);
    [OptionalSetting] public virtual int? Id(Player player) => null;
    [OptionalSetting] public virtual string Hint(Player player) => null;
    [OptionalSetting] public virtual void OnAction(Player player, T converted) { }

    public sealed override void AddWhen(Player player, List<ServerSpecificSettingBase> settings)
    {
        var based = ConvertToBase(player);
        settings.Add(based);
        SettingHolder.Add(based, this, player);
    }
    
    public abstract T ConvertToBase(Player player);
}