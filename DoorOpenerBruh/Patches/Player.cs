using DoorOpenerBruh.Components;
using HarmonyLib;

namespace DoorOpenerBruh.Patches;

public class PlayerPatches
{

    [HarmonyPatch(typeof(Player), nameof(Player.SetLocalPlayer))]
    public static class PlayerSetLocalPlayerPatch
    {
        static void Postfix()
        {
            if (DoorOpener.Instance == null) return;
            DoorOpener.Instance.ResetBruh();
        }
    }
}