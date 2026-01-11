using TMPro;
using UltimateSSS.SSS.Attributes;
using UserSettings.ServerSpecific;

namespace UltimateSSS.SSS.Settings.DynamicSetting;

public class DynamicPlainText : DynamicSetting<SSPlaintextSetting>
{
    [OptionalSetting] public string PlaceHolder { get; set; }
    [OptionalSetting] public int CharacterLimit { get; set; }
    [OptionalSetting] public TMP_InputField.ContentType Type { get; set; }
    [OptionalSetting] public byte CollectionId { get; set; }
    [OptionalSetting] public bool IsServerOnly { get; set; }

    public DynamicPlainText(string label, int? id = null, string placeHolder = "...", int characterLimit = 64, 
        TMP_InputField.ContentType type = TMP_InputField.ContentType.Standard, byte collectionId = 255, bool isServerOnly = false)
    {
        Label = label;
        Id = id;
        PlaceHolder = placeHolder;
        CharacterLimit = characterLimit;
        Type = type;
        CollectionId = collectionId;
        IsServerOnly = isServerOnly;
    }
    
    public sealed override SSPlaintextSetting ConvertDynamically()
    {
        return Base = new SSPlaintextSetting(Id, Label, PlaceHolder, CharacterLimit, Type, Hint, CollectionId, IsServerOnly);
    }
}