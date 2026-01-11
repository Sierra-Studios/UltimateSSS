using LabApi.Features.Wrappers;
using TMPro;
using UltimateSSS.SSS.Attributes;
using UserSettings.ServerSpecific;

namespace UltimateSSS.SSS.Settings.StaticSetting;

public abstract class StaticPlainText : StaticSetting<SSPlaintextSetting>
{
    [OptionalSetting] public virtual string PlaceHolder { get; set; } = "...";
    [OptionalSetting] public virtual int CharacterLimit { get; set; } = 64;
    [OptionalSetting] public virtual TMP_InputField.ContentType Type { get; set; } = TMP_InputField.ContentType.Standard;
    [OptionalSetting] public virtual byte CollectionId { get; set; } = 255;
    [OptionalSetting] public virtual bool IsServerOnly { get; set; } = false;
    
    public sealed override void PreAction(Player player, ServerSpecificSettingBase theBase)
    {
        OnAction(player, (SSPlaintextSetting)theBase);
    }
    
    public sealed override SSPlaintextSetting ConvertToBase()
    {
        return Base = new SSPlaintextSetting(Id, Label, PlaceHolder, CharacterLimit, Type, Hint, CollectionId, IsServerOnly);
    }
}