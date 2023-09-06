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

    private int _doorCount;
    private float _timeRemaining; 
    
    private void Awake()
    {
        Instance = this;
    }

    private void Update()
    {
        _timeRemaining -= Time.deltaTime;
        if (_timeRemaining > 0f)
            return;
        
        _timeRemaining = 5f;

        if (Player.m_localPlayer != null)
            Bruh = Player.m_localPlayer;
        
        DoorOpenerBruh.Log.Debug($"Tracking {_doorCount} doors.");
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
    }
    public void RemoveDoor(Door trackedDoor)
    {
        _doorCount--;
    }
}