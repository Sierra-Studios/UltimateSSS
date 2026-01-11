using LabApi.Features.Wrappers;
using UltimateSSS.SSS.Attributes;
using UnityEngine;
using UserSettings.ServerSpecific;

namespace UltimateSSS.SSS.Settings.PlayerSetting;

public abstract class PlayerKeybind : PlayerSetting<SSKeybindSetting>
{
    [RequiredSetting] public abstract KeyCode SuggestedKey(Player player);
    [OptionalSetting] public virtual bool PreventInteractionOnGui(Player player) => true;
    [OptionalSetting] public virtual bool AllowSpectatorTrigger(Player player) => true;
    [OptionalSetting] public virtual byte CollectionId(Player player) => 255;
    
    public sealed override void PreAction(Player player, ServerSpecificSettingBase theBase)
    {
        OnAction(player, (SSKeybindSetting)theBase);
    }

    public sealed override SSKeybindSetting ConvertToBase(Player player)
    {
        return Base = new SSKeybindSetting(Id(player), Label(player), SuggestedKey(player), PreventInteractionOnGui(player), AllowSpectatorTrigger(player), Hint(player),
            CollectionId(player));
    }
}