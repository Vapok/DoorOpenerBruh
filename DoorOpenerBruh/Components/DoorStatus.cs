using System;
using DoorOpenerBruh.Assets.Factories;
using UnityEngine;

namespace DoorOpenerBruh.Components;

public class DoorStatus : MonoBehaviour
{
    private Door _trackedDoor;
    private Piece _piece;
    private bool _enabled;
    private bool _inRange;
    private bool _autoOpened;
    private bool _isGhost;
    private int _status;
    private float _timeRemaining;
    private bool _started;

    public bool IsGhost => _isGhost;

    private void Awake()
    {
        _trackedDoor = gameObject.GetComponent<Door>();
        _piece = gameObject.GetComponent<Piece>();
        
        InvokeRepeating(nameof(UpdateState),0.0f,0.2f);
    }

    private void Start()
    {
        _isGhost = _trackedDoor.gameObject.layer == Piece.s_ghostLayer;
            
        if (_isGhost)
        {
            CancelInvoke(nameof(UpdateState));
            enabled = false;
            return;
        }
        
        DoorOpenerBruh.Log.Debug($"Door Name: {_trackedDoor.gameObject.name} - Env: {EnvMan.instance.m_forceEnv} - Creator: {_trackedDoor.m_nview.GetZDO().GetLong(ZDOVars.s_creator)} ");
        _started = true;
    }

    private void OnEnable()
    {
        DoorOpener.Instance.AddDoor(_trackedDoor);
    }

    private void OnDisable()
    {
        DoorOpener.Instance.RemoveDoor(_trackedDoor);
    }

    private void UpdateState()
    {
        if (_trackedDoor.m_nview.GetZDO().IsValid())
            _status = _trackedDoor.m_nview.GetZDO().GetInt(ZDOVars.s_state);
    }
    
    private void Update()
    {
        if (!_started) return;
        
        _timeRemaining -= Time.deltaTime;
        if (_timeRemaining > 0f)
            return;
        
        _timeRemaining = 0.02f;
        
        if (!DoorOpener.Instance.Enabled)
            return;

        CheckPlayerPositionForDoors();
    }

    private bool IsEnabled()
    {
        if (!DoorFactory.DoorPieces.TryGetValue(_trackedDoor.gameObject.name.Replace("(Clone)",String.Empty),out var doorPiece))
            doorPiece = DoorFactory.DoorPieces["other"];

        _enabled = doorPiece.DoorAutomationEnabled(_trackedDoor);
        return _enabled;
    }

    private void CheckPlayerPositionForDoors()
    {
        var player = DoorOpener.Instance.Bruh;
        
        if (player is null || player.IsDead())
            return;
        
        _inRange = PlayersInRange(player, _inRange, out var previousInRange);

        if (_inRange)
        {
            _enabled = IsEnabled();
            if (_enabled && ((_status == 0 && !_trackedDoor.m_invertedOpenClosedText)||(_status != 0 && _trackedDoor.m_invertedOpenClosedText)))
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
            if (_enabled && _autoOpened)
            {
                SetState(_trackedDoor.m_invertedOpenClosedText ? 1 :0);
                _autoOpened = false;
            }
        }
    }

    private bool PlayersInRange(Player player, bool currentInRange, out bool previouslyInRange)
    {
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