using UserSettings.ServerSpecific;

namespace UltimateSSS.SSS.Interfaces;

public interface IDynamicSetting : IGenericSetting
{
    public ServerSpecificSettingBase ConvertToBase();
}