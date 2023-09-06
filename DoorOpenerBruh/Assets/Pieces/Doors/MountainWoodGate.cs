using DoorOpenerBruh.Configuration;

namespace DoorOpenerBruh.Assets.Pieces.Doors;

public class MountainWoodGate : DoorPiece
{
    public MountainWoodGate(string prefabName, string pieceName, string configSection) : base(prefabName, pieceName, configSection)
    {
        RegisterConfigSettings();
    }

    public override bool DoorAutomationEnabled(Door trackedDoor)
    {
        var enabled = ComputeAutomation(trackedDoor);

        return enabled;
    }

    internal sealed override void RegisterConfigSettings()
    {
        RegisterAutomationMechanic(Components.AutomationMechanic.OpenAllDoors);
    }
}