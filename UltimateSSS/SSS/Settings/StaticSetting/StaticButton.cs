using LabApi.Features.Wrappers;
using UltimateSSS.SSS.Attributes;
using UserSettings.ServerSpecific;

namespace UltimateSSS.SSS.Settings.StaticSetting;

public abstract class StaticButton : StaticSetting<SSButton>
{
    [RequiredSetting] public abstract string ButtonText { get; set; }
    [OptionalSetting] public virtual float? HoldTimeSeconds { get; set; } = null;
    
    public sealed override void PreAction(Player player, ServerSpecificSettingBase theBase)
    {
        OnAction(player, (SSButton)theBase);
    }
    
    public sealed override SSButton ConvertToBase()
    {
        return Base = new SSButton(Id, Label, ButtonText, HoldTimeSeconds, Hint);
    }
}