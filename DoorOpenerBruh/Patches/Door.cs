using System.Collections.Generic;
using DoorOpenerBruh.Components;
using HarmonyLib;
using JetBrains.Annotations;
using Jotunn;
using Jotunn.Managers;
using UnityEngine;

namespace DoorOpenerBruh.Patches;

internal static class DoorPatches
{
    [HarmonyPatch(typeof(Door), nameof(Door.Awake))]
    internal static class DoorAwakePatch
    {
        [HarmonyPrepare]
        private static bool Prepare() => !GUIManager.IsHeadless();

        internal static Queue<Door> Doors = new ();
        
        [UsedImplicitly]
        private static void Postfix(Door __instance)
        {
            if (DoorOpener.Instance != null)
                __instance.gameObject.GetOrAddComponent<DoorStatus>();
            else
                Doors.Enqueue(__instance);
        }
    }
}
