using FPSShooter.Modules.Meta.Upgrades;
using UnityEngine;

namespace FPSShooter.Game.Meta.Upgrades
{
    [CreateAssetMenu(fileName = "WeaponReloadSpeedUpgradeConfig", menuName = "FPS Shooter/Upgrades/WeaponReloadSpeed")]
    public sealed class WeaponReloadSpeedUpgradeConfig : UpgradeConfig
    {
        public TableValue ReloadSpeedTableValue => _reloadSpeedTableValue;
        [SerializeField] private TableValue _reloadSpeedTableValue;
        
        public override Upgrade CreateUpgrade()
        {
            return new WeaponReloadSpeedUpgrade(this);
        }

        private void OnValidate()
        {
            Validate();
            _reloadSpeedTableValue.FillLevelPrices(MaxLevel);
        }
    }
}