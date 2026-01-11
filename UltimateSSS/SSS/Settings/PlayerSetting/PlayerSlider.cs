using LabApi.Features.Wrappers;
using UltimateSSS.SSS.Attributes;
using UserSettings.ServerSpecific;

namespace UltimateSSS.SSS.Settings.PlayerSetting;

public abstract class PlayerSlider : PlayerSetting<SSSliderSetting>
{
    [RequiredSetting] public abstract float Min(Player player);
    [RequiredSetting] public abstract float Max(Player player);
    [OptionalSetting] public virtual float Default(Player player) => 0f;
    [OptionalSetting] public virtual bool IsInteger(Player player) => false;
    [OptionalSetting] public virtual string ToStringFormat(Player player) => "0.##";
    [OptionalSetting] public virtual string FinalFormat(Player player) => "{0}";
    [OptionalSetting] public virtual byte CollectionId(Player player) => 255;
    [OptionalSetting] public virtual bool IsServer(Player player) => false;
    
    public sealed override void PreAction(Player player, ServerSpecificSettingBase theBase)
    {
        OnAction(player, (SSSliderSetting)theBase);
    }
    
    public sealed override SSSliderSetting ConvertToBase(Player player)
    {
        return Base = new SSSliderSetting(Id(player), Label(player), Min(player), Max(player), Default(player), IsInteger(player), ToStringFormat(player), FinalFormat(player), Hint(player), CollectionId(player), IsServer(player));
    }
}