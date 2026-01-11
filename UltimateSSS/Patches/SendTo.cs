using HarmonyLib;
using LabApi.Features.Wrappers;
using UltimateSSS.SSS;
using UserSettings.ServerSpecific;

//Secret API

namespace UltimateSSS.Patches;

/// <summary>
/// Fixes <see cref="ServerSpecificSettingsSync.SendToPlayer(ReferenceHub)"/> to resync with <see cref="CustomSetting.SendSettingsToPlayer"/>.
/// </summary>
[HarmonyPatch(typeof(ServerSpecificSettingsSync), nameof(ServerSpecificSettingsSync.SendToPlayer), typeof(ReferenceHub))]
internal static class SendSettingsPlayerSync
{
    private static bool Prefix(ReferenceHub hub)
    {
        var player = Player.Get(hub);
        if (player == null)
        {
            return false;
        }

        UltimateSetting.Update(player);
        return false;
    }
}