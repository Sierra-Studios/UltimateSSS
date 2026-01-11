using UserSettings.ServerSpecific;

namespace UltimateSSS.SSS.Settings;

public abstract class SettingMerger : UltimateSetting
{
    public virtual ServerSpecificSettingBase PreBase { get; set; }
}