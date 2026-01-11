using UltimateSSS.SSS.Attributes;
using UserSettings.ServerSpecific;

namespace UltimateSSS.SSS.Settings.DynamicSetting;

public class DynamicTwoButton : DynamicSetting<SSTwoButtonsSetting>
{
    [RequiredSetting] public string OptionA { get; set; }
    [RequiredSetting] public string OptionB { get; set; }
    [OptionalSetting] public bool IsDefaultB { get; set; } = false;
    [OptionalSetting] public byte CollectionId { get; set; } = 255;
    [OptionalSetting] public bool IsServerOnly { get; set; } = false;

    public DynamicTwoButton(string label, string optionA, string optionB, int? id = null, bool isDefaultB = false,
        byte collectionId = 255, bool isServerOnly = false)
    {
        Label = label;
        OptionA = optionA;
        OptionB = optionB;
        Id = id;
        IsDefaultB = isDefaultB;
        CollectionId = collectionId;
        IsServerOnly = isServerOnly;
    }

    public sealed override SSTwoButtonsSetting ConvertDynamically()
    {
        return Base = new SSTwoButtonsSetting(Id, Label, OptionA, OptionB, IsDefaultB, Hint, CollectionId, IsServerOnly);
    }
}