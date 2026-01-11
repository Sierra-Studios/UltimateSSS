using LabApi.Features.Wrappers;
using UltimateSSS.SSS.Attributes;
using UserSettings.ServerSpecific;

namespace UltimateSSS.SSS.Settings.PlayerSetting;

public abstract class PlayerTwoButton : PlayerSetting<SSTwoButtonsSetting>
{
    [RequiredSetting] public abstract string OptionA(Player player);
    [RequiredSetting] public abstract string OptionB(Player player);
    [OptionalSetting] public virtual bool IsDefaultB(Player player) => false;
    [OptionalSetting] public virtual byte CollectionId(Player player) => 255;
    [OptionalSetting] public virtual bool IsServerOnly(Player player) => false;
    
    public sealed override void PreAction(Player player, ServerSpecificSettingBase theBase)
    {
        OnAction(player, (SSTwoButtonsSetting)theBase);
    }
    
    public sealed override SSTwoButtonsSetting ConvertToBase(Player player)
    {
        return Base = new SSTwoButtonsSetting(Id(player), Label(player), OptionA(player), OptionB(player), 
            IsDefaultB(player), Hint(player), CollectionId(player), IsServerOnly(player));
    }
}