using System;
using FPSShooter.Modules.CurrencyStorage;
namespace FPSShooter.Modules.Meta.Upgrades.Presenters
{
    public sealed class UpgradeButtonPresenter : IUpgradeButtonPresenter
    {
        public string Price => _upgrade.CurrentPrice.ToString();
        public bool CanLevelUp => _upgrade.CanLevelUp;
        public bool CanBuy => _moneyStorage.Amount >= _upgrade.CurrentPrice;
        public event Action OnMoneyChanged;
        
        private readonly Upgrade _upgrade;
        private readonly ICurrencyStorage _moneyStorage;
        
        public UpgradeButtonPresenter(Upgrade upgrade, ICurrencyStorage moneyStorage)
        {
            _upgrade = upgrade;
            _moneyStorage = moneyStorage;
            _moneyStorage.OnAmountChanged += NotifyMoneyChanged;
        }
        
        public void LevelUp()
        {
            UpgradeUseCase.LevelUp(_upgrade, _moneyStorage);
        }

        private void NotifyMoneyChanged()
        {
            OnMoneyChanged?.Invoke();
        }

        public void Dispose()
        {
            _moneyStorage.OnAmountChanged -= NotifyMoneyChanged;
        }
    }
}