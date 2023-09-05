using DoorOpenerBruh.Components;
using HarmonyLib;

namespace DoorOpenerBruh.Patches;

public static class ZNetScenePatches
{
    [HarmonyPatch(typeof(ZNetScene), nameof(ZNetScene.Awake))]
    public static class ZNetSceneAwakePatch
    {
        static void Prefix(ZNetScene __instance)
        {
            __instance.gameObject.AddComponent<DoorOpener>();
        }
    }
}