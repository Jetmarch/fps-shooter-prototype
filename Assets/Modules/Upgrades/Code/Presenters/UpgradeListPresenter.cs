using System.Collections.Generic;
using FPSShooter.Modules.CurrencyStorage;

namespace FPSShooter.Modules.Meta.Upgrades.Presenters
{
    // ReSharper disable once ClassNeverInstantiated.Global
    public sealed class UpgradeListPresenter : IUpgradeListPresenter
    {
        private readonly Upgrade[] _upgrades;
        private readonly ICurrencyStorage _moneyStorage;

        public UpgradeListPresenter(Upgrade[] upgrades, ICurrencyStorage moneyStorage)
        {
            _upgrades = upgrades;
            _moneyStorage = moneyStorage;
        }
        
        public List<IUpgradePresenter> GetUpgradePresenters()
        {
            var upgradePresenters = new List<IUpgradePresenter>();
            foreach (var upgrade in _upgrades)
            {
                upgradePresenters.Add(new UpgradePresenter(upgrade, _moneyStorage));
            }
            
            return upgradePresenters;
        }

    }
}