using TMPro;
using UltimateSSS.SSS.Attributes;
using UserSettings.ServerSpecific;

namespace UltimateSSS.SSS.Settings.DynamicSetting;

public class DynamicTextArea : DynamicSetting<SSTextArea>
{
    [RequiredSetting] public string Context { get; set; }
    [OptionalSetting] public  SSTextArea.FoldoutMode FoldoutMode { get; set; } = SSTextArea.FoldoutMode.NotCollapsable;
    [OptionalSetting] public string CollapsedText { get; set; } = null;
    [OptionalSetting] public TextAlignmentOptions TextAlignment { get; set; } = TextAlignmentOptions.TopLeft;

    public DynamicTextArea(string context, int? id = null, SSTextArea.FoldoutMode foldoutMode = SSTextArea.FoldoutMode.NotCollapsable,
        string collapsedText = null, TextAlignmentOptions textAlignment = TextAlignmentOptions.TopLeft)
    {
        Context = context;
        Id = id;
        FoldoutMode = foldoutMode;
        CollapsedText = collapsedText;
        TextAlignment = textAlignment;
    }
    
    public sealed override SSTextArea ConvertDynamically()
    {
        return Base = new SSTextArea(Id, Context, FoldoutMode, CollapsedText, TextAlignment);
    }
}