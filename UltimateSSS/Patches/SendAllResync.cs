using HarmonyLib;
using UltimateSSS.SSS;
using UserSettings.ServerSpecific;

//Secret API

namespace UltimateSSS.Patches;

/// <summary>
/// Fixes <see cref="ServerSpecificSettingsSync.SendToAll"/> to resync with <see cref="CustomSetting.ResyncServer"/>.
/// </summary>
[HarmonyPatch(typeof(ServerSpecificSettingsSync), nameof(ServerSpecificSettingsSync.SendToAll))]
internal static class SendSettingsServerSync
{
    private static bool Prefix()
    {
        UltimateSetting.ResyncServer();
        return false;
    }
}