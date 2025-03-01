using FPSShooter.Modules.Gameplay.Weapons;
using FPSShooter.Modules.Meta.Upgrades;
using VContainer;

namespace FPSShooter.Game.Meta.Upgrades
{
    public sealed class WeaponAttackSpeedUpgrade : Upgrade
    {
        private readonly WeaponAttackSpeedUpgradeConfig _config;
        private Weapon _weapon;
        
        public WeaponAttackSpeedUpgrade(WeaponAttackSpeedUpgradeConfig config) : base(config)
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

            var valueIncrement = _config.AttackSpeedTableValue.GetValue(_currentLevel + 1) -
                                 _config.AttackSpeedTableValue.GetValue(_currentLevel);
            return valueIncrement;
        }
        
        public override void LevelUp()
        {
            base.LevelUp();
            var newSpeedValue = _config.AttackSpeedTableValue.GetValue(_currentLevel);
            _weapon.ReloadDelay.MaxValue = newSpeedValue;
        }
    }
}