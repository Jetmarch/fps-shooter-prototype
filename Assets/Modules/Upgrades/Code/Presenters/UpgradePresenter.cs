using FPSShooter.Modules.CurrencyStorage;

namespace FPSShooter.Modules.Meta.Upgrades.Presenters
{
    public sealed class UpgradePresenter : IUpgradePresenter
    {
        public string Name => $"{_upgrade.DisplayName}";
        public string Value => $"Value: {_upgrade.GetUpgradeCurrentValue()} <color=green>(+{_upgrade.GetUpgradeValueIncrement()})</color>";
        public string Level => $"Level: {_upgrade.CurrentLevel}/{_upgrade.MaxLevel}";
        
        private readonly Upgrade _upgrade;
        private readonly ICurrencyStorage _moneyStorage;
        public UpgradePresenter(Upgrade upgrade, ICurrencyStorage moneyStorage)
        {
            _upgrade = upgrade;
            _moneyStorage = moneyStorage;
        }

        public IUpgradeButtonPresenter GetUpgradeButtonPresenter()
        {
            return new UpgradeButtonPresenter(_upgrade, _moneyStorage);
        }
    }
}