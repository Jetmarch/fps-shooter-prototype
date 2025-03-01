using UnityEngine;

namespace FPSShooter.Modules.Meta.Upgrades.UI
{
    public sealed class UpgradePanelFactory
    {
        private readonly UpgradePanel _panelPrefab;
        private readonly Transform _panelContainer;

        public UpgradePanelFactory(UpgradePanel panelPrefab, Transform panelContainer)
        {
            _panelPrefab = panelPrefab;
            _panelContainer = panelContainer;
        }

        public UpgradePanel Create()
        {
            return Object.Instantiate(_panelPrefab, _panelContainer);
        }
    }
}