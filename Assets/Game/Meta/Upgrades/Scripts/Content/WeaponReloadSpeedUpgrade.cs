using FPSShooter.Modules.Gameplay.Weapons;
using FPSShooter.Modules.Meta.Upgrades;
using UnityEngine.Serialization;
using VContainer;

namespace FPSShooter.Game.Meta.Upgrades
{
    public sealed class WeaponReloadSpeedUpgrade : Upgrade
    {
        private readonly WeaponReloadSpeedUpgradeConfig _config;
        private Weapon _weapon;
        
        public WeaponReloadSpeedUpgrade(WeaponReloadSpeedUpgradeConfig config) : base(config)
        {
            _config = config;
        }

        [Inject]
        public void Configure(Weapon weapon)
        {
            _weapon = weapon;
        }

        public override int GetUpgradeCurrentValue()
        {
            return (int)_weapon.ReloadDelay.MaxValue;
        }

        public override int GetUpgradeValueIncrement()
        {
            if (!CanLevelUp)
            {
                return 0;
            }

            var valueIncrement = _config.ReloadSpeedTableValue.GetValue(_currentLevel + 1) -
                                 _config.ReloadSpeedTableValue.GetValue(_currentLevel);
            return (int)valueIncrement;
        }
        
        public override void LevelUp()
        {
            base.LevelUp();
            var newSpeedValue = _config.ReloadSpeedTableValue.GetValue(_currentLevel);
            _weapon.ReloadDelay.MaxValue = newSpeedValue;
        }
    }
}