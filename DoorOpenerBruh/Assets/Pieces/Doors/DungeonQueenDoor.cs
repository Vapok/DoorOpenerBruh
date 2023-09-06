using DoorOpenerBruh.Configuration;

namespace DoorOpenerBruh.Assets.Pieces.Doors;

public class DungeonQueenDoor : DoorPiece
{
    public DungeonQueenDoor(string prefabName, string pieceName, string configSection) : base(prefabName, pieceName, configSection)
    {
        RegisterConfigSettings();
    }

    public override bool DoorAutomationEnabled(Door trackedDoor)
    {
        var enabled = ComputeAutomation(trackedDoor, true);

        return enabled;
    }

    internal sealed override void RegisterConfigSettings()
    {
        RegisterAutomationMechanic();
        RegisterCheckForKey(false);
    }
}