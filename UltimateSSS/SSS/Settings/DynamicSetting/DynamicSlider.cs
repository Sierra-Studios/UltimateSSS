using UltimateSSS.SSS.Attributes;
using UserSettings.ServerSpecific;

namespace UltimateSSS.SSS.Settings.DynamicSetting;

public class DynamicSlider : DynamicSetting<SSSliderSetting>
{
    [RequiredSetting] public float Min { get; set; }
    [RequiredSetting] public float Max { get; set; }
    [OptionalSetting] public float Default { get; set; } = 0f;
    [OptionalSetting] public bool IsInteger { get; set; } = false;
    [OptionalSetting] public string ToStringFormat { get; set; } = "0.##";
    [OptionalSetting] public string FinalFormat { get; set; } = "{0}";
    [OptionalSetting] public byte CollectionId { get; set; } = 255;
    [OptionalSetting] public bool IsServer { get; set; } = false;

    public DynamicSlider(string label, float max, float min, float @default = 0f, int? id = null, bool isInteger = false, string toStringFormat = "0.##", 
        string finalFormat = "{0}", byte collectionId = 255, bool isServer = false)
    {
        Label = label;
        Max = max;
        Min = min;
        Default = @default;
        IsInteger = isInteger;
        ToStringFormat = toStringFormat;
        FinalFormat = finalFormat;
        CollectionId = collectionId;
        IsServer = isServer;
    }
    
    public sealed override SSSliderSetting ConvertDynamically()
    {
        return Base = new SSSliderSetting(Id, Label, Min, Max, Default, IsInteger, ToStringFormat, FinalFormat, Hint, CollectionId, IsServer);
    }
}