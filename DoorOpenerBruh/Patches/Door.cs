using System.Collections.Generic;
using DoorOpenerBruh.Components;
using HarmonyLib;
using JetBrains.Annotations;

namespace DoorOpenerBruh.Patches;

public static class DoorPatches
{
    [HarmonyPatch(typeof(Door), nameof(Door.Awake))]
    public static class DoorAwakePatch
    {
        // This Queue is for tracking doors that have awoken before DoorOpener. 
        // We'll keep track of the doors until DoorOpener is available.
        
        public static Queue<Door> Doors  = new ();
        
        [UsedImplicitly]
        static void Postfix(Door __instance)
        {
            if (DoorOpener.Instance != null)
                __instance.gameObject.AddComponent<DoorStatus>();
            else
                Doors.Enqueue(__instance);
        }
    }
}