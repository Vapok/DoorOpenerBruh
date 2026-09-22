using DoorOpenerBruh.Components;
using HarmonyLib;
using Jotunn.Managers;

namespace DoorOpenerBruh.Patches;

internal static class PlayerPatches
{
    [HarmonyPatch(typeof(Player), nameof(Player.SetLocalPlayer))]
    internal static class PlayerSetLocalPlayerPatch
    {
        [HarmonyPrepare]
        private static bool Prepare() => !GUIManager.IsHeadless();

        private static void Postfix()
        {
            if (DoorOpener.Instance == null) return;
            DoorOpener.Instance.ResetBruh();
        }
    }
}