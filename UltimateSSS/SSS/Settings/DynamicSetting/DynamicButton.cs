using System;
using UltimateSSS.SSS.Attributes;
using UserSettings.ServerSpecific;

namespace UltimateSSS.SSS.Settings.DynamicSetting;

public class DynamicButton : DynamicSetting<SSButton>
{
    [RequiredSetting] public string ButtonText { get; set; }
    [OptionalSetting] public float? HoldTimeSeconds { get; set; } = null;
    
    public DynamicButton([RequiredSetting] string label, [RequiredSetting] string buttonText, [OptionalSetting] Action action = null,
        [OptionalSetting] int? id = null, [OptionalSetting] float? holdTimeSeconds = null, [OptionalSetting] string hint = null)
    {
        Label = label;
        ButtonText = buttonText;
        Id = id;
        HoldTimeSeconds = holdTimeSeconds;
        Hint = hint;
        Action = action;
    }
    
    public sealed override SSButton ConvertDynamically()
    {
        return Base = new SSButton(Id, Label, ButtonText, HoldTimeSeconds, Hint);
    }
}