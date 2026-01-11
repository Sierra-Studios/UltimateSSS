using System;
using System.Collections.Generic;
using LabApi.Features.Wrappers;
using UltimateSSS.SSS.Attributes;
using UltimateSSS.SSS.Interfaces;
using UserSettings.ServerSpecific;

namespace UltimateSSS.SSS.Settings.DynamicSetting;

public class DynamicHeader : DynamicSetting<SSGroupHeader>, IHeader
{
    [OptionalSetting] public bool ReducedPadding { get; set; } = false;
    [OptionalSetting] public List<IDynamicSetting> PreDynamicSettings { get; } = new();
    [OptionalSetting] public bool IsAlone { get; set; } = false;
    [OptionalSetting] public int Order { get; set; } = 0;
    [OptionalSetting] public List<IDynamicSetting> AfterDynamicSettings() => new();

    public DynamicHeader(string label, int? id = null, bool reducedPadding = false, Action action = null, bool isAlone = false, List<IDynamicSetting> preDynamicSettings = null)
    {
        Label = label;
        Id = id;
        ReducedPadding = reducedPadding;
        Action = action;
        IsAlone = isAlone;
        if(preDynamicSettings != null)
            PreDynamicSettings = preDynamicSettings;
    }
    
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
    
    public sealed override SSGroupHeader ConvertDynamically()
    {
        return Base = new SSGroupHeader(Id, Label, ReducedPadding, Hint);
    }
}