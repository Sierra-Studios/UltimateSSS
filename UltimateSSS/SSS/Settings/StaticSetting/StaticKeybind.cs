using LabApi.Features.Wrappers;
using UltimateSSS.SSS.Attributes;
using UnityEngine;
using UserSettings.ServerSpecific;

namespace UltimateSSS.SSS.Settings.StaticSetting;

public abstract class StaticKeybind : StaticSetting<SSKeybindSetting>
{
    [RequiredSetting] public abstract KeyCode SuggestedKey { get; set; }
    [OptionalSetting] public virtual bool PreventInteractionOnGui { get; set; } = true;
    [OptionalSetting] public virtual bool AllowSpectatorTrigger { get; set; } = true;
    [OptionalSetting] public virtual byte CollectionId { get; set; } = 255;
    
    public sealed override void PreAction(Player player, ServerSpecificSettingBase theBase)
    {
        var based = (SSKeybindSetting)theBase;

        if (!based.SyncIsPressed)
        {
            OnRelease(player, based);
        }
        else
        {
            OnPressed(player, based);
        }
        
        OnAction(player, based);
    }

    public virtual void OnRelease(Player player, SSKeybindSetting keybindSetting) { }
    
    public virtual void OnPressed(Player player, SSKeybindSetting keybindSetting) { }

    public sealed override SSKeybindSetting ConvertToBase()
    {
        return Base = new SSKeybindSetting(Id, Label, SuggestedKey, PreventInteractionOnGui, AllowSpectatorTrigger, Hint,
            CollectionId);
    }
}