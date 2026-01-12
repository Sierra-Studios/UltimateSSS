using System;
using System.Collections.Generic;
using HarmonyLib;
using LabApi.Events.CustomHandlers;
using LabApi.Features.Console;
using LabApi.Loader.Features.Plugins;
using MEC;
using UltimateSSS.SSS;
using UltimateSSS.Utils;

namespace UltimateSSS;

public class EntryPoint : Plugin<Config>
{
    public override string Name { get; } = "UltimateSSS";
    public override string Description { get; } = "Ultimate SSS";
    public override string Author { get; } = "Saskyc";
    public override Version Version { get; } = new Version(1, 1, 0);
    public override Version RequiredApiVersion { get; } = new Version(1, 1, 4);
    public static EntryPoint Instance { get; set; }
    
    public Harmony Harmony { get; set; }
    public MyCustomEvents CustomEvents { get; set; }
    
    public override void Enable()
    {
        Instance = this;
        UltimateSetting.InternallyRegister();
        UltimateSetting.Register();
        
        //Coroutine.Start();
        CustomEvents = new MyCustomEvents();
        CustomHandlersManager.RegisterEventsHandler(CustomEvents);
        
        Harmony = new Harmony("UltimateSSS.domain");
        Harmony.PatchAll();
    }

    public override void Disable()
    {
        UltimateSetting.Unregister();
        UltimateSetting.InternallyUnRegister();
        
        CustomHandlersManager.UnregisterEventsHandler(CustomEvents);
        
        Harmony.UnpatchAll();
        Harmony = null;
        Instance = null;
    }

    public IEnumerator<float> UpdateLoop()
    {
        while (true)
        {
            try
            {
                MyLogger.Debug("UPDATE");
                UltimateSetting.ResyncServer();
            }
            catch (Exception e)
            {
                Logger.Error(e);
            }
        
            yield return Timing.WaitForSeconds(0.5f);
        }
    }
}