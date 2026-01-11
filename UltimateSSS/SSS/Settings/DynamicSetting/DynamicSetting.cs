using System;
using System.Collections.Generic;
using LabApi.Features.Console;
using LabApi.Features.Wrappers;
using UltimateSSS.SSS.Attributes;
using UltimateSSS.SSS.Interfaces;
using UserSettings.ServerSpecific;

namespace UltimateSSS.SSS.Settings.DynamicSetting;

public abstract class DynamicSetting<T> : SettingFinalMerger<T>, IDynamicSetting, IDynamicallyFuckOff where T : ServerSpecificSettingBase
{
    [RequiredSetting] public string Label { get; set; }
    [OptionalSetting] public int? Id { get; set; } = null;
    [OptionalSetting] public string Hint { get; set; } = null;
    #nullable enable
    [OptionalSetting] public Action? Action { get; set; }
    #nullable disable
    public sealed override IHeader Header { get; set; } = null;
    
    public sealed override void AddWhen(Player player, List<ServerSpecificSettingBase> settings)
    {
        var based = ConvertDynamically();
        settings.Add(based);
        SettingHolder.Add(based, this, player);
    }
    
    public abstract T ConvertDynamically();

    public sealed override void PreAction(Player player, ServerSpecificSettingBase theBase)
    {
        try
        {
            Action?.Invoke();
        }
        catch (Exception e)
        {
            Logger.Error(e);
        }
    }

    public ServerSpecificSettingBase ConvertToBase()
    {
        return ConvertDynamically();
    }
    
    public static implicit operator T(DynamicSetting<T> setting)
    {
        return setting.ConvertDynamically();
    }
}