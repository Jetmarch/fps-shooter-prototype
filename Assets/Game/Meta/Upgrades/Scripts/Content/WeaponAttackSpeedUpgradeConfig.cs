using FPSShooter.Modules.Meta.Upgrades;
using UnityEngine;

namespace FPSShooter.Game.Meta.Upgrades
{
    [CreateAssetMenu(fileName = "WeaponAttackSpeedUpgradeConfig", menuName = "FPS Shooter/Upgrades/WeaponAttackSpeed")]
    public sealed class WeaponAttackSpeedUpgradeConfig : UpgradeConfig
    {
        public TableValue AttackSpeedTableValue => _attackSpeedTableValue;
        [SerializeField] private TableValue _attackSpeedTableValue;
        
        public override Upgrade CreateUpgrade()
        {
            return new WeaponAttackSpeedUpgrade(this);
        }

        private void OnValidate()
        {
            Validate();
            _attackSpeedTableValue.FillLevelPrices(MaxLevel);
        }
    }
}