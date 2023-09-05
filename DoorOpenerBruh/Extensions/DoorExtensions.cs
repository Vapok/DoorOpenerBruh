using DoorOpenerBruh.Components;

namespace DoorOpenerBruh.Extensions;

public static class DoorExtensions
{
    public static DoorStatus GetDoorStatus(this Door trackedDoor)
    {
        return trackedDoor.gameObject.GetComponent<DoorStatus>();
    }
}