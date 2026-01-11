using System.Collections.Generic;
using System.Reflection.Emit;
using HarmonyLib;
using UserSettings.ServerSpecific;

//ASS

namespace UltimateSSS.Patches;

[HarmonyPatch(typeof(ServerSpecificSettingsSync), nameof(ServerSpecificSettingsSync.SendOnJoinFilter), MethodType.Setter)]
public class PreAuthFix
{
    // why would you call SendToPlayer DURING authentication instead of after smh.
    // Now I gotta patch out SendOnJoinFilter cuz I cant overwrite the action in Init, and if I don't do this, people don't spawn in during round start for some reason!?
    public static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions)
    {
        yield return new CodeInstruction(OpCodes.Ret);
    }
}