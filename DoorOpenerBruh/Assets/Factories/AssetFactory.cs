using Vapok.Common.Abstractions;
using Vapok.Common.Managers.Configuration;

namespace DoorOpenerBruh.Assets.Factories;

internal abstract class AssetFactory : FactoryBase
{
    internal AssetFactory(ILogIt logger, ConfigSyncBase configs) : base(logger,configs)
    {
    }

    internal abstract void CreateAssets();
}