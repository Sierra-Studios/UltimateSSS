using LabApi.Features.Wrappers;
using TMPro;
using UltimateSSS.SSS.Attributes;
using UserSettings.ServerSpecific;

namespace UltimateSSS.SSS.Settings.PlayerSetting;

public abstract class PlayerTextArea : PlayerSetting<SSTextArea>
{
    [RequiredSetting] public abstract string Context(Player player);
    [OptionalSetting] public virtual SSTextArea.FoldoutMode FoldoutMode(Player player) => SSTextArea.FoldoutMode.NotCollapsable;
    [OptionalSetting] public virtual string CollapsedText(Player player) => null;
    [OptionalSetting] public virtual TextAlignmentOptions TextAlignment(Player player) => TextAlignmentOptions.TopLeft;

    public sealed override string Label(Player player) => null;
    public sealed override int? Id(Player player) => null;
    public sealed override string Hint(Player player) => null;
    
    public sealed override void PreAction(Player player, ServerSpecificSettingBase theBase)
    {
        OnAction(player, (SSTextArea)theBase);
    }
    
    public sealed override SSTextArea ConvertToBase(Player player)
    {
        return Base = new SSTextArea(Id(player), Context(player), FoldoutMode(player), CollapsedText(player), TextAlignment(player));
    }
}