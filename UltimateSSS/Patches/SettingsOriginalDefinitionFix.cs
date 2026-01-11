using HarmonyLib;
using LabApi.Features.Console;
using UltimateSSS.SSS;
using UltimateSSS.SSS.Settings;
using UserSettings.ServerSpecific;

//Secret API

namespace UltimateSSS.Patches;

/// <summary>
/// Fixes <see cref="ServerSpecificSettingBase.OriginalDefinition"/> on custom settings.
/// </summary>
[HarmonyPatch(typeof(ServerSpecificSettingBase), nameof(ServerSpecificSettingBase.OriginalDefinition), MethodType.Getter)]
internal static class SettingsOriginalDefinitionFix
{
#pragma warning disable SA1313
    private static void Postfix(ServerSpecificSettingBase __instance, ref ServerSpecificSettingBase __result)
#pragma warning restore SA1313
    {
        // Prevent handling non SecretAPI (UltimateSSS) settings.
        if (__result != null)
            return;

        var setting = SettingHolder.Get(__instance);

        if (setting is not SettingMerger settingMerger)
        {
            return;
        }

        if (settingMerger.PreBase == null)
        {
            Logger.Error("Pre-Base is null");
            return;
        }
        
        __result = settingMerger.PreBase;
    }
}