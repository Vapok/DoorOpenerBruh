using HarmonyLib;
using Jotunn.Managers;

namespace DoorOpenerBruh.Patches;

internal static class FejdStartupPatches
{
    [HarmonyPatch(typeof(FejdStartup), nameof(FejdStartup.Awake))]
    [HarmonyAfter("vapok.common.LocalizationManager", "org.bepinex.helpers.LocalizationManager")]
    [HarmonyBefore("vapok.common.ItemManager", "org.bepinex.helpers.ItemManager")]
    internal static class FejdStartupAwakePatch
    {
        [HarmonyPrepare]
        private static bool Prepare() => !GUIManager.IsHeadless();

        private static void Prefix()
        {
            DoorOpenerBruh.Waiter.ValheimIsAwake(true);
        }
    }
}