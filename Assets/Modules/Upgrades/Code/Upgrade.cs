using System;

namespace FPSShooter.Modules.Meta.Upgrades
{
    [Serializable]
    public abstract class Upgrade
    {
        public string Id => Config.Id;
        public string DisplayName => Config.DisplayName;
        public int MaxLevel => Config.MaxLevel;
        public int CurrentLevel => _currentLevel;
        public float CurrentPrice => Config.PriceTableValue.GetValue(_currentLevel);
        public bool CanLevelUp => _currentLevel < MaxLevel;
        
        protected int _currentLevel = 1;
        
        protected UpgradeConfig Config;
        protected Upgrade(UpgradeConfig config)
        {
            Config = config;
        }

        public virtual void LevelUp()
        {
            _currentLevel++;
        }

        public abstract int GetUpgradeCurrentValue();
        public abstract int GetUpgradeValueIncrement();
    }
}