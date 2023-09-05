using System;
using BepInEx.Configuration;
using UnityEngine;
using Vapok.Common.Abstractions;
using Vapok.Common.Managers.Configuration;
using Vapok.Common.Shared;

namespace DoorOpenerBruh.Configuration
{
    public class ConfigRegistry : ConfigSyncBase
    {
        //Configuration Entry Privates
        internal static ConfigEntry<bool> OpenCryptDoors { get; private set;}
        internal static ConfigEntry<bool> Enabled { get; private set;}
        
        public static Waiting Waiter;

        public ConfigRegistry(IPluginInfo mod): base(mod)
        {
            //Waiting For Startup
            Waiter = new Waiting();

            InitializeConfigurationSettings();
        }

        public sealed override void InitializeConfigurationSettings()
        {
            if (_config == null)
                return;
            
            //User Configs
            Enabled = SyncedConfig("Synced Settings", "Enable Auto Door", false,
                new ConfigDescription("If true, will automatically open doors.",
                    null, 
                    new ConfigurationManagerAttributes { Category = "Synced Settings", Order = 1 }));

            OpenCryptDoors = SyncedConfig("Synced Settings", "Open Crypt Doors", false,
                new ConfigDescription("If true, will auto open doors when in crypts.",
                    null, 
                    new ConfigurationManagerAttributes { Category = "Synced Settings", Order = 2 }));
        }
    }
    
    public class Waiting
    {
        public void ConfigurationComplete(bool configDone)
        {
            if (configDone)
                StatusChanged?.Invoke(this, EventArgs.Empty);
        }
        public event EventHandler StatusChanged;            
    }

}