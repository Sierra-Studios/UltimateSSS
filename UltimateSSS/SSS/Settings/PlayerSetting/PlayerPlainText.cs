using LabApi.Features.Wrappers;
using TMPro;
using UltimateSSS.SSS.Attributes;
using UserSettings.ServerSpecific;

namespace UltimateSSS.SSS.Settings.PlayerSetting;

public abstract class PlayerPlainText : PlayerSetting<SSPlaintextSetting>
{
    [OptionalSetting] public virtual string PlaceHolder(Player player) => "...";
    [OptionalSetting] public virtual int CharacterLimit(Player player) => 64;
    [OptionalSetting] public virtual TMP_InputField.ContentType Type(Player player) => TMP_InputField.ContentType.Standard;
    [OptionalSetting] public virtual byte CollectionId(Player player) => 255;
    [OptionalSetting] public virtual bool IsServerOnly(Player player) => false;
    
    public sealed override void PreAction(Player player, ServerSpecificSettingBase theBase)
    {
        OnAction(player, (SSPlaintextSetting)theBase);
    }
    
    public sealed override SSPlaintextSetting ConvertToBase(Player player)
    {
        return Base = new SSPlaintextSetting(Id(player), Label(player), PlaceHolder(player), CharacterLimit(player), Type(player), Hint(player), CollectionId(player), IsServerOnly(player));
    }
}