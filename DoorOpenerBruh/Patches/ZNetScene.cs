using DoorOpenerBruh.Components;
using HarmonyLib;
using UnityEngine;

namespace DoorOpenerBruh.Patches;

internal static class ZNetScenePatches
{
    [HarmonyPatch(typeof(ZNetScene), nameof(ZNetScene.Awake))]
    internal static class ZNetSceneAwakePatch
    {
        [HarmonyPrepare]
        private static bool Prepare() => SystemInfo.graphicsDeviceType != UnityEngine.Rendering.GraphicsDeviceType.Null;

        private static void Prefix(ZNetScene __instance)
        {
            __instance.gameObject.AddComponent<DoorOpener>();
        }
    }
}