using LabApi.Features.Wrappers;
using UserSettings.ServerSpecific;

namespace UltimateSSS.SSS.Interfaces;

public interface IGenericSetting
{
    public void PreAction(Player player, ServerSpecificSettingBase theBase);
}