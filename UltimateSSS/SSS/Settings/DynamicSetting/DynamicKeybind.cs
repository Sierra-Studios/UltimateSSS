using UltimateSSS.SSS.Attributes;
using UnityEngine;
using UserSettings.ServerSpecific;

namespace UltimateSSS.SSS.Settings.DynamicSetting;

public class DynamicKeybind : DynamicSetting<SSKeybindSetting>
{
    [RequiredSetting] public KeyCode SuggestedKey { get; set; }
    [OptionalSetting] public bool PreventInteractionOnGui { get; set; } = true;
    [OptionalSetting] public bool AllowSpectatorTrigger { get; set; } = true;
    [OptionalSetting] public byte CollectionId { get; set; } = 255;

    public DynamicKeybind(string label, int? id = null, KeyCode suggestedKey = KeyCode.None, bool preventInteractionOnGui = false, 
        bool allowSpectatorTrigger = false, byte collectionId = 255)
    {
        Label = label;
        Id = id;
        SuggestedKey = suggestedKey;
        PreventInteractionOnGui = preventInteractionOnGui;
        AllowSpectatorTrigger = allowSpectatorTrigger;
        CollectionId = collectionId;
    }
    
    public sealed override SSKeybindSetting ConvertDynamically()
    {
        return Base = new SSKeybindSetting(Id, Label, SuggestedKey, PreventInteractionOnGui, AllowSpectatorTrigger, Hint,
            CollectionId);
    }
}