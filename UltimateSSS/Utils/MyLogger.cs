using InventorySystem.Items.Usables.Scp330;
using LabApi.Features.Console;

namespace UltimateSSS.Utils;

public class MyLogger
{
    public static void Debug(string message)
    {
        if (EntryPoint.Instance.Config.Debug)
        {
            Logger.Debug(message);
        }
    }
}