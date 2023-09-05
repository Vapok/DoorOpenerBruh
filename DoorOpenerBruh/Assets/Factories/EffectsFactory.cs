using System;
using System.Collections.Generic;
using DoorOpenerBruh.Assets.Effects;
using Vapok.Common.Abstractions;
using Vapok.Common.Managers.Configuration;

namespace DoorOpenerBruh.Assets.Factories;

public enum DoorOpenerBruhEffects
{

}
public class EffectsFactory : FactoryBase
{
    public static Dictionary<DoorOpenerBruhEffects,EffectsBase> EffectList => _effectList;

    private static Dictionary<DoorOpenerBruhEffects,EffectsBase> _effectList = new();
    
    public EffectsFactory(ILogIt logger, ConfigSyncBase configs) : base(logger, configs)
    {
    
    }

    public void RegisterEffects()
    {
    }
}