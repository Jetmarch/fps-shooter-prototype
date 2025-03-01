using System.Collections.Generic;
using FPSShooter.Modules.Meta.Upgrades.Presenters;
using Sirenix.OdinInspector;
using UnityEngine;
using VContainer;

namespace FPSShooter.Modules.Meta.Upgrades.UI
{
    public sealed class UpgradePanelList : MonoBehaviour
    {
        [SerializeField] private GameObject _container;
        [SerializeField] private List<UpgradePanel> _upgradePanels = new();
        
        private UpgradePanelFactory _panelFactory;

        private void Start()
        {
            Hide();
        }

        [Inject]
        public void Construct(UpgradePanelFactory panelFactory)
        {
            _panelFactory = panelFactory;
        }

        [Button]
        public void Show(IUpgradeListPresenter presenter)
        {
            _container.SetActive(true);
            ClearUpgradePanels();
            var upgradePresenters = presenter.GetUpgradePresenters();
            foreach (var upgradePresenter in upgradePresenters)
            {
                var upgradePanel = _panelFactory.Create();
                upgradePanel.Configure(upgradePresenter);
                _upgradePanels.Add(upgradePanel);
            }
        }
        
        [Button]
        public void Hide()
        {
            ClearUpgradePanels();
            _container.SetActive(false);
        }

        private void ClearUpgradePanels()
        {
            foreach (var upgradePanel in _upgradePanels)
            {
                upgradePanel.Hide();
                Destroy(upgradePanel.gameObject);
            }
            _upgradePanels.Clear();
        }
    }
}
