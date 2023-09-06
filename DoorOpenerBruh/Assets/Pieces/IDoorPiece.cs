using DoorOpenerBruh.Components;

namespace DoorOpenerBruh.Assets.Pieces;

public interface IDoorPiece
{
    string PrefabName { get; }
    string PieceName { get; }
    bool DoorAutomationEnabled(Door trackedDoor);
}