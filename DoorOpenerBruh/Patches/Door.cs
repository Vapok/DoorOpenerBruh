using System.Collections.Generic;
using DoorOpenerBruh.Components;
using HarmonyLib;
using JetBrains.Annotations;
using Jotunn;
using UnityEngine;

namespace DoorOpenerBruh.Patches;

internal static class DoorPatches
{
    [HarmonyPatch(typeof(Door), nameof(Door.Awake))]
    internal static class DoorAwakePatch
    {
        internal static Queue<Door> Doors = new ();
        
        [UsedImplicitly]
        private static void Postfix(Door __instance)
        {
            if (SystemInfo.graphicsDeviceType == UnityEngine.Rendering.GraphicsDeviceType.Null)
                return;

            if (DoorOpener.Instance != null)
                __instance.gameObject.GetOrAddComponent<DoorStatus>();
            else
                Doors.Enqueue(__instance);
        }
    }
}
