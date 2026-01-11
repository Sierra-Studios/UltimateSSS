using LabApi.Features.Wrappers;
using UltimateSSS.SSS.Attributes;
using UserSettings.ServerSpecific;

namespace UltimateSSS.SSS.Settings.PlayerSetting;

public abstract class PlayerDropdown : PlayerSetting<SSDropdownSetting>
{
    [RequiredSetting] public abstract string[] Options(Player player);
    [OptionalSetting] public virtual int DefaultOptionIndex(Player player) => 0;
    [OptionalSetting] public virtual SSDropdownSetting.DropdownEntryType EntryType(Player player) =>
        SSDropdownSetting.DropdownEntryType.Regular;
    [OptionalSetting] public virtual byte CollectionId(Player player) => 255;
    [OptionalSetting] public virtual bool IsServerOnly(Player player) => false;
    
    public sealed override void PreAction(Player player, ServerSpecificSettingBase theBase)
    {
        OnAction(player, (SSDropdownSetting)theBase);
    }
    
    public sealed override SSDropdownSetting ConvertToBase(Player player)
    {
        return Base = new SSDropdownSetting(Id(player), Label(player), Options(player), DefaultOptionIndex(player), EntryType(player), Hint(player), CollectionId(player), IsServerOnly(player));
    }
}