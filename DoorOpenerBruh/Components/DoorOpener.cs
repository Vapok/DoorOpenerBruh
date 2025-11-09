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

    public Player Bruh;
    public bool Enabled;
    public bool PlayerSet => _playerSet;

    private int _doorCount;
    private bool _needsUpdating = true;
    private bool _playerSet;
    
    private void Awake()
    {
        Instance = this;
    }

    private void Update()
    {
        if (!_needsUpdating)
            return;

        if (!_playerSet)
            if (Player.m_localPlayer != null)
            {
                Bruh = Player.m_localPlayer;
                _playerSet = true;
            }
            else
                return;
        
        DoorOpenerBruh.Log.Debug($"Tracking {_doorCount} doors.");
        _needsUpdating = false;
    }

    public void ResetBruh()
    {
        _playerSet = false;
    }
    
    private void OnEnable()
    {
        Enabled = true;
    }

    private void OnDisable()
    {
        Enabled = false;
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