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
    
    internal ConfigEntry<AutomationMechanic> AutomationMechanic { get; private set;}
    internal ConfigEntry<bool> CheckForKey { get; private set;}
    
    public string PrefabName => _prefabName;
    public string PieceName => _pieceName;

    protected DoorPiece(string prefabName, string pieceName, string configSection)
    {
        _prefabName = prefabName;
        _pieceName = pieceName;
        _configSection = string.IsNullOrEmpty(configSection) ? $"Door: {pieceName}" : configSection;
    }

    public abstract bool DoorAutomationEnabled(Door trackedDoor);
    
    internal abstract void RegisterConfigSettings();
    
    internal virtual void RegisterAutomationMechanic(AutomationMechanic defaultValue = Components.AutomationMechanic.DoNotOpenAutomatically)
    {
        AutomationMechanic = ConfigSyncBase.SyncedConfig(_configSection, "Automation Mechanic", defaultValue,
            new ConfigDescription("Determine door open automation based on list provided.",
                null,
                new ConfigurationManagerAttributes { Category = _configSection, Order = 1 }));
    }

    internal virtual void RegisterCheckForKey(bool defaultValue)
    {
        CheckForKey = ConfigSyncBase.SyncedConfig(_configSection, "Check for Key", defaultValue,
            new ConfigDescription("If enabled, will automatically open locked doors, if player has key. If disabled, Doors with keys will not automatically open.",
                null,
                new ConfigurationManagerAttributes { Category = _configSection, Order = 2 }));
    }

    internal bool ComputeAutomation(Door trackedDoor, bool keyDefined = false)
    {
        var computeResult = false;
        switch (AutomationMechanic.Value)
        {
            case Components.AutomationMechanic.OpenAllDoors:
                computeResult = DefaultDoorEnablement(trackedDoor,keyDefined);
                break;
            case Components.AutomationMechanic.OnlyOpenSelfmadeDoors:
                computeResult = DefaultDoorEnablement(trackedDoor,keyDefined) &&
                                IsSelfMadeDoor(trackedDoor);
                break;
            case Components.AutomationMechanic.OnlyOpenAllPlayerMadeDoors:
                computeResult = DefaultDoorEnablement(trackedDoor,keyDefined) &&
                                IsPlayerMadeDoor(trackedDoor);
                break;
        }

        return computeResult;
    }

    private bool IsPlayerMadeDoor(Door trackedDoor)
    {
        if (trackedDoor.m_nview.GetZDO().IsValid())
            return trackedDoor.m_nview.GetZDO().GetLong(ZDOVars.s_creator) != 0L;

        return false;
    }
    
    private bool IsSelfMadeDoor(Door trackedDoor)
    {
        var player = DoorOpener.Instance.Bruh;

        if (trackedDoor.m_nview.GetZDO().IsValid())
            return trackedDoor.m_nview.GetZDO().GetLong(ZDOVars.s_creator) == player.GetPlayerID();

        return false;
    }

    private bool DefaultDoorEnablement(Door trackedDoor, bool keyDefined)
    {
        var status = trackedDoor.gameObject.GetComponent<DoorStatus>();
        
        var enabled = status is not null &&
                      status.isActiveAndEnabled &&
                      !status.IsGhost &&
                      ConfigRegistry.Enabled.Value &&
                      DoorOpener.Instance.Bruh is not null &&
                      DetermineCheckForKey(trackedDoor, keyDefined) &&
                      trackedDoor.CanInteract();

        return enabled;
    }

    private bool DetermineCheckForKey(Door trackedDoor, bool keyDefined)
    {
        var enabled = trackedDoor.m_keyItem is null;

        if (!keyDefined) return enabled;
        if (CheckForKey.Value)
        {
            enabled = true;
            if (trackedDoor.m_keyItem is not null)
                enabled = trackedDoor.HaveKey(DoorOpener.Instance.Bruh);
        }

        return enabled;
    }
}