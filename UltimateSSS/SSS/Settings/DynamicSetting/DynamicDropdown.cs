using UltimateSSS.SSS.Attributes;
using UserSettings.ServerSpecific;

namespace UltimateSSS.SSS.Settings.DynamicSetting;

public class DynamicDropdown : DynamicSetting<SSDropdownSetting>
{
    [RequiredSetting] public string[] Options { get; set; }
    [OptionalSetting] public int DefaultOptionIndex { get; set; }
    [OptionalSetting] public SSDropdownSetting.DropdownEntryType EntryType { get; set; }
    [OptionalSetting] public byte CollectionId { get; set; }
    [OptionalSetting] public bool IsServerOnly { get; set; }

    public DynamicDropdown(string label, string[] options, int? id, int defaultOptionIndex = 0, 
        SSDropdownSetting.DropdownEntryType entryType = SSDropdownSetting.DropdownEntryType.Regular, byte collectionId = 255, bool isServerOnly = false)
    {
        Label = label;
        Id = id;
        Options = options;
        DefaultOptionIndex = defaultOptionIndex;
        EntryType = entryType;
        CollectionId = collectionId;
        IsServerOnly = isServerOnly;
    }
    
    public sealed override SSDropdownSetting ConvertDynamically()
    {
        return Base = new SSDropdownSetting(Id, Label, Options, DefaultOptionIndex, EntryType, Hint, CollectionId, IsServerOnly);
    }
}