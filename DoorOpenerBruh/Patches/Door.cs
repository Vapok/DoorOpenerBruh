using DoorOpenerBruh.Components;
using HarmonyLib;

namespace DoorOpenerBruh.Patches;

public static class DoorPatches
{
    [HarmonyPatch(typeof(Door), nameof(Door.Awake))]
    public static class DoorAwakePatch
    {
        static void Postfix(Door __instance)
        {
            __instance.gameObject.AddComponent<DoorStatus>();
        }
    }
}