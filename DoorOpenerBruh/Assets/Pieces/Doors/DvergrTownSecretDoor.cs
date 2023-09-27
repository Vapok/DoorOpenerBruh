﻿using DoorOpenerBruh.Components;
using DoorOpenerBruh.Configuration;

namespace DoorOpenerBruh.Assets.Pieces.Doors;

public class DvergrTownSecretDoor : DoorPiece
{
    public DvergrTownSecretDoor(string prefabName, string pieceName, string configSection) : base(prefabName, pieceName, configSection)
    {
        RegisterConfigSettings();
    }

    public override bool DoorAutomationEnabled(DoorStatus trackedDoor)
    {
        var enabled = ComputeAutomation(trackedDoor);

        return enabled;
    }

    internal sealed override void RegisterConfigSettings()
    {
        RegisterAutomationMechanic();
    }
}