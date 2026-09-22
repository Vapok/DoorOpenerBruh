using DoorOpenerBruh.Components;
using HarmonyLib;
using Jotunn.Managers;
using UnityEngine;

namespace DoorOpenerBruh.Patches;

internal static class ZNetScenePatches
{
    [HarmonyPatch(typeof(ZNetScene), nameof(ZNetScene.Awake))]
    internal static class ZNetSceneAwakePatch
    {
        [HarmonyPrepare]
        private static bool Prepare() => !GUIManager.IsHeadless();

        private static void Prefix(ZNetScene __instance)
        {
            __instance.gameObject.AddComponent<DoorOpener>();
        }
    }
}