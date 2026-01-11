using LabApi.Features.Wrappers;
using UltimateSSS.SSS.Attributes;
using UserSettings.ServerSpecific;

namespace UltimateSSS.SSS.Settings.StaticSetting;

public abstract class StaticDropdown : StaticSetting<SSDropdownSetting>
{
    [RequiredSetting] public abstract string[] Options { get; set; }
    [OptionalSetting] public virtual int DefaultOptionIndex { get; set; } = 0;
    [OptionalSetting] public virtual SSDropdownSetting.DropdownEntryType EntryType { get; set; } =
        SSDropdownSetting.DropdownEntryType.Regular;
    [OptionalSetting] public virtual byte CollectionId { get; set; } = 255;
    [OptionalSetting] public virtual bool IsServerOnly { get; set; } = false;
    
    public sealed override void PreAction(Player player, ServerSpecificSettingBase theBase)
    {
        OnAction(player, (SSDropdownSetting)theBase);
    }
    
    public sealed override SSDropdownSetting ConvertToBase()
    {
        return Base = new SSDropdownSetting(Id, Label, Options, DefaultOptionIndex, EntryType, Hint, CollectionId, IsServerOnly);
    }
}