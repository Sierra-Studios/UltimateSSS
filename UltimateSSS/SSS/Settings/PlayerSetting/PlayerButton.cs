using LabApi.Features.Wrappers;
using UltimateSSS.SSS.Attributes;
using UserSettings.ServerSpecific;

namespace UltimateSSS.SSS.Settings.PlayerSetting;

public abstract class PlayerButton : PlayerSetting<SSButton>
{
    [RequiredSetting] public abstract string ButtonText(Player player);
    [OptionalSetting] public virtual float? HoldTimeSeconds(Player player) => null;
    
    public sealed override void PreAction(Player player, ServerSpecificSettingBase theBase)
    {
        OnAction(player, (SSButton)theBase);
    }
    
    public sealed override SSButton ConvertToBase(Player player)
    {
        return Base = new SSButton(Id(player), Label(player), ButtonText(player), HoldTimeSeconds(player), Hint(player));
    }
}