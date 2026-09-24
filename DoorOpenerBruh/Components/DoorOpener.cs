using DoorOpenerBruh.Patches;
using Jotunn;
using UnityEngine;

namespace DoorOpenerBruh.Components;

public enum AutomationMechanic
{
    OnlyOpenSelfmadeDoors,
    OnlyOpenAllPlayerMadeDoors,
    OpenAllDoors,
    DoNotOpenAutomatically
}

public class DoorOpener : MonoBehaviour
{
    public static DoorOpener Instance;

    public Player Bruh => Player.m_localPlayer;
    public bool Enabled;
    public bool PlayerSet => Player.m_localPlayer != null;

    private int _doorCount;
    private bool _needsUpdating = true;
    
    private void Awake()
    {
        Instance = this;
        
        DoorOpenerBruh.Log.Debug($"Door Queue Count: {DoorPatches.DoorAwakePatch.Doors.Count}");
        
        while (DoorPatches.DoorAwakePatch.Doors != null && DoorPatches.DoorAwakePatch.Doors.Count > 0)
        {
            Door door = DoorPatches.DoorAwakePatch.Doors.Dequeue();
            
            if (door == null) continue;
            
            if (door.m_nview != null && door.m_nview.GetZDO() != null)
                DoorOpenerBruh.Log.Debug($"Queued Door ID: {door.m_nview.GetZDO().m_uid.ID}");
            
            door.gameObject.GetOrAddComponent<DoorStatus>();
        }
    }

    private void Update()
    {
        if (!_needsUpdating)
            return;

        if (Player.m_localPlayer == null)
            return;
        
        DoorOpenerBruh.Log.Debug($"Tracking {_doorCount} doors.");
        _needsUpdating = false;
    }

    public void ResetBruh()
    {
        _needsUpdating = true;
    }
    
    private void OnEnable()
    {
        Enabled = true;
    }

    private void OnDisable()
    {
        Enabled = false;
    }

    private void OnDestroy()
    {
        DoorPatches.DoorAwakePatch.Doors?.Clear();
        if (Instance == this)
            Instance = null;
    }

    public void AddDoor(Door trackedDoor)
    {
        _doorCount++;
        _needsUpdating = true;
    }

    public void RemoveDoor(Door trackedDoor)
    {
        _doorCount--;
        _needsUpdating = true;
    }
}
