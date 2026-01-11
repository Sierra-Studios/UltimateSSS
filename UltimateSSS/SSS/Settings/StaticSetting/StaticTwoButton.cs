using LabApi.Features.Wrappers;
using UltimateSSS.SSS.Attributes;
using UserSettings.ServerSpecific;

namespace UltimateSSS.SSS.Settings.StaticSetting;

public abstract class StaticTwoButton : StaticSetting<SSTwoButtonsSetting>
{
    [RequiredSetting] public abstract string OptionA { get; set; }
    [RequiredSetting] public abstract string OptionB { get; set; }
    [OptionalSetting] public virtual bool IsDefaultB { get; set; } = false;
    [OptionalSetting] public virtual byte CollectionId { get; set; } = 255;
    [OptionalSetting] public virtual bool IsServerOnly { get; set; } = false;
    
    public sealed override void PreAction(Player player, ServerSpecificSettingBase theBase)
    {
        OnAction(player, (SSTwoButtonsSetting)theBase);
    }
    
    public sealed override SSTwoButtonsSetting ConvertToBase()
    {
        return Base = new SSTwoButtonsSetting(Id, Label, OptionA, OptionB, IsDefaultB, Hint, CollectionId, IsServerOnly);
    }
}