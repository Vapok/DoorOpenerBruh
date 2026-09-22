using DoorOpenerBruh.Components;
using HarmonyLib;
using UnityEngine;

namespace DoorOpenerBruh.Patches;

internal static class ZNetScenePatches
{
    [HarmonyPatch(typeof(ZNetScene), nameof(ZNetScene.Awake))]
    internal static class ZNetSceneAwakePatch
    {
        private static void Prefix(ZNetScene __instance)
        {
            if (SystemInfo.graphicsDeviceType == UnityEngine.Rendering.GraphicsDeviceType.Null)
                return;

            __instance.gameObject.AddComponent<DoorOpener>();
        }
    }
}