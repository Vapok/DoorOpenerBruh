using System;
using System.Collections.Generic;
using BepInEx.Configuration;
using DoorOpenerBruh.Configuration;
using Vapok.Common.Managers.Configuration;
using Vapok.Common.Shared;

namespace DoorOpenerBruh.Assets.Effects;

public abstract class EffectsBase
{
    public string EffectName => _effectName;
    public ConfigEntry<bool> EnabledEffect { get; private set;}

    private string _configSection;
    private string _effectName;
    private string _description;

    public EffectsBase(string effectName, string effectDesc)
    {
        _effectName = effectName;
        _description = string.IsNullOrEmpty(effectDesc) ? "Enables the effect." : effectDesc;
        _configSection = $"Effect: {effectName}";

        //RegisterEffectConfiguration();
    }

    public void RegisterEffectConfiguration()
    {
        
        EnabledEffect = ConfigSyncBase.SyncedConfig(_configSection, "Effect Enabled", true,
            new ConfigDescription(_description,
                null,
                new ConfigurationManagerAttributes { Order = 1 }));
        
        //Waiting For Startup
        //ConfigRegistry.Waiter.StatusChanged += ;
    }
}