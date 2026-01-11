using LabApi.Features.Wrappers;
using TMPro;
using UltimateSSS.SSS.Attributes;
using UserSettings.ServerSpecific;

namespace UltimateSSS.SSS.Settings.StaticSetting;

public abstract class StaticTextArea : StaticSetting<SSTextArea>
{
    [RequiredSetting] public abstract string Context { get; set; }
    [OptionalSetting] public virtual SSTextArea.FoldoutMode FoldoutMode { get; set; } = SSTextArea.FoldoutMode.NotCollapsable;
    [OptionalSetting] public virtual string CollapsedText { get; set; } = null;
    [OptionalSetting] public virtual TextAlignmentOptions TextAlignment { get; set; } = TextAlignmentOptions.TopLeft;

    public sealed override string Label { get; set; } = null;
    public sealed override int? Id { get; set; } = null;
    public sealed override string Hint { get; set; } = null;
    
    public sealed override void PreAction(Player player, ServerSpecificSettingBase theBase)
    {
        OnAction(player, (SSTextArea)theBase);
    }
    
    public sealed override SSTextArea ConvertToBase()
    {
        return Base = new SSTextArea(Id, Context, FoldoutMode, CollapsedText, TextAlignment);
    }
}