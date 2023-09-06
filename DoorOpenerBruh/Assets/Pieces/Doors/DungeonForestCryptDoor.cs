using DoorOpenerBruh.Configuration;

namespace DoorOpenerBruh.Assets.Pieces.Doors;

public class DungeonForestCryptDoor : DoorPiece
{
    public DungeonForestCryptDoor(string prefabName, string pieceName, string configSection) : base(prefabName, pieceName, configSection)
    {
        RegisterConfigSettings();
    }

    public override bool DoorAutomationEnabled(Door trackedDoor)
    {
        var enabled = ComputeAutomation(trackedDoor) && 
                      ConfigRegistry.OpenCryptDoors.Value;

        return enabled;
    }

    internal sealed override void RegisterConfigSettings()
    {
        RegisterAutomationMechanic();
    }
}