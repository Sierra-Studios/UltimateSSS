using LabApi.Features.Wrappers;
using UltimateSSS.SSS.Attributes;
using UltimateSSS.SSS.Interfaces;
using UserSettings.ServerSpecific;

namespace UltimateSSS.SSS.Settings.StaticSetting;

public abstract class StaticSlider : StaticSetting<SSSliderSetting>
{
    [RequiredSetting] public abstract float Min { get; set; }
    [RequiredSetting] public abstract float Max { get; set; }
    [OptionalSetting] public virtual float Default { get; set; } = 0f;
    [OptionalSetting] public virtual bool IsInteger { get; set; } = false;
    [OptionalSetting] public virtual string ToStringFormat { get; set; } = "0.##";
    [OptionalSetting] public virtual string FinalFormat { get; set; } = "{0}";
    [OptionalSetting] public virtual byte CollectionId { get; set; } = 255;
    [OptionalSetting] public virtual bool IsServer { get; set; } = false;
    
    public sealed override void PreAction(Player player, ServerSpecificSettingBase theBase)
    {
        OnAction(player, (SSSliderSetting)theBase);
    }
    
    public sealed override SSSliderSetting ConvertToBase()
    {
        return Base = new SSSliderSetting(Id, Label, Min, Max, Default, IsInteger, ToStringFormat, FinalFormat, Hint, CollectionId, IsServer);
    }
}