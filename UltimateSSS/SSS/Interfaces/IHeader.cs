using System.Collections.Generic;
using LabApi.Features.Wrappers;
using UserSettings.ServerSpecific;

namespace UltimateSSS.SSS.Interfaces;

public interface IHeader
{
    public List<IDynamicSetting> PreDynamicSettings { get; }
    
    public bool IsAlone { get; set; }

    public void AddYourselfInit(Player player, List<ServerSpecificSettingBase> settings);
}