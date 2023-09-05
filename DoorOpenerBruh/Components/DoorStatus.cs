using System;
using DoorOpenerBruh.Configuration;
using UnityEngine;

namespace DoorOpenerBruh.Components;

public class DoorStatus : MonoBehaviour
{
    private Door _trackedDoor;

    private bool _inRange;
    private bool _autoOpened;
    private int _status;
    private float _timeRemaining; 

    private void Awake()
    {
        _trackedDoor = gameObject.GetComponent<Door>();
        DoorOpener.Instance.AddDoor(_trackedDoor);
        InvokeRepeating(nameof(UpdateState),0.0f,0.1f);
    }

    private void Start()
    {
        UpdateState();
    }

    private void UpdateState()
    {
        if (!IsEnabled())
            return;

        if (_trackedDoor.m_nview.GetZDO().IsValid())
            _status = _trackedDoor.m_nview.GetZDO().GetInt(ZDOVars.s_state);
    }
    
    private void Update()
    {
        _timeRemaining -= Time.deltaTime;
        if (_timeRemaining > 0f)
            return;
        
        _timeRemaining = 1f/32;
        
        if (!DoorOpener.Instance.Enabled || !IsEnabled())
            return;

        CheckPlayerPositionForDoors();
    }

    private bool IsEnabled()
    {
        var enabled = ConfigRegistry.Enabled.Value &&
                      (!EnvMan.instance.m_forceEnv.Contains("Crypt") || ConfigRegistry.OpenCryptDoors.Value) &&
                      DoorOpener.Instance.Bruh is not null &&
                      _trackedDoor.m_keyItem is null &&
                      _trackedDoor.m_nview.HasOwner() &&
                      _trackedDoor.CanInteract();
        
        return enabled;
    }

    private void CheckPlayerPositionForDoors()
    {
        var player = DoorOpener.Instance.Bruh;
        
        if (player.IsDead())
            return;
        
        _inRange = PlayersInRange(player, _inRange, out var previousInRange);

        if (_inRange)
        {
            if (_status == 0)
            {
                if (!_autoOpened)
                {
                    _trackedDoor.Interact(player, false, false);
                    _autoOpened = true;
                }
            }
            else
            {
                _autoOpened = true;
            }
        }
        else
        {
            if (_autoOpened)
            {
                SetState(0);
                _autoOpened = false;
            }
        }
    }

    private bool PlayersInRange(Player player, bool currentInRange, out bool previouslyInRange)
    {
        var allPlayers = ZNet.instance.m_players;

        var inRange = false;
        
        previouslyInRange = currentInRange;
        
        var radius = player.m_maxInteractDistance;
        var radiusSquared = radius * radius;

        bool InRangeOfDoor(Vector3 playerPos)
        {
            var distanceSquared = Vector3.SqrMagnitude(_trackedDoor.transform.position - playerPos);
            return distanceSquared <= radiusSquared;
        }

        inRange = InRangeOfDoor(player.transform.position);
        
        return inRange;
    }
    private void SetState(int state)
    {
        if (_trackedDoor.m_nview.GetZDO().IsValid())
            _trackedDoor.m_nview.GetZDO().Set(ZDOVars.s_state,state);
    }
}