using System.Collections.Generic;
using UnityEngine;

namespace FPSShooter.Modules.Meta.Upgrades
{
    [CreateAssetMenu(fileName = "UpgradeConfigBundle", menuName = "FPS Shooter/Upgrades/UpgradesBundle")]
    public sealed class UpgradeConfigBundle : ScriptableObject
    {
        [SerializeField] private List<UpgradeConfig> _upgradeConfigs;
        
        public IReadOnlyList<UpgradeConfig> UpgradeConfigs => _upgradeConfigs;
    }
}