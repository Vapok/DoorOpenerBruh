using BepInEx.Configuration;
using DoorOpenerBruh.Components;
using DoorOpenerBruh.Configuration;
using Vapok.Common.Managers.Configuration;
using Vapok.Common.Shared;

namespace DoorOpenerBruh.Assets.Pieces;

public abstract class DoorPiece : IDoorPiece
{
    private string _configSection;
    private string _prefabName;
    private string _pieceName;
    
    internal ConfigEntry<AutomationMechanic> AutomationMechanic;
    internal ConfigEntry<bool> CheckForKey;
    internal ConfigEntry<float> OpenDistance;
    internal ConfigEntry<float> CloseDistance;
    
    public string PrefabName => _prefabName;
    public string PieceName => _pieceName;

    protected DoorPiece(string prefabName, string pieceName, string configSection)
    {
        _prefabName = prefabName;
        _pieceName = pieceName;
        _configSection = string.IsNullOrEmpty(configSection) ? $"Door: {pieceName}" : configSection;
    }

    public abstract bool DoorAutomationEnabled(DoorStatus trackedDoor);
    
    internal abstract void RegisterConfigSettings();

    public virtual float GetOpenDistance() => OpenDistance?.Value ?? 3.0f;
    public virtual float GetCloseDistance() => CloseDistance?.Value ?? 4.5f;

    internal virtual void RegisterDistances(float defaultOpen = 3.0f, float defaultClose = 4.5f)
    {
        ConfigSyncBase.UnsyncedConfig(_configSection, "Open Distance", defaultOpen,
            new ConfigDescription("Distance (in meters) from the door to automatically open.",
                null,
                new ConfigurationManagerAttributes { Category = _configSection, Order = 3 }), ref OpenDistance);

        ConfigSyncBase.UnsyncedConfig(_configSection, "Close Distance", defaultClose,
            new ConfigDescription("Distance (in meters) away from the door to automatically close.",
                null,
                new ConfigurationManagerAttributes { Category = _configSection, Order = 4 }), ref CloseDistance);
    }
    
    internal virtual void RegisterAutomationMechanic(AutomationMechanic defaultValue = Components.AutomationMechanic.DoNotOpenAutomatically, float defaultOpen = 3.0f, float defaultClose = 4.5f)
    {
        ConfigSyncBase.UnsyncedConfig(_configSection, "Automation Mechanic", defaultValue,
            new ConfigDescription("Determine door open automation based on list provided.",
                null,
                new ConfigurationManagerAttributes { Category = _configSection, Order = 1 }), ref AutomationMechanic);

        RegisterDistances(defaultOpen, defaultClose);
    }

    internal virtual void RegisterCheckForKey(bool defaultValue = true)
    {
        ConfigSyncBase.SyncedConfig(_configSection, "Check for Key", defaultValue,
            new ConfigDescription("If enabled, will automatically open locked doors, if player has key. If disabled, Doors with keys will not automatically open.",
                null,
                new ConfigurationManagerAttributes { Category = _configSection, Order = 2 }), ref CheckForKey);
    }

    internal bool ComputeAutomation(DoorStatus trackedDoor, bool keyDefined = false)
    {
        if (trackedDoor == null || trackedDoor.TrackedDoor == null)
            return false;

        bool computeResult = false;
        switch (AutomationMechanic.Value)
        {
            case Components.AutomationMechanic.OpenAllDoors:
                computeResult = DefaultDoorEnablement(trackedDoor, keyDefined);
                break;
            case Components.AutomationMechanic.OnlyOpenSelfmadeDoors:
                computeResult = DefaultDoorEnablement(trackedDoor, keyDefined) &&
                                IsSelfMadeDoor(trackedDoor);
                break;
            case Components.AutomationMechanic.OnlyOpenAllPlayerMadeDoors:
                computeResult = DefaultDoorEnablement(trackedDoor, keyDefined) &&
                                IsPlayerMadeDoor(trackedDoor);
                break;
        }

        return computeResult;
    }

    private bool IsPlayerMadeDoor(DoorStatus trackedDoor)
    {
        if (trackedDoor == null || trackedDoor.TrackedDoor == null)
            return false;

        ZNetView nview = trackedDoor.TrackedDoor.m_nview;
        if (nview != null && nview.IsValid())
            return nview.GetZDO().GetLong(ZDOVars.s_creator) != 0L;

        return false;
    }
    
    private bool IsSelfMadeDoor(DoorStatus trackedDoor)
    {
        Player player = DoorOpener.Instance != null ? DoorOpener.Instance.Bruh : null;
        if (player == null || trackedDoor == null || trackedDoor.TrackedDoor == null)
            return false;

        ZNetView nview = trackedDoor.TrackedDoor.m_nview;
        if (nview != null && nview.IsValid())
            return nview.GetZDO().GetLong(ZDOVars.s_creator) == player.GetPlayerID();

        return false;
    }

    private bool DefaultDoorEnablement(DoorStatus trackedDoor, bool keyDefined)
    {
        bool enabled = trackedDoor.isActiveAndEnabled &&
                      !trackedDoor.IsGhost &&
                      ConfigRegistry.Enabled.Value &&
                      DoorOpener.Instance != null &&
                      DoorOpener.Instance.PlayerSet &&
                      DetermineCheckForKey(trackedDoor, keyDefined) &&
                      trackedDoor.TrackedDoor.CanInteract();

        return enabled;
    }

    private bool DetermineCheckForKey(DoorStatus trackedDoor, bool keyDefined)
    {
        bool enabled = trackedDoor.TrackedDoor.m_keyItem == null;

        if (!keyDefined) return enabled;
        if (CheckForKey != null && CheckForKey.Value)
        {
            enabled = true;
            if (trackedDoor.TrackedDoor.m_keyItem != null)
            {
                Player player = DoorOpener.Instance != null ? DoorOpener.Instance.Bruh : null;
                enabled = player != null && trackedDoor.TrackedDoor.HaveKey(player);
            }
        }

        return enabled;
    }
}
