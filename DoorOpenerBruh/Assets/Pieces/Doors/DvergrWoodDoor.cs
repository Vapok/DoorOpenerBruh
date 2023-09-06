﻿using DoorOpenerBruh.Configuration;

namespace DoorOpenerBruh.Assets.Pieces.Doors;

public class DvergrWoodDoor : DoorPiece
{
    public DvergrWoodDoor(string prefabName, string pieceName, string configSection) : base(prefabName, pieceName, configSection)
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
        RegisterAutomationMechanic();
    }
}