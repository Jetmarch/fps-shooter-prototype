using System;
using System.Collections.Generic;
using System.Linq;
using VContainer;

namespace FPSShooter.Modules.Meta.Upgrades
{
    [Serializable]
    public sealed class UpgradeFactory
    {
        private readonly List<UpgradeConfig> _upgradeConfigs;
        private readonly IObjectResolver _objectResolver;
        public UpgradeFactory(UpgradeConfigBundle configBundle, IObjectResolver objectResolver)
        {
            _upgradeConfigs = configBundle.UpgradeConfigs.ToList();
            _objectResolver = objectResolver;
        }

        public Upgrade[] CreateUpgrades()
        {
            var upgrades = new Upgrade[_upgradeConfigs.Count];

            for (int i = 0; i < upgrades.Length; i++)
            {
                upgrades[i] = _upgradeConfigs[i].CreateUpgrade();
                _objectResolver.Inject(upgrades[i]);
            }
            
            return upgrades;
        }
    }
}