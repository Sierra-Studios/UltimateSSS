using System.Collections.Generic;
using System.Linq;
using LabApi.Features.Wrappers;
using UltimateSSS.SSS.Interfaces;
using UltimateSSS.Utils;
using UserSettings.ServerSpecific;

namespace UltimateSSS.SSS;

public class SettingHolder
{
    public static HashSet<ServerSpecificSettingBase> TheBase { get; } = new();
    
    public static EvilDictionary<Player, List<ServerSpecificSettingBase>> Cleaner { get; } = new();
    public static Dictionary<ServerSpecificSettingBase, IGenericSetting> TheUltimate { get; } = new();
    
    public static void Add(ServerSpecificSettingBase setting, IGenericSetting genericSetting, Player owner)
    {
        TheUltimate[setting] = genericSetting;
        TheBase.Add(setting);
        Cleaner[owner, new List<ServerSpecificSettingBase>()].Add(setting);
        Sync();
    }

    public static void Remove(ServerSpecificSettingBase setting, Player owner)
    {
        TheUltimate.Remove(setting);
        TheBase.Remove(setting);
        Cleaner[owner, new List<ServerSpecificSettingBase>()].Remove(setting);
        Sync();
    }

    public static void Clean(Player owner)
    {
        var cleaner = Cleaner[owner, new List<ServerSpecificSettingBase>()];
        for (var index = 0; index < cleaner.Count; index++)
        {
            Remove(cleaner[index], owner);
        }
    }
    
    public static bool Contains(ServerSpecificSettingBase setting)
    {
        return TheBase.Contains(setting);
    }

    public static IGenericSetting Get(ServerSpecificSettingBase setting)
    {
        return TheUltimate[setting];
    }
    
    public static void Sync()
    {
        ServerSpecificSettingsSync.DefinedSettings = TheBase.ToArray();
    }
}