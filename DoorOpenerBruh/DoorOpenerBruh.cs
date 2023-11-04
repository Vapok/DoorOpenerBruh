/* DoorOpenerBruh by Vapok */
using System;
using System.Reflection;
using BepInEx;
using HarmonyLib;
using JetBrains.Annotations;
using DoorOpenerBruh.Assets.Factories;
using DoorOpenerBruh.Configuration;
using Vapok.Common.Abstractions;
using Vapok.Common.Managers;
using Vapok.Common.Managers.Configuration;
using Vapok.Common.Managers.LocalizationManager;
using Vapok.Common.Tools;

namespace DoorOpenerBruh
{
    [BepInPlugin(_pluginId, _displayName, _version)]
    public class DoorOpenerBruh : BaseUnityPlugin, IPluginInfo
    {
        //Module Constants
        private const string _pluginId = "vapok.mods.DoorOpenerBruh";
        private const string _displayName = "DoorOpenerBruh";
        private const string _version = "1.1.4";
        
        //Interface Properties
        public string PluginId => _pluginId;
        public string DisplayName => _displayName;
        public string Version => _version;
        public BaseUnityPlugin Instance => _instance;
        
        //Class Properties
        public static ILogIt Log => _log;
        public static bool ValheimAwake;
        public static Waiting Waiter;
        
        //Class Privates
        private static DoorOpenerBruh _instance;
        private DoorFactory _doorFactory;
        private static ConfigSyncBase _config;
        private static ILogIt _log;
        private Harmony _harmony;
        
        [UsedImplicitly]
        // This the main function of the mod. BepInEx will call this.
        private void Awake()
        {
            //I'm awake!
            _instance = this;
            
            //Waiting For Startup
            Waiter = new Waiting();
            
            //Initialize Managers
            Initializer.LoadManagers(enableLocalizationManager: true);

            //Register Configuration Settings
            _config = new ConfigRegistry(_instance);

            //Register Logger
            LogManager.Init(PluginId,out _log);

            Localizer.Waiter.StatusChanged += InitializeModule;
            
            //Patch Harmony
            _harmony = new Harmony(Info.Metadata.GUID);
            _harmony.PatchAll(Assembly.GetExecutingAssembly());

            //???

            //Profit
        }

        public void InitializeModule(object send, EventArgs args)
        {
            if (ValheimAwake)
                return;
            
            //Register Effects
            var effectsFactory = new EffectsFactory(_log, _config);
            effectsFactory.RegisterEffects();
            
            //Register Assets
            _doorFactory = new DoorFactory(_log, _config);
            
            ConfigRegistry.Waiter.ConfigurationComplete(true);

            ValheimAwake = true;
        }
        
        private void OnDestroy()
        {
            _instance = null;
        }

        public class Waiting
        {
            public void ValheimIsAwake(bool awakeFlag)
            {
                if (awakeFlag)
                    StatusChanged?.Invoke(this, EventArgs.Empty);
            }
            public event EventHandler StatusChanged;            
        }
    }
}