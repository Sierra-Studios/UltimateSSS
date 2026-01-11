using System;
using HarmonyLib;
using LabApi.Loader.Features.Plugins;
using UltimateSSS.SSS;

namespace UltimateSSS;

public class EntryPoint : Plugin<Config>
{
    public override string Name { get; } = "UltimateSSS";
    public override string Description { get; } = "Ultimate SSS";
    public override string Author { get; } = "Saskyc";
    public override Version Version { get; } = new Version(1, 0, 0);
    public override Version RequiredApiVersion { get; } = new Version(1, 1, 4);
    public Harmony Harmony { get; set; }
    
    public override void Enable()
    {
        UltimateSetting.InternallyRegister();
        Harmony = new Harmony("UltimateSSS.domain");
        Harmony.PatchAll();
        UltimateSetting.Register();
    }

    public override void Disable()
    {
        Harmony.UnpatchAll();
        Harmony = null;
        UltimateSetting.Unregister();
        UltimateSetting.InternallyUnRegister();
    }
}