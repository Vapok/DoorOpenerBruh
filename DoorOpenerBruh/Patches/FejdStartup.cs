using HarmonyLib;

namespace DoorOpenerBruh.Patches;

internal static class FejdStartupPatches
{
    [HarmonyPatch(typeof(FejdStartup), nameof(FejdStartup.Awake))]
    [HarmonyAfter("org.bepinex.helpers.LocalizationManager")]
    [HarmonyBefore("org.bepinex.helpers.ItemManager")]
    internal static class FejdStartupAwakePatch
    {
        [HarmonyPrepare]
        private static bool Prepare() => UnityEngine.SystemInfo.graphicsDeviceType != UnityEngine.Rendering.GraphicsDeviceType.Null;

        private static void Prefix()
        {
            DoorOpenerBruh.Waiter.ValheimIsAwake(true);
        }
    }
}