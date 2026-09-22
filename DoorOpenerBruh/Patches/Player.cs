using DoorOpenerBruh.Components;
using HarmonyLib;

namespace DoorOpenerBruh.Patches;

internal static class PlayerPatches
{
    [HarmonyPatch(typeof(Player), nameof(Player.SetLocalPlayer))]
    internal static class PlayerSetLocalPlayerPatch
    {
        [HarmonyPrepare]
        private static bool Prepare() => UnityEngine.SystemInfo.graphicsDeviceType != UnityEngine.Rendering.GraphicsDeviceType.Null;

        private static void Postfix()
        {
            if (DoorOpener.Instance == null) return;
            DoorOpener.Instance.ResetBruh();
        }
    }
}