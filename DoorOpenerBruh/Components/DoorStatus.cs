using System;
using DoorOpenerBruh.Assets.Factories;
using DoorOpenerBruh.Assets.Pieces;
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
    private string _prefabCleanName;
    private IDoorPiece _doorPiece;
    private Collider[] _colliders;

    public bool IsGhost => _isGhost;
    public Door TrackedDoor => _trackedDoor;
    public bool Enabled => _enabled;

    private void Awake()
    {
        _trackedDoor = gameObject.GetComponent<Door>();
        _piece = gameObject.GetComponent<Piece>();
        _prefabCleanName = global::Utils.GetPrefabName(gameObject);
        _colliders = gameObject.GetComponentsInChildren<Collider>(true);
    }

    private void Start()
    {
        if (SystemInfo.graphicsDeviceType == UnityEngine.Rendering.GraphicsDeviceType.Null)
        {
            enabled = false;
            return;
        }

        _isGhost = _trackedDoor != null && _trackedDoor.gameObject.layer == Piece.s_ghostLayer;
            
        if (_isGhost)
        {
            enabled = false;
            return;
        }
        _started = true;
    }

    private void OnEnable()
    {
        if (DoorOpener.Instance != null)
            DoorOpener.Instance.AddDoor(_trackedDoor);
    }

    private void OnDisable()
    {
        if (DoorOpener.Instance != null)
            DoorOpener.Instance.RemoveDoor(_trackedDoor);
    }

    private void Update()
    {
        if (!_started) return;
        
        _timeRemaining -= Time.deltaTime;
        if (_timeRemaining > 0f)
            return;
        
        _timeRemaining = 0.02f;
        
        if (DoorOpener.Instance == null || !DoorOpener.Instance.Enabled)
            return;

        CheckPlayerPositionForDoors();
    }

    private IDoorPiece GetDoorPiece()
    {
        if (_doorPiece != null)
            return _doorPiece;

        if (string.IsNullOrEmpty(_prefabCleanName) && _trackedDoor != null)
            _prefabCleanName = global::Utils.GetPrefabName(gameObject);

        if (DoorFactory.DoorPieces != null)
        {
            if (DoorFactory.DoorPieces.TryGetValue(_prefabCleanName ?? string.Empty, out IDoorPiece doorPiece))
                _doorPiece = doorPiece;
            else if (DoorFactory.DoorPieces.TryGetValue("other", out IDoorPiece otherPiece))
                _doorPiece = otherPiece;
        }

        return _doorPiece;
    }

    private float GetDistanceToPlayer(Player player)
    {
        Vector3 playerPos = player.transform.position;
        float minDistance = Vector3.Distance(_trackedDoor.transform.position, playerPos);

        if (_colliders != null && _colliders.Length > 0)
        {
            for (int i = 0; i < _colliders.Length; i++)
            {
                Collider col = _colliders[i];
                if (col == null || !col.enabled || col.isTrigger) continue;

                Vector3 closest = col.bounds.ClosestPoint(playerPos);
                float dist = Vector3.Distance(closest, playerPos);
                if (dist < minDistance)
                    minDistance = dist;
            }
        }
        return minDistance;
    }

    private void CheckPlayerPositionForDoors()
    {
        if (DoorOpener.Instance == null) return;

        Player player = DoorOpener.Instance.Bruh;
        if (player == null || player.IsDead() || _trackedDoor == null)
            return;

        if (_trackedDoor.m_nview == null || !_trackedDoor.m_nview.IsValid())
            return;

        _status = _trackedDoor.m_nview.GetZDO().GetInt(ZDOVars.s_state, 0);

        IDoorPiece doorPiece = GetDoorPiece();
        float openDist = doorPiece?.GetOpenDistance() ?? 3.0f;
        float closeDist = doorPiece?.GetCloseDistance() ?? 4.5f;

        float currentDist = GetDistanceToPlayer(player);

        if (_inRange)
        {
            if (currentDist > closeDist)
                _inRange = false;
        }
        else
        {
            if (currentDist <= openDist)
                _inRange = true;
        }

        if (_inRange)
        {
            _enabled = doorPiece != null && doorPiece.DoorAutomationEnabled(this);
            if (_enabled && ((_status == 0 && !_trackedDoor.m_invertedOpenClosedText) || (_status != 0 && _trackedDoor.m_invertedOpenClosedText)))
            {
                if (!_autoOpened)
                {
                    try
                    {
                        _trackedDoor.Interact(player, false, false);
                    }
                    catch (Exception ex)
                    {
                        DoorOpenerBruh.Log.Warning($"Exception during door interaction: {ex.Message}");
                    }
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
                _enabled = doorPiece != null && doorPiece.DoorAutomationEnabled(this);
                if (_enabled)
                {
                    SetState(_trackedDoor.m_invertedOpenClosedText ? 1 : 0);
                }
                _autoOpened = false;
            }
        }
    }

    private void SetState(int state)
    {
        if (_trackedDoor != null && _trackedDoor.m_nview != null && _trackedDoor.m_nview.IsValid())
            _trackedDoor.m_nview.InvokeRPC("UseDoor", state);
    }
}
