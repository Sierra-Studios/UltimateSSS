using System;
using System.Collections.Generic;
using System.Reflection;
using LabApi.Features.Console;
using LabApi.Features.Enums;
using LabApi.Features.Wrappers;
using MEC;
using UltimateSSS.SSS.Interfaces;
using UltimateSSS.Utils;
using UserSettings.ServerSpecific;

namespace UltimateSSS.SSS;

public abstract class UltimateSetting : IGenericSetting
{
    public abstract IHeader Header { get; set; }
    public static EvilDictionary<Player, List<ServerSpecificSettingBase>> Cleaner = new();
    internal static void InternallyRegister()
    {
        ServerSpecificSettingsSync.DefinedSettings ??= Array.Empty<ServerSpecificSettingBase>();
        ServerSpecificSettingsSync.ServerOnSettingValueReceived += OnServerOnSettingValueReceived;
    }

    internal static void InternallyUnRegister()
    {
        ServerSpecificSettingsSync.ServerOnSettingValueReceived -= OnServerOnSettingValueReceived;
        ServerSpecificSettingsSync.ServerOnSettingValueReceived -= OnServerOnSettingValueReceived;
    }

    private static void OnServerOnSettingValueReceived(ReferenceHub arg1, ServerSpecificSettingBase arg2)
    {
        try
        {
            var player = Player.Get(arg1);

            if (player == null)
            {
                Logger.Error("Player was null");
            }
            
            if(SettingHolder.Contains(arg2.OriginalDefinition))
            {
                try
                {
                    SettingHolder.Get(arg2.OriginalDefinition).PreAction(player, arg2);
                }
                catch (Exception e)
                {
                    Logger.Error(e);
                }
                
            }
        }
        catch (Exception e)
        {
            Logger.Error(e);
        }
    }
    
    
    
    /// <summary>
    /// Determines if player should see setting
    /// </summary>
    /// <param name="player">Labapi wrapper of player</param>
    /// <returns>If the player will get setting</returns>
    public virtual bool Condition(Player player)
    {
        return true;
    }
    
    public static List<UltimateSetting> Settings { get; set; } = new();

    public static void Register(Assembly assembly = null)
    {
        assembly ??= Assembly.GetCallingAssembly();
        foreach (var type in assembly.GetTypes())
        {
            if (type.IsAbstract)
            {
                continue;
            }
            
            if (!type.IsSubclassOf(typeof(UltimateSetting)))
            {
                continue;
            }

            if (typeof(IDynamicallyFuckOff).IsAssignableFrom(type))
            {
                continue;
            }

            try
            {
                Settings.Add((UltimateSetting)Activator.CreateInstance(type));
            }
            catch (Exception e)
            {
                Logger.Error(e);
            }
        }
    }

    public static void Unregister(Assembly assembly = null)
    {
        assembly ??= Assembly.GetCallingAssembly();
        for (var index = 0; index < Settings.Count; index++)
        {
            var type = Settings[index];
            if (type.GetType().Assembly == assembly)
            {
                Settings.Remove(type);
            }
        }
    }
    
    public static List<UltimateSetting> Prepare(Player player)
    {
        var list = new List<UltimateSetting>();
        
        foreach (var setting in Settings)
        {
            if (setting is IHeader iheader && !iheader.IsAlone)
            {
                continue;
            }
            
            if (!setting.Condition(player))
            {
                continue;
            }
            
            list.Add(setting);
        }

        return list;
    }
    
    public static void ResyncServer()
    {
        // only update to real players that are authenticated
        foreach (var player in Player.GetAll(PlayerSearchFlags.AuthenticatedPlayers))
            Update(player);
    }

    public abstract void AddWhen(Player player, List<ServerSpecificSettingBase> settings);

    public void Update(Player player, float after)
    {
        if (player == null)
        {
            return;
        }
        Timing.CallDelayed(Timing.WaitForSeconds(after), () => Update(player));
    }
    
    public static ServerSpecificSettingBase[] Update(Player player)
    {
        if (player == null)
        {
            return Array.Empty<ServerSpecificSettingBase>();
        }
        
        List<ServerSpecificSettingBase> result = new List<ServerSpecificSettingBase>();
        EvilDictionary<IHeader, List<UltimateSetting>> dictionary = new EvilDictionary<IHeader, List<UltimateSetting>>();
        Dictionary<string, IHeader> names =  new Dictionary<string, IHeader>();

        SettingHolder.Clean(player);
        
        Cleaner[player, new List<ServerSpecificSettingBase>()].Clear();
        
        foreach (var setting in Prepare(player))
        {
            if (setting == null)
            {
                Logger.Error("WAS NULL WAS THE ISSUE");
            }
            
            IHeader header;
            
            if (setting is IHeader theHeader)
            {
                dictionary.Ensure(theHeader, new List<UltimateSetting>());
                continue;
            }
            
            if (names.TryGetValue(nameof(setting.Header), out header))
            {
                dictionary[header, new List<UltimateSetting>()].Add(setting);
                continue;
            }

            names[nameof(setting.Header)] = setting.Header;
            var value = dictionary[setting.Header, new List<UltimateSetting>()];
            if (value == null)
            {
                Logger.Error("Gave me null list dumbass");
            }
            else
            {
                value.Add(setting);
            }
        }

        foreach (var dict in dictionary)
        {
            dict.Key.AddYourselfInit(player, result);
            
            foreach (var li in dict.Value)
            {
                li.AddWhen(player, result);
            }

            foreach (var ds in dict.Key.PreDynamicSettings)
            {
                var converted = ds.ConvertToBase();
                result.Add(converted);
                SettingHolder.Add(converted, ds, player);
            }
        }

        var collection = result.ToArray();
        ServerSpecificSettingsSync.SendToPlayer(player.ReferenceHub, collection);
        return collection;
    }


    public abstract void PreAction(Player player, ServerSpecificSettingBase theBase);
}